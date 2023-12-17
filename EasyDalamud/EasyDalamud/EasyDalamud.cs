using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using EasyDalamud.utils;
using Dalamud.Game.Network;
using Dalamud.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dalamud.Game.ClientState.Party;
using Dalamud.Interface.Windowing;
using EasyDalamud.windows;

namespace EasyDalamud
{
    public sealed class EasyDalamud : IDalamudPlugin
    {
        // 固定配置
        public string Name => "EasyDalamud";
        private const string CommandEd = "/ed";
        private const string CommandEnet = "/enet";


        // 插件核心
        public static EasyDalamud instance;
        public DalamudPluginInterface PluginInterface { get; init; }
        public CommandManager CommandManager { get; init; }
        public Configuration Configuration { get; init; }

        // 实体类
        public PartyList PartyList { get; init; }

        // 窗体
        public WindowSystem WindowSystem = new("别查我 Logs, 哥!");
        public MainWindow MainWindow { get; init; }
        public ConfigWindow ConfigWindow { get; init; }

        /// <summary>
        /// 插件入口
        /// </summary>
        /// <param name="pluginInterface"></param>
        /// <param name="commandManager"></param>
        /// <param name="partyList"></param>
        /// <param name="gameNetwork"></param>
        public EasyDalamud(
            [RequiredVersion("1.0")] DalamudPluginInterface pluginInterface,
            [RequiredVersion("1.0")] CommandManager commandManager,
            [RequiredVersion("1.0")] PartyList partyList)
        {
            // 插件核心
            instance = this;
            this.PluginInterface = pluginInterface;
            this.CommandManager = commandManager;
            this.Configuration = this.PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
            this.Configuration.Initialize(this.PluginInterface);

            // 实体类
            this.PartyList = partyList;

            // 窗体
            MainWindow = new MainWindow(this);
            ConfigWindow = new ConfigWindow(this);
            WindowSystem.AddWindow(MainWindow);
            WindowSystem.AddWindow(ConfigWindow);
            this.PluginInterface.UiBuilder.Draw += DrawAllWindows;
            this.PluginInterface.UiBuilder.OpenConfigUi += DrawConfigWIndow;
            this.CommandManager.AddHandler(CommandEd, new CommandInfo(OnCommandEd)
            {
                HelpMessage = "A useful message to display in /xlhelp"
            });
            this.CommandManager.AddHandler(CommandEnet, new CommandInfo(OnCommandEnet)
            {
                HelpMessage = "A useful message to display in /xlhelp"
            });
        }

        /// <summary>
        /// 插件卸载
        /// </summary>
        public void Dispose()
        {
            this.WindowSystem.RemoveAllWindows();
            MainWindow.Dispose();
            ConfigWindow.Dispose();
            this.CommandManager.RemoveHandler(CommandEd);
            this.CommandManager.RemoveHandler(CommandEnet);
        }

        /// <summary>
        /// 指令 ed
        /// </summary>
        /// <param name="command">指令</param>
        /// <param name="args">参数</param>
        private void OnCommandEd(string command, string args)
        {
            MainWindow.IsOpen = true;
        }

        /// <summary>
        /// 指令 enet
        /// </summary>
        /// <param name="command">指令</param>
        /// <param name="args">参数</param>
        private void OnCommandEnet(string command, string args)
        {
            MainWindow.IsOpen = true;
        }

        private void DrawAllWindows()
        {
            WindowSystem.Draw();
        }

        public void DrawConfigWIndow()
        {
            ConfigWindow.IsOpen = true;
        }
    }
}
