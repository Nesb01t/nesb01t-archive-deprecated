package nesb01t.monetdungeon.listener;

import nesb01t.monetdungeon.api.LocFileParser;
import org.bukkit.Material;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.inventory.InventoryClickEvent;
import org.bukkit.inventory.ItemStack;
import org.bukkit.inventory.meta.ItemMeta;

import java.io.IOException;

public class PanelListener implements Listener {
    private static final int startLevel = 1;
    private static final int itemStartIndex = 10;
    @EventHandler
    public void clickTeleItem(InventoryClickEvent event) throws IOException {
        ItemStack itemStack = event.getCurrentItem();

        // 点击物品是否有效
        if (itemStack == null) return;
        if (itemStack.getType() == Material.AIR) return;

        // 名字中包含 TeleItem，则取消事件
        if (!itemStack.hasItemMeta()) return;
        ItemMeta meta = itemStack.getItemMeta();
        if (!meta.hasDisplayName()) return;
        if (!meta.getDisplayName().contains("TeleItem")) return;
        event.setCancelled(true);

        // 传送玩家到选择副本
        Player player = (Player) event.getWhoClicked();
        String blockIndex = String.valueOf(event.getSlot() - itemStartIndex + 2);
        player.sendMessage(String.valueOf(blockIndex));
        player.teleport(LocFileParser.getRandomLocation(blockIndex, String.valueOf(startLevel)).getLocation());
    }
}
