package icu.nesb01t.anvilofall.events;

import icu.nesb01t.anvilofall.api.Anvil;
import icu.nesb01t.anvilofall.api.CommonMaterial;
import org.bukkit.Material;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.inventory.InventoryClickEvent;
import org.bukkit.event.inventory.InventoryType;
import org.bukkit.inventory.Inventory;
import org.bukkit.inventory.ItemStack;

import java.util.Objects;

public class AnvilClickEvent implements Listener {
    /**
     * 铁砧界面点击事件
     */
    @EventHandler
    public void onAnvilClick(InventoryClickEvent event) {
        if (event.getInventory().getType() == InventoryType.ANVIL) {

        }
    }
}