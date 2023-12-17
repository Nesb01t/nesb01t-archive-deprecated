namespace LumosBringers.Test;

public class TeleListHolderTest
{
    public static string Test()
    {
        string s = "[Debug] 正在开始 TeleListHolderTest\r";

        foreach (var p in Core.TeleListHolder.points)
        {
            s += p + "\r";
        }

        return s;
    }
}