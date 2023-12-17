package nesb01t.monetdungeon.api;

import nesb01t.monetdungeon.utils.MathUtils;
import nesb01t.monetdungeon.utils.YamlUtils;
import org.bukkit.Location;
import org.bukkit.configuration.ConfigurationSection;
import org.bukkit.configuration.file.YamlConfiguration;

import java.io.IOException;
import java.util.Random;
import java.util.Set;

import static nesb01t.monetdungeon.utils.YamlUtils.saveYamlToFile;
import static nesb01t.monetdungeon.utils.YamlUtils.useYamlFile;

public class LocFileParser {
    /**
     * 获取坐标
     *
     * @param blockX 所在地图区块
     * @param level  层级
     */
    public static Location getLocation(String blockX, String level, String index) throws IOException {
        YamlConfiguration yaml = useYamlFile(String.valueOf(blockX)); // 读取 blockX -> 1.yml
        Location loc = (Location) yaml.getConfigurationSection("level" + level).get(index);
        ConfigurationSection section = yaml.getConfigurationSection("level" + level);
        return loc;
    }

    /**
     * 获取随机坐标
     *
     * @param blockX 所在地图区块
     * @param level  层级
     */
    public static DungeonNode getRandomLocation(String blockX, String level) throws IOException {
        YamlConfiguration yaml = useYamlFile(String.valueOf(blockX)); // 读取 blockX -> 1.yml
        ConfigurationSection section = yaml.getConfigurationSection("level" + level);

        // 获取随机位置
        Set<String> keys = section.getKeys(false);
        String[] keyArray = keys.toArray(new String[keys.size()]);
        int randIndex = MathUtils.getRandomBetween(0, YamlUtils.getListSize(blockX, level) - 1);
        String randKey = keyArray[randIndex];

        Location loc = (Location) yaml.getConfigurationSection("level" + level).get(randKey);
        return new DungeonNode(loc, randKey);
    }

    /**
     * 保存坐标
     *
     * @param location 位置
     * @param blockX   所在地图区块
     * @param level    层级
     */
    public static void saveLocation(Location location, String blockX, String level, String name) throws IOException {
        YamlConfiguration yaml = useYamlFile(blockX); // 区块 1.yml
        ConfigurationSection list;

        // 是否存在yaml，否则创建
        if (yaml.isConfigurationSection("level" + level)) {
            list = yaml.getConfigurationSection("level" + level);
        } else {
            list = yaml.createSection("level" + level);
        }

        int index = list.getKeys(false).size();
        list.set(name, location);

        saveYamlToFile(blockX, yaml);
    }
}
