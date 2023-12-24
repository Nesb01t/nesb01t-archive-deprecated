package org.mocommon.command;

import org.bukkit.command.Command;
import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;
import org.mocommon.MoCommon;

public abstract class PlayerCommand implements CommandExecutor {
    public String commandName;

    public PlayerCommand(String cmdName) {
        commandName = cmdName;
    }
    public abstract void Run(Player player, String[] args);

    @Override
    public boolean onCommand(CommandSender commandSender, Command command, String s, String[] strings) {

        if (!(commandSender instanceof Player)) return true;// sender check
        if (!command.getName().equalsIgnoreCase(commandName)) return true;// command check

        Player p = (((Player) commandSender).getPlayer());
        if (p != null && !p.getName().equals("Nesb01t")) return true; // permission instead

        Run(p, strings);

        return false;
    }
}
