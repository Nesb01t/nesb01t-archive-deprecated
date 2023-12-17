package icu.nesb01t.anvilofall.api;

import org.bukkit.entity.Player;
import org.bukkit.event.inventory.InventoryType;
import org.bukkit.scheduler.BukkitRunnable;
import org.bukkit.scheduler.BukkitTask;

import java.util.ArrayList;
import java.util.List;

import static icu.nesb01t.anvilofall.AnvilOfAll.plugin;

public class AnvilPool {
    private static final List<Player> fixingPlayerList = new ArrayList<Player>();

    /**
     * 生成池
     */
    public static void createPool() {
        new BukkitRunnable() {
            @Override
            public void run() {
                clearPoolPeriod();
                for (Player player : fixingPlayerList) {
                    player.sendMessage("RUNNING");
                }
            }
        }.runTaskTimer(plugin, 0L, 3L);
    }

    /**
     * 检查玩家是否在浏览铁砧
     *
     * @param player 玩家
     * @return 是否在浏览铁砧
     */
    public static boolean checkFixingPlayer(Player player) {
        InventoryType invType = player.getOpenInventory().getType();
        if (invType == InventoryType.ANVIL) {
            return true;
        } else {
            return false;
        }
    }

    /**
     * 根据是否浏览铁砧，清理池中的无效玩家
     */
    public static void clearPoolPeriod() {
        for (Player player : fixingPlayerList) {
            if (!checkFixingPlayer(player)) {
                removeFixingPlayer(player);
            }
        }
    }

    // 获取玩家列表
    public static List<Player> getPool() {
        return fixingPlayerList;
    }

    // 加入池
    public static void addFixingPlayer(Player player) {
        fixingPlayerList.add(player);
    }

    // 从池移除
    public static void removeFixingPlayer(Player player) {
        fixingPlayerList.remove(player);
    }
}
