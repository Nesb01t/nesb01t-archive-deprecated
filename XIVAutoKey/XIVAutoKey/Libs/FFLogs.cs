using System.Collections.Generic;
using System.Net.Http;
using Dalamud.Logging;
using Newtonsoft.Json;
using XIVAutoKey.Models;

namespace XIVAutoKey.Libs;

public class FFLogs
{
    private string apikey;
    private string code;
    private int fightid;

    public int Zoneid;
    public int StartTime;
    public int EndTime;
    public Dictionary<string, int> PlayerIdDictionary = new Dictionary<string, int>();

    public FFLogs(string code, int fightid, string apikey)
    {
        this.apikey = apikey;
        this.code = code;
        this.fightid = fightid;
        GetFights();
    }

    public void GetFights()
    {
        string url = "https://cn.fflogs.com:443/v1/report/fights/" + code + "?api_key=" + apikey;
        HttpClient client = new HttpClient();
        var response = client.GetAsync(url).Result;
        var text = response.Content.ReadAsStringAsync().Result;
        var json = JsonConvert.DeserializeObject<dynamic>(text);

        var fight = json.fights[fightid];
        Zoneid = fight.zoneID;
        StartTime = fight.start_time;
        EndTime = fight.end_time;

        var friendlies = json.friendlies;
        foreach (var i in friendlies)
        {
            if (i.name != "Multiple Players")
            {
                string name = i.name;
                int id = i.id;
                PlayerIdDictionary.Add(name, id);
            }
        }
    }

    public void GetSpellList(string name)
    {
        var startTime = StartTime;
        var endTime = EndTime;
        var sourceid = PlayerIdDictionary[name];
        
        string url = "https://cn.fflogs.com:443/v1/report/events/casts/" + code + "?api_key=" + apikey + "&start=" +
                     startTime + "&end=" + endTime + "&sourceid="+sourceid;
        HttpClient client = new HttpClient();
        var response = client.GetAsync(url).Result;
        var text = response.Content.ReadAsStringAsync().Result;
        var json = JsonConvert.DeserializeObject<dynamic>(text);

        var events = json.events;
        foreach (var i in events)
        {
            string spellName = i.ability.name;
            PluginLog.Error(spellName);
        }
    }
}
