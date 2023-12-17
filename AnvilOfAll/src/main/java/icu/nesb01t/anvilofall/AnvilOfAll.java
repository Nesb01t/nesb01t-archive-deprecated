package icu.nesb01t.anvilofall;

import icu.nesb01t.anvilofall.api.AnvilPool;
import icu.nesb01t.anvilofall.cmds.GiveItemsCmd;
import icu.nesb01t.anvilofall.events.AnvilClickEvent;
import icu.nesb01t.anvilofall.events.AnvilOpenEvent;
import org.bukkit.plugin.java.JavaPlugin;

public final class AnvilOfAll extends JavaPlugin {

    public static AnvilOfAll plugin;

    @Override
    public void onEnable() {
        plugin = this;
        getLogger().info("AnvilOfAll has been enabled!");

        // event
        getServer().getPluginManager().registerEvents(new AnvilClickEvent(), this);
        getServer().getPluginManager().registerEvents(new AnvilOpenEvent(), this);

        // command
        getCommand("giveitems").setExecutor(new GiveItemsCmd());

        // task
        AnvilPool.createPool();
    }

    @Override
    public void onDisable() {
        getLogger().info("AnvilOfAll has been disabled!");
    }
}
