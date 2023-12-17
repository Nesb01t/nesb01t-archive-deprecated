package icu.nesb01t.anvilofall.api;

import org.bukkit.Material;
import org.bukkit.inventory.ItemStack;

import java.util.Arrays;
import java.util.List;

public class CommonMaterial {
    /**
     * 根据类型设置修复物品
     */
    public static Material getMaterialByTypeName(String name) {
        Material material = Material.REDSTONE;
        switch (name) {
            case "WOODEN":
                material = Material.OAK_PLANKS;
                break;
            case "STONE":
                material = Material.STONE;
                break;
            case "GOLDEN":
                material = Material.GOLD_INGOT;
                break;
            case "IRON":
                material = Material.IRON_INGOT;
                break;
            case "DIAMOND":
                material = Material.DIAMOND;
                break;
        }
        return material;
    }

    /**
     * 改变物品的 CommonMaterial 类型
     */
//    public
}
