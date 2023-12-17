package nesb01t.monetdungeon.api;

import org.bukkit.Location;

public class DungeonNode {
    Location location;
    String name;

    DungeonNode(Location location, String name) {
        this.location = location;
        this.name = name;
    }

    public Location getLocation() {
        return location;
    }

    public String getName() {
        return name;
    }
}
