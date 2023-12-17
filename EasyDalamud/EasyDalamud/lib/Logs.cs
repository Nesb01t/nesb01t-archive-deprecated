using System;

namespace EasyDalamud.lib;

public class Logs
{
    public string DungeonName { get; set; }   // 副本名
    public string InstanceSpec { get; set; }  // 过本职业
    public long InstanceRank { get; set; }    // 过本排名
    public string InstancePatch { get; set; } // 版本号
    public long StartTime { get; set; }       // 开始时间

    public Logs(string dungeonName, string instanceSpec, long instanceRank, string instancePatch, long startTime)
    {
        DungeonName = dungeonName;
        InstanceSpec = instanceSpec;
        StartTime = startTime;
        InstanceRank = instanceRank;
        InstancePatch = instancePatch;
    }

    public DateTime GetStartDate()
    {
        return DateTimeOffset.FromUnixTimeSeconds(StartTime / 1000).DateTime;
    }

    public string GenerateLogString()
    {
        return DungeonName + InstancePatch + InstanceRank + InstanceSpec + GetStartDate();
    }
}
