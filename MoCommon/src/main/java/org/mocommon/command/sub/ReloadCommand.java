package org.mocommon.command.sub;

import org.bukkit.Bukkit;
import org.bukkit.command.ConsoleCommandSender;
import org.bukkit.entity.Player;
import org.mocommon.command.PlayerCommand;

public class ReloadCommand extends PlayerCommand {
    public static String commandName = "r";

    public ReloadCommand() {
        super(commandName);
    }

    @Override
    public void Run(Player player, String[] args) {
        executeReloadConfirmCommand();
        player.sendMessage(player.getName() + " 执行了重启指令");
    }

    private void executeReloadConfirmCommand() {
        ConsoleCommandSender console = Bukkit.getServer().getConsoleSender();
        Bukkit.dispatchCommand(console, "reload confirm");
    }
}
