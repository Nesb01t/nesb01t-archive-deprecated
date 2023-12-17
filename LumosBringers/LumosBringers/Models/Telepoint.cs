using Newtonsoft.Json;

namespace LumosBringers.Models;

public class Telepoint
{
    [JsonProperty("Name")] public string Name { get; set; }
    [JsonProperty("MapId")] public int MapId { get; set; }
    [JsonProperty("PosX")] public float PosX { get; set; }
    [JsonProperty("PosY")] public float PosY { get; set; }
    [JsonProperty("PosZ")] public float PosZ { get; set; }

    public Telepoint(float x, float y, float z)
    {
        PosX = x;
        PosY = y;
        PosZ = z;
    }

    public override string ToString()
    {
        return Name + ", " + PosX + ", " + PosY + ", " + PosZ;
    }
}