using System;
using LumosBringers.Lib;

namespace LumosBringers.Test;

public class ProcessHolderTest
{
    public static string Test()
    {
        string s = "[Debug] 正在开始 ProcessHolderTest\r";

        s += "如果 hProcess 为 0 则启动失败!\r";
        s += Core.ProcessHolder.PrintHelper();
        
        return s;
    }
}