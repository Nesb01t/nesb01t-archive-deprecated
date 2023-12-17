using System.Collections.Generic;
using Dalamud.Logging;
using EasyDalamud.lib;

namespace EasyDalamud.test;

public static class PlayerListTest
{
    public static void InfoOutput(List<Player> players)
    {
        foreach (var player in players)
        {
            PluginLog.Log(player.Name);
        }
    }
}
