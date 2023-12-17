package nesb01t.monetdungeon.com;

import nesb01t.monetdungeon.MonetDungeon;
import nesb01t.monetdungeon.api.LocFileParser;
import org.bukkit.command.Command;
import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;

import java.io.IOException;


public class LocationCom implements CommandExecutor {
    @Override
    public boolean onCommand(CommandSender sender, Command command, String label, String[] args) {
        if (!(sender instanceof Player)) { // 禁止控制台
            MonetDungeon.plugin.getLogger().info("Error! wrong command used in console.");
            return true;
        }

        if (args.length == 0) { // 参数长度 = 0
            sender.sendMessage("Error! you did not provide any arguments.");
            return true;
        }

        sender.sendMessage(String.valueOf(args.length));

        switch (args[0]) {
            case "save":
                /**
                 * 参数依次为:
                 *  区块 -> 0~N
                 *  层级 -> 1~3
                 *  名字 -> Name
                 */
                if (args.length < 4) {
                    sender.sendMessage("Error! usage /md save blockX level Name.");
                } else if (args.length == 4) {
                    try {
                        sender.sendMessage("正在尝试存储坐标...");
                        LocFileParser.saveLocation(((Player) sender).getLocation(), args[1], args[2], args[3]);
                    } catch (IOException e) {
                        throw new RuntimeException(e);
                    }
                }
                break;
            default:
                sender.sendMessage("Error! your argument makes no effect.");
                break;
        }
        return false;
    }
}
