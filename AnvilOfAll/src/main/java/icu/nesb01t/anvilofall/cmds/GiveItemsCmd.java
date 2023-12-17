package icu.nesb01t.anvilofall.cmds;

import org.bukkit.ChatColor;
import org.bukkit.Material;
import org.bukkit.command.Command;
import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;
import org.bukkit.inventory.ItemStack;
import org.bukkit.inventory.meta.ItemMeta;

import java.util.ArrayList;
import java.util.List;

public class GiveItemsCmd implements CommandExecutor {
    @Override
    public boolean onCommand(CommandSender sender, Command cmd, String label, String[] args) {
        if (cmd.getName().equalsIgnoreCase("giveitems")) {
            if (sender instanceof Player) {
                Player player = (Player) sender;
                ItemStack sword = new ItemStack(Material.WOODEN_SWORD, 1);
                sword.setDurability((short) (sword.getType().getMaxDurability() / 2));
                player.getInventory().addItem(sword);
                giveRedstoneWithLore(player);
                return true;
            } else {
                sender.sendMessage("Only players can use this command.");
                return false;
            }
        }
        return false;
    }

    public void giveRedstoneWithLore(Player player) {
        ItemStack redstone = new ItemStack(Material.REDSTONE, 32);
        ItemMeta meta = redstone.getItemMeta();
        meta.setDisplayName(ChatColor.DARK_RED + "Redstone");
        List<String> lore = new ArrayList<String>();
        lore.add(ChatColor.DARK_AQUA + "万用材料");
        meta.setLore(lore);
        redstone.setItemMeta(meta);
        player.getInventory().addItem(redstone);
    }

}
