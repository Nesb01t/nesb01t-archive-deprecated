package org.mocommon.command.sub;

import org.bukkit.entity.Player;
import org.mocommon.command.PlayerCommand;

public class GameModeCommand extends PlayerCommand {
    public static String commandName = "gm";

    public GameModeCommand() {
        super(commandName);
    }

    @Override
    public void Run(Player player, String[] args) {
        player.setGameMode(player.getPreviousGameMode());
    }
}
