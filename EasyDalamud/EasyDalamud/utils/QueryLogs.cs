using System;
using System.Collections.Generic;
using System.Net.Http;
using Dalamud.Logging;
using EasyDalamud.lib;
using Newtonsoft.Json;

namespace EasyDalamud.utils;

public static class QueryLogs
{
    public static List<Logs> GetLogs(string playerName, string server, int zone, string apiKey)
    {
        zone = 43;
        apiKey = "865d42a53607f4927c0e19c8529ea86b";

        // 从 fflogs 获取信息
        string url = "https://cn.fflogs.com:443/v1/parses/character/" + playerName + "/" + server + "/CN?zone=" + zone +
                     "&api_key=" + apiKey;
        HttpClient client = new HttpClient();
        var response = client.GetAsync(url).Result;
        var text = response.Content.ReadAsStringAsync().Result;
        var json = JsonConvert.DeserializeObject<dynamic>(text);

        // 获取 该玩家该区域所有 logs
        List<Logs> logsList = new List<Logs>();
        foreach (var i in json)
        {
            string dungeonName = i["encounterName"];
            string instanceSpec = i["spec"];
            long instanceRank = i["percentile"];
            string instancePatch = i["ilvlKeyOrPatch"];
            long startTime = i["startTime"];
            Logs logs = new Logs(dungeonName, instanceSpec, instanceRank, instancePatch, startTime);
            logsList.Add(logs);
        }

        return logsList;
    }
}
