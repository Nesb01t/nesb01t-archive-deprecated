package org.mocommon.command.sub;

import org.bukkit.entity.Player;
import org.mocommon.command.PlayerCommand;

public class HealthCommand extends PlayerCommand {
    public static String commandName = "hp";

    public HealthCommand() {
        super(commandName);
    }

    @Override
    public void Run(Player player, String[] args) {
        if (args[0] != null) {
            player.setMaxHealth(Double.parseDouble(args[0]));
        }
        player.setHealth(player.getMaxHealth());
    }
}
