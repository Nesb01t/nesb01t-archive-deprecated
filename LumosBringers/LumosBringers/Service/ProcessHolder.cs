using System;
using LumosBringers.Constants;

namespace LumosBringers.Lib;

/// <summary>
/// 进程管理人
/// </summary>
public class ProcessHolder
{
    private const int ProcessAllAccess = 0x1F0FFF;

    private bool _isAccessed;
    private string _gameTitle = "";
    private IntPtr _hWnd;

    public bool IsInGame;
    public IntPtr hProcess;

    public ProcessHolder()
    {
        UpdateInfo();
    }

    /// <summary>
    /// 更新所有状态
    /// </summary>
    public void UpdateInfo()
    {
        _isAccessed = GetPrivilege();
        _gameTitle = ReadGameTitle();

        // 避免重复获取 hProcess
        var tmpHwnd = GetHwnd();
        if (_hWnd == tmpHwnd) return;
        _hWnd = tmpHwnd;

        // 强制重新获取
        // _hWnd = GetHwnd();

        hProcess = GetProcessHandle();
        IsInGame = GetIsInGame();
    }

    /// <summary>
    /// DEBUGGER 调试输出
    /// </summary>
    public string PrintHelper()
    {
        string prefix = "[ProcessHelper] ";
        string s = (prefix + "isAccessed: " + _isAccessed + '\r');
        s += (prefix + "gameTitle: " + _gameTitle + '\r');
        s += (prefix + "hWnd: " + _hWnd + '\r');
        s += (prefix + "hProcess: " + hProcess + '\r');
        s += (prefix + "isInGame: " + IsInGame + '\r');
        return s;
    }

    private bool GetPrivilege()
    {
        if (_isAccessed) return true;
        bool f = CommonHelpher.EnableDebugPrivilege(true);
        return f;
    }

    private string ReadGameTitle()
    {
        return "World of Warcraft";
    }

    private IntPtr GetHwnd()
    {
        // 查找窗口 -> 句柄
        return CommonHelpher.FindWoW(_gameTitle);
    }

    private IntPtr GetProcessHandle()
    {
        // 获取 hProcess
        uint pid;
        WinApiHelper.GetWindowThreadProcessId(_hWnd, out pid);
        return WinApiHelper.OpenProcess(ProcessAllAccess, false, pid);
    }

    private bool GetIsInGame()
    {
        var f = MemoryHelper.ReadMem32(hProcess, Offsets.IsInGame);
        return f > 0;
    }
}