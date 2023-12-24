package org.mocommon.command.sub;

import org.bukkit.Bukkit;
import org.bukkit.command.ConsoleCommandSender;
import org.bukkit.entity.Player;
import org.mocommon.command.PlayerCommand;

public class ClearCommand extends PlayerCommand {

    public static String commandName = "c";

    public ClearCommand() {
        super(commandName);
    }

    @Override
    public void Run(Player player, String[] args) {
        player.sendMessage("清空了 " + player.getName() + " 的背包");
        player.getInventory().clear();
    }
}
