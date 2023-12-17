using System.Drawing;
using System.Numerics;
using Dalamud.Interface.Colors;
using ImGuiNET;

namespace EasyDalamud.utils;

public class LogsColor
{
    public static Vector4 GetColor(long rank)
    {
        if (rank == 100)
        {
            // 金色
            return ImGuiColors.DalamudYellow;
        }
        else if (rank >= 98)
        {
            // 粉色
            return ImGuiColors.DalamudViolet;
        }
        else if (rank >= 96)
        {
            // 橙色
            return ImGuiColors.DalamudOrange;
        }
        else if (rank >= 75)
        {
            // 紫色
            return ImGuiColors.ParsedPurple;
        }
        else if (rank >= 50)
        {
            return ImGuiColors.ParsedBlue;
        }
        else if (rank >= 25)
        {
            return ImGuiColors.HealerGreen;
        }
        else
        {
            return ImGuiColors.DalamudGrey;
        }
    }

    public static Vector4 GetColor(double rank)
    {
        long l = (long)rank;
        return GetColor(l);
    }
}
