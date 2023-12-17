using Dalamud.Game.Command;
using Dalamud.Plugin;
using Dalamud.Interface.Windowing;
using XIVAutoKey.Windows;
using Dalamud.Game.ClientState;
using XIVAutoKey.Libs;

namespace XIVAutoKey
{
    public sealed class Plugin : IDalamudPlugin
    {
        public string Name => "XIVAutoKey";
        private const string CommandName = "/ak";

        private DalamudPluginInterface PluginInterface { get; init; }
        private CommandManager CommandManager { get; init; }
        public Configuration Configuration { get; init; }
        public WindowSystem WindowSystem = new("XIVAutoKey");
        public ClientState clientState { get; init; }

        private ControllerWindow ControllerWindow { get; init; }

        public Plugin(
            DalamudPluginInterface pluginInterface,
            CommandManager commandManager,
            ClientState clientState)
        {
            this.PluginInterface = pluginInterface;
            this.CommandManager = commandManager;

            this.Configuration = this.PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
            this.Configuration.Initialize(this.PluginInterface);

            this.clientState = clientState;

            ControllerWindow = new ControllerWindow(this);
            WindowSystem.AddWindow(ControllerWindow);

            this.CommandManager.AddHandler(CommandName, new CommandInfo(OnCommand)
            {
                HelpMessage = "在聊天框 & 宏中输入 /ak 打开主界面~"
            });

            this.PluginInterface.UiBuilder.Draw += DrawUI;
        }

        public void Dispose()
        {
            this.WindowSystem.RemoveAllWindows();

            ControllerWindow.Dispose();

            this.CommandManager.RemoveHandler(CommandName);
        }

        private void OnCommand(string command, string args)
        {
            ControllerWindow.IsOpen = !ControllerWindow.IsOpen;
        }

        private void DrawUI()
        {
            this.WindowSystem.Draw();
        }
    }
}
