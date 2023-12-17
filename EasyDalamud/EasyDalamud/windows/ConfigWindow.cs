using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace EasyDalamud.windows;

public class ConfigWindow : Window, IDisposable
{
    private Configuration Configuration;

    public ConfigWindow(EasyDalamud easyDalamud) : base("配置窗口", ImGuiWindowFlags.NoScrollbar |
                                                                ImGuiWindowFlags.NoScrollWithMouse)
    {
        this.Size = new Vector2(200, 50);
        SizeCondition = ImGuiCond.Always;
        Configuration = easyDalamud.Configuration;
    }

    public void Dispose()
    {
        
    }

    public override void Draw()
    {
        var configValue = Configuration.SomePropertyToBeSavedAndWithADefault;
        if (ImGui.Checkbox("你好", ref configValue))
        {
            Configuration.SomePropertyToBeSavedAndWithADefault = configValue;
            Configuration.Save();
        }
    }
}
