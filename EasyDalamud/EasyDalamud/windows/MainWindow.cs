using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using Dalamud.Game.ClientState.Party;
using Dalamud.Interface.Windowing;
using Dalamud.Logging;
using EasyDalamud.lib;
using EasyDalamud.test;
using EasyDalamud.utils;
using FFXIVClientStructs.FFXIV.Client.UI;
using ImGuiNET;

namespace EasyDalamud.windows;

public class MainWindow : Window, IDisposable
{
    private string dungeonName = "究极神兵绝境战";
    private List<Player> players = new List<Player>();
    private EasyDalamud easyDalamud;

    public MainWindow(EasyDalamud easyDalamud) : base("别查我 Logs, 哥!",
                                                      ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(160, 100),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };
        this.easyDalamud = easyDalamud;
    }


    public override void Draw()
    {
        if (ImGui.Button("给我狠狠地查!"))
        {
            // 获取玩家列表及其logs
            players = PlayerList.GetPlayerList(easyDalamud.PartyList);
            foreach (var player in players)
            {
                player.ReadPlayerLogs(dungeonName);
            }
        }

        ImGui.PushItemWidth(200);
        ImGui.SameLine();
        ImGui.InputText("输入副本名", ref dungeonName, 20);
        ImGui.PopItemWidth();

        // 渲染列表
        ImGui.BeginGroup();
        ImGui.Columns(5, "Columns");
        ImGui.Text("编号");
        ImGui.NextColumn();
        ImGui.Text("玩家");
        ImGui.NextColumn();
        ImGui.Text("常用职业");
        ImGui.NextColumn();
        ImGui.Text("最好成绩");
        ImGui.NextColumn();
        ImGui.Text("平均成绩");
        ImGui.NextColumn();
        for (int i = 0; i < players.Count; i++)
        {
            string lineId = (i + 1).ToString();
            string lineName = players[i].GenePlayerNameAndServer();
            string lineSpec = players[i].BestSpec;
            string lineBest = players[i].BestRank.ToString();
            string lineAvg = players[i].AvgRank.ToString();

            ImGui.Separator();
            ImGui.Text(lineId);
            ImGui.NextColumn();
            ImGui.Text(lineName);
            ImGui.NextColumn();
            ImGui.Text(lineSpec);
            ImGui.NextColumn();
            ImGui.TextColored(LogsColor.GetColor(players[i].BestRank), lineBest);
            ImGui.NextColumn();
            ImGui.TextColored(LogsColor.GetColor(players[i].AvgRank), lineAvg);
            if (i != players.Count - 1) ImGui.NextColumn();
        }

        ImGui.EndGroup();
    }

    public void Dispose() { }
}
