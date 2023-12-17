using System;
using System.Diagnostics;
using LumosBringers.Lib;
using LumosBringers.Service;

namespace LumosBringers;

public class Core
{
    public static ProcessHolder? ProcessHolder;
    public static ObjectHolder? ObjectHolder;
    public static TeleListHolder? TeleListHolder;

    public static readonly short UpdateIntervalUi = 10; // UI 更新间隔毫秒
    public static readonly short UpdateIntervalObject = 10; // 更新间隔毫秒

    public static void Init()
    {
        ProcessHolder = new ProcessHolder();
        ObjectHolder = new ObjectHolder(ProcessHolder.hProcess);
        TeleListHolder = new TeleListHolder();
    }

    /// <summary>
    /// 更新加载进程
    /// </summary>
    public static void UpdateProcess()
    {
        ProcessHolder.UpdateInfo();
        if (ProcessHolder.IsInGame == false) return;
        ObjectHolder.hProcess = ProcessHolder.hProcess;
    }
}