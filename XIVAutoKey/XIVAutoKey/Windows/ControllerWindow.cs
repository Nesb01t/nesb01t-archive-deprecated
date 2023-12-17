using Dalamud.Interface.Windowing;
using ImGuiNET;
using System.Numerics;
using System;
using System.Threading;
using System.Runtime.InteropServices;
using Dalamud.Game.ClientState;
using XIVAutoKey.Libs;
using Dalamud.Logging;
using FFXIVClientStructs.FFXIV.Client.Game.Character;
using XIVAutoKey.Utils;

namespace XIVAutoKey.Windows
{
    internal unsafe class ControllerWindow : Window, IDisposable
    {
        private const string ControllerWindowName = "XIVAutoKey";

        private const ImGuiWindowFlags WindowFlags = ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse |
                                                     ImGuiWindowFlags.NoScrollbar |
                                                     ImGuiWindowFlags.NoScrollWithMouse;

        private Configuration configuration;
        private ClientState clientState;
        private Thread threadHotKey;
        private Thread threadSyncPlayerInfo;
        private Boolean isThreadRunning = true;
        private Boolean isInited = false;

        private string inputKeyString;
        private string inputLogslinkString;
        private IntPtr hWnd;
        private IntPtr playerAddr = IntPtr.Zero;
        private BattleChara* battleChara;
        private Character.CastInfo castInfo;
        private uint lastSpellID;
        private float x;
        private float y;
        private float z;

        private bool isHotkeyRunning;
        private bool isPlayerInfoSyncing = true;

        public ControllerWindow(Plugin plugin) : base(ControllerWindowName, WindowFlags)
        {
            // 窗口
            Size = new Vector2(0, 0);
            SizeCondition = ImGuiCond.Always;

            // 配置
            configuration = plugin.Configuration;
            clientState = plugin.clientState;
        }

        public override void OnOpen()
        {
            if (!isInited)
            {
                isInited = true;
                Init();
            }
        }

        public void Init()
        {
            threadHotKey = new Thread(Thread_HotKey);
            threadHotKey.Start();
            threadSyncPlayerInfo = new Thread(Thread_SyncPlayerInfo);
            threadSyncPlayerInfo.Start();

            inputKeyString = "";
            inputLogslinkString = "";
            hWnd = Common.GetHwnd();
            playerAddr = clientState.LocalPlayer.Address;
            battleChara =
                (FFXIVClientStructs.FFXIV.Client.Game.Character.BattleChara*)(void*)clientState.LocalPlayer
                    .Address;
        }

        public override void Draw()
        {
            ImGui.Text("全免费, 供学习 & 开发工具用途");

            if (ImGui.BeginTabBar("MainTab"))
            {
                if (ImGui.BeginTabItem("AutoClick"))
                {
                    // 输入使用的按键
                    ImGui.Text("输入使用的按键");
                    ImGui.SameLine();
                    ImGui.SetNextItemWidth(50);
                    if (ImGui.InputText("", ref inputKeyString, 1)) { }

                    // 按键状态: 暂停中
                    ImGui.Text("按键状态: ");
                    ImGui.SameLine();
                    var color = isHotkeyRunning ? ColorUtils.Green : ColorUtils.Red;
                    ImGui.PushStyleColor(ImGuiCol.Button, color);
                    if (ImGui.Button(isHotkeyRunning ? "运行中" : "暂停中"))
                    {
                        isHotkeyRunning = !isHotkeyRunning;
                    }

                    ImGui.PopStyleColor();

                    // 测试
                    ImGui.PushStyleColor(ImGuiCol.Text, ColorUtils.Grey);
                    ImGui.Text("[测试] keyChar: " + GetKeyChar());

                    // 单次点击
                    ImGui.Text("[测试] 单次点击按钮");
                    ImGui.SameLine();
                    if (ImGui.Button("点我"))
                    {
                        Common.SendHotkey(hWnd, GetKeyChar());
                    }

                    // 句柄
                    ImGui.Text("[测试] 句柄 hWnd: " + hWnd);

                    ImGui.PopStyleColor();
                    ImGui.EndTabItem();
                }

                if (ImGui.BeginTabItem("PlayerAddr"))
                {
                    // 获取位置状态
                    ImGui.Text("获取位置状态: ");
                    ImGui.SameLine();
                    var color = isPlayerInfoSyncing ? ColorUtils.Green : ColorUtils.Red;
                    ImGui.PushStyleColor(ImGuiCol.Button, color);
                    if (ImGui.Button(isPlayerInfoSyncing ? "正在获取" : "暂停获取"))
                    {
                        isPlayerInfoSyncing = !isPlayerInfoSyncing;
                    }

                    ImGui.PopStyleColor();

                    // 玩家 X Y Z
                    ImGui.Text("玩家 X ");
                    ImGui.SameLine();
                    ImGui.InputFloat("", ref x);
                    ImGui.Text("玩家 Y ");
                    ImGui.SameLine();
                    ImGui.InputFloat("", ref y);
                    ImGui.Text("玩家 Z ");
                    ImGui.SameLine();
                    ImGui.InputFloat("", ref z);

                    // 测试
                    ImGui.PushStyleColor(ImGuiCol.Text, ColorUtils.Grey);
                    ImGui.Text("[测试] playerAddr: " + playerAddr.ToString("X"));

                    ImGui.PopStyleColor();
                    ImGui.EndTabItem();
                }

                if (ImGui.BeginTabItem("ActionTimeLine"))
                {
                    ImGui.Text("[测试] 输入 FFLogs 链接");
                    ImGui.SameLine();
                    if (ImGui.InputText("", ref inputLogslinkString, 120)) { }

                    ImGui.Text("[测试] 读取到时间轴");
                    ImGui.SameLine();
                    if (ImGui.Button("点我"))
                    {
                        FFLogs ffLogs = new FFLogs("VFTjCvKxt87p2kNP", 5, "865d42a53607f4927c0e19c8529ea86b");
                        ffLogs.GetSpellList("荷拉德古娜");
                    }

                    ImGui.Text("[测试] 时间轴");
                    ImGui.SameLine();
                    if (ImGui.BeginListBox(""))
                    {
                        ImGui.Text("q");
                        ImGui.Separator();
                        ImGui.Text("q");

                        ImGui.EndListBox();
                    }


                    // 测试
                    ImGui.Text("[测试] 上个技能ID: " + lastSpellID);
                    ImGui.EndTabItem();
                }

                ImGui.EndTabBar();
            }
        }

        public override void Update()
        {
            if (!isInited) return;

            // 记录上个技能
            this.castInfo = battleChara->SpellCastInfo;
            var id = castInfo.UsedActionId;
            if (id != 0 && id != 8) lastSpellID = id;
        }

        public void Dispose()
        {
            isThreadRunning = false;
            threadHotKey.Join();
            threadSyncPlayerInfo.Join();
        }

        private void Thread_HotKey()
        {
            while (isThreadRunning)
            {
                if (isHotkeyRunning)
                {
                    Random random = new Random();
                    int interval = random.Next(140, 200);

                    Common.SendHotkey(hWnd, GetKeyChar());
                    this.IsOpen = true;

                    Thread.Sleep(interval);
                }
            }
        }

        private void Thread_SyncPlayerInfo()
        {
            while (isThreadRunning)
            {
                if (isPlayerInfoSyncing)
                {
                    SyncPlayerAxis();
                    Thread.Sleep(50);
                }
            }
        }

        private Char GetKeyChar()
        {
            if (inputKeyString.Length == 1)
            {
                return (Char)inputKeyString[0];
            }
            else
            {
                return '无';
            }
        }

        private void SyncPlayerAxis()
        {
            if (playerAddr == 0) return;
            x = Marshal.PtrToStructure<float>(playerAddr + 0xB0);
            y = Marshal.PtrToStructure<float>(playerAddr + 0xB4);
            z = Marshal.PtrToStructure<float>(playerAddr + 0xB8);
        }
    }
}
