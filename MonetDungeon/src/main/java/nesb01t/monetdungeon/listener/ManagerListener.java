package nesb01t.monetdungeon.listener;

import org.bukkit.Material;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.inventory.InventoryClickEvent;
import org.bukkit.inventory.ItemStack;
import org.bukkit.inventory.meta.ItemMeta;

import java.util.List;

public class ManagerListener implements Listener {
    @EventHandler
    public void clickLocItem(InventoryClickEvent event) {
        ItemStack itemStack = event.getCurrentItem();

        // 点击物品是否有效
        if (itemStack == null) return;
        if (itemStack.getType() == Material.AIR) return;

        // 名字为Teleport Here，则取消事件
        if (!itemStack.hasItemMeta()) return;
        ItemMeta meta = itemStack.getItemMeta();
        if (!meta.hasDisplayName()) return;
        if (!meta.getDisplayName().equals("Teleport Here")) return;
        event.setCancelled(true);

        // teleport To clickedLocation
        Player player = (Player) event.getWhoClicked();
        List<String> lore = meta.getLore();
        String X = lore.get(1);
        String Y = lore.get(2);
        String Z = lore.get(3);
        player.sendMessage(X + Y + Z);
    }
}
