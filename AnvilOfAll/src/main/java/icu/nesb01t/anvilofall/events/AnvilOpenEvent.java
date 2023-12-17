package icu.nesb01t.anvilofall.events;

import icu.nesb01t.anvilofall.api.AnvilPool;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.inventory.InventoryOpenEvent;
import org.bukkit.event.inventory.InventoryType;
import org.bukkit.inventory.Inventory;

public class AnvilOpenEvent implements Listener {
    @EventHandler
    public void onAnvilOpen(InventoryOpenEvent event) {
        // 打开的是铁砧
        if (event.getInventory().getType() == InventoryType.ANVIL) {
            Player player = (Player) event.getPlayer();
            player.sendMessage(player.getDisplayName());
            AnvilPool.addFixingPlayer(player);
        }
    }
}
