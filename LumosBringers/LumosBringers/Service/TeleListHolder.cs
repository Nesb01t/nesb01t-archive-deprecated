using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using LumosBringers.Models;

namespace LumosBringers.Service;

public class TeleListHolder
{
    public List<Telepoint> points = new List<Telepoint>();

    public TeleListHolder()
    {
        UpdatePointFromTeleListJson();
    }

    public void UpdatePointFromTeleListJson()
    {
        string filePath = "./TeleList.json";
        string json = File.ReadAllText(filePath);
        
        points = JsonConvert.DeserializeObject<List<Telepoint>>(json);
    }
}