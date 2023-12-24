package org.mocommon;

import org.bukkit.plugin.java.JavaPlugin;
import org.mocommon.command.PlayerCommand;
import org.mocommon.command.sub.ClearCommand;
import org.mocommon.command.sub.GameModeCommand;
import org.mocommon.command.sub.HealthCommand;
import org.mocommon.command.sub.ReloadCommand;

public final class MoCommon extends JavaPlugin {

    public static MoCommon Core;

    @Override
    public void onEnable() {
        Core = this;
        regCommand(new ClearCommand());
        regCommand(new GameModeCommand());
        regCommand(new HealthCommand());
        regCommand(new ReloadCommand());
    }

    @Override
    public void onDisable() {
    }

    public void regCommand(PlayerCommand command) {
        getCommand(command.commandName).setExecutor(command);
    }
}
