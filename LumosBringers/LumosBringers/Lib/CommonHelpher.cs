using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using LumosBringers.Constants;
using static LumosBringers.Lib.WinApiHelper;

namespace LumosBringers.Lib;

/// <summary>
/// 一些帮助实现窗口和权限功能的类
/// </summary>
public class CommonHelpher
{
    /// <summary>
    /// 启用或禁用调试权限
    /// </summary>
    /// <param name="bEnable"></param>
    /// <returns></returns>
    public static bool EnableDebugPrivilege(bool bEnable)
    {
        IntPtr hToken = IntPtr.Zero;
        WinApiHelper.LUID luid;

        if (!OpenProcessToken(Process.GetCurrentProcess().Handle, TOKEN_ADJUST_PRIVILEGES, out hToken))
            return false;

        if (!LookupPrivilegeValue(null, SE_DEBUG_NAME, out luid))
            return false;

        WinApiHelper.TOKEN_PRIVILEGES tokenPriv;
        tokenPriv.PrivilegeCount = 1;
        tokenPriv.Privileges.Luid = luid;
        tokenPriv.Privileges.Attributes = bEnable ? (uint)SE_PRIVILEGE_ENABLED : 0;

        if (!AdjustTokenPrivileges(hToken, false, ref tokenPriv, (uint)Marshal.SizeOf(tokenPriv), IntPtr.Zero,
                IntPtr.Zero))
            return false;

        return true;
    }

    /// <summary>
    /// 寻找窗口
    /// </summary>
    /// <param name="gameTitle"></param>
    /// <returns></returns>
    public static IntPtr FindWoW(string gameTitle)
    {
        return FindWindow(null, gameTitle);
    }

    /// <summary>
    /// 更新玩家 AFK 状态
    /// </summary>
    /// <param name="hProcess"></param>
    /// <returns></returns>
    public static bool UpdateAFK(IntPtr hProcess)
    {
        int tick = GetTickCount();
        byte[] buffer = BitConverter.GetBytes(tick);
        return MemoryHelper.WriteMem(hProcess, Offsets.LastHardwareAction, buffer, sizeof(int));
    }

    /// <summary>
    /// 判断玩家是否在游戏中
    /// </summary>
    /// <param name="hProcess"></param>
    /// <returns></returns>
    public static bool IsLoggedIn(IntPtr hProcess)
    {
        int value = MemoryHelper.ReadMem32(hProcess, Offsets.IsInGame);
        return value != 0;
    }
}