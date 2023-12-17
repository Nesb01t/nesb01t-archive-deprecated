package icu.nesb01t.anvilofall.api;

import org.bukkit.event.inventory.InventoryType;
import org.bukkit.inventory.Inventory;
import org.bukkit.inventory.ItemStack;

import java.util.Arrays;
import java.util.List;

public class Anvil {
    /**
     * 判断需要修复的物品类型
     */
    static List<String> keyItems = Arrays.asList("WOODEN", "STONE", "GOLDEN", "IRON", "DIAMOND");
    public static String getFixItemType(Inventory inv) {
        if (inv.getType() == InventoryType.ANVIL) {
            ItemStack fixItem = inv.getItem(0);
            if (fixItem != null) {
                String name = fixItem.getType().name();
                for (String key : keyItems) {
                    if (name.contains(key)) {
                        return key;
                    }
                }
            }
        }
        return "NONE";
    }
}
