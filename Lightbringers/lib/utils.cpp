#pragma once
#include "../constants/offset.h"
#include "memory.cpp"

// 定义回调函数类型 FindWoW_Callback，用于 FindWindow 函数
typedef VOID (*FindWoW_Callback)(HANDLE hWnd);

/// @brief 启用或禁用调试权限
/// @param bEnable 是否启用调试权限，TRUE 表示启用，FALSE 表示禁用
/// @return 成功返回 TRUE，失败返回 FALSE
BOOL EnableDebugPrivilege(BOOL bEnable)
{
  HANDLE hToken = NULL; // 声明一个句柄变量
  LUID luid;            // LUID 结构体变量 luid，用于存储特权值

  // 打开当前进程的访问令牌
  if (!OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES, &hToken))
    return FALSE;

  // 查找调试权限的特权值
  if (!LookupPrivilegeValue(NULL, SE_DEBUG_NAME, &luid))
    return FALSE;

  TOKEN_PRIVILEGES tokenPriv;          // 存储特权信息
  tokenPriv.PrivilegeCount = 1;        // 设置特权数量为 1
  tokenPriv.Privileges[0].Luid = luid; // 将查找到的特权值存储到 tokenPriv 中
  tokenPriv.Privileges[0].Attributes =
      bEnable ? SE_PRIVILEGE_ENABLED : 0; // 根据传入的 bEnable 参数确定特权状态

  // 调整令牌的特权
  if (!AdjustTokenPrivileges(hToken, FALSE, &tokenPriv,
                             sizeof(TOKEN_PRIVILEGES), NULL, NULL))
    return FALSE;

  return TRUE;
}

/// @brief 寻找进程的回调函数
/// @param hWnd 传入的窗口句柄
/// @param lParam 传入的回调函数指针
/// @return 成功返回 TRUE
BOOL CALLBACK FindWoW_Process(HWND hWnd, LONG lParam)
{
  CHAR title_buff[255];

  if (IsWindowVisible(hWnd)) // 窗口可见
  {
    GetWindowTextA(hWnd, (LPSTR)title_buff, 254); // 获取窗口标题
    if (strcmp(title_buff, "World of Warcraft") == 0)
    {
      // 如果窗口标题是 "World of Warcraft"，则调用回调函数
      ((FindWoW_Callback)lParam)(hWnd);

      // 语法解析
      // FindWoW_Callback callback = (FindWoW_Callback)lParam;
      // callback(hWnd);
    }
  }
  return TRUE;
}

/// @brief 寻找 WoW 进程
/// @param callback 对每个窗口进程执行的函数
/// @return
BOOL FindWoW(FindWoW_Callback callback)
{
  // EnumWindows(FindWoW_Process, (LONG)callback);
  // 枚举所有窗口，并对每个窗口调用 FindWoW_Process 函数
}

/// @brief 更新玩家的 AFK 状态
/// @param hProcess 游戏进程
/// @return
BOOL UpdateAFK(HANDLE hProcess)
{
  // 将当前系统时间写入指定内存地址，用于更新处于离开状态的玩家信息
  int tick = GetTickCount();
  return WriteMem(hProcess, O_last_hardware_action, &tick, sizeof(tick));
}

/// @brief 获取玩家在游戏中
/// @param hProcess 游戏进程
/// @return
BOOL IsLoggedIn(HANDLE hProcess)
{
  // 读取指定内存地址的值，如果不为 0，则表示玩家已登录
  return ReadMemory32(hProcess, O_is_ingame) != 0;
}