// 单元测试
// 读取当前所有窗口到 enum_window.log 文件中
#include <fstream>
#include <iostream>
#include <windows.h>

using namespace std;

/// @brief 枚举回调函数
/// @param hwnd 句柄
/// @param lParam 回调
/// @return
BOOL CALLBACK EnumWindowsProc(HWND hwnd, LPARAM lParam)
{
  // 读取窗口标题
  char windowTitle[256];
  GetWindowTextA(hwnd, windowTitle, sizeof(windowTitle));
  cout << windowTitle << ", ";

  // 打开文件
  ofstream outputFile("enum_window.log", ios::app);
  if (!outputFile.is_open())
  {
    cout << "unable to open log." << endl;
    return FALSE;
  }

  // 传入文件
  outputFile << windowTitle << endl;
  outputFile.close();
  return TRUE;
}

/// @brief 清除文件内容
BOOL ClearLogFile()
{
  ofstream file("enum_window.log", ios::trunc);
  if (!file.is_open())
  {
    cout << "unable to clear log." << endl;
    return FALSE;
  }

  file.close();
  return TRUE;
}

int main()
{
  ClearLogFile();
  EnumWindows(EnumWindowsProc, NULL);
  return 0;
}