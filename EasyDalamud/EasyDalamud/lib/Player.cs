using System;
using System.Collections.Generic;
using EasyDalamud.utils;

namespace EasyDalamud.lib;

public class Player
{
    public string Server = "";     // 服务器名
    public string Name = "";       // 玩家姓名
    public string BestSpec = "未知"; // 常用职业
    public long BestRank = 0;      // 常用职业的最好排名
    public int BestSpecTimes = 0;  // 常用职业的过本次
    public double AvgRank = 0;     // 常用职业的平均分数

    public Player(string name, string server)
    {
        Server = server;
        Name = name;
    }

    /// <summary>
    /// 读入特定副本的 logs 信息到 player 对象
    /// </summary>
    /// <param name="dungeonName"></param>
    public void ReadPlayerLogs(string dungeonName)
    {
        List<Logs> playerLogs = QueryLogs.GetLogs(Name, Server, 43, "865d42a53607f4927c0e19c8529ea86b");
        Dictionary<string, int> SpecCountDict = new Dictionary<string, int>();     // 职业过本次数
        Dictionary<string, long> SpecBestDict = new Dictionary<string, long>();    // 职业最好rank
        Dictionary<string, long> SpecRankSumDict = new Dictionary<string, long>(); // 职业rank总和
        foreach (var logs in playerLogs)
        {
            if (dungeonName != logs.DungeonName)
            {
                continue;
            }
            else
            {
                // 录入词典
                string spec = logs.InstanceSpec;
                long rank = logs.InstanceRank;
                if (SpecCountDict.ContainsKey(logs.InstanceSpec)) // 已经有这个职业的logs记录
                {
                    SpecCountDict[spec]++;
                    SpecBestDict[spec] = Int64.Max(SpecBestDict[spec], rank); // 成绩更好则改变
                    SpecRankSumDict[spec] += rank;
                }
                else
                {
                    SpecCountDict[spec] = 1;
                    SpecBestDict[spec] = rank;
                    SpecRankSumDict[spec] = rank;
                }
            }
        }

        // 读入 player 变量
        foreach (var pair in SpecCountDict)
        {
            if (pair.Value > BestSpecTimes)
            {
                BestSpecTimes = pair.Value;
                BestSpec = pair.Key;
                BestRank = SpecBestDict[BestSpec];
                AvgRank = SpecRankSumDict[BestSpec] / BestSpecTimes;
            }
        }
    }

    /// <summary>
    /// 生成玩家姓名@服务器
    /// </summary>
    /// <returns></returns>
    public string GenePlayerNameAndServer()
    {
        return Name + "@" + Server;
    }
}
