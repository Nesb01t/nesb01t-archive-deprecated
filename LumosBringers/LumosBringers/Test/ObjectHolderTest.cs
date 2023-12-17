using LumosBringers.Constants;

namespace LumosBringers.Test;

public class ObjectHolderTest
{
    public static string Test()
    {
        string s = "[Debug] 正在开始 ObjectHolderTest\r";

        // guid & base
        s += "PlayerGUID: " + Core.ObjectHolder.PlayerGuid + "\r";
        s += "PlayerBase: " + Core.ObjectHolder.PlayerBase + "\r";

        // player info
        s += PlayerGeneStr();

        // player object address
        s += PlayerGeneAddress();

        // obj enum
        s += ObjectEnumInfoStr();

        return s;
    }

    public static string ObjectEnumInfoStr()
    {
        var s = "";
        var objects = Core.ObjectHolder.Objects;
        if (objects.Count == 0)
        {
            s += "未能初始化 ObjectHolder, 或许你未进入游戏 & 未使用管理员权限打开\r";
            return s;
        }

        foreach (var i in objects)
        {
            if (i.ToString() == "") continue;
            s += i + "\r";
        }

        return s;
    }

    public static string PlayerGeneStr()
    {
        var s = "";
        var player = Core.ObjectHolder.GetPlayerObject();
        if (player == null) return "未找到 Player, 或许你未进入游戏 & 未使用管理员权限打开\r";
        s += player.PosX + ", " + player.PosY + ", " + player.PosZ + "\r";
        return s;
    }

    public static string PlayerGeneAddress()
    {
        var s = "";
        var player = Core.ObjectHolder.GetPlayerObject();
        if (player == null) return "未找到 Player Address, 或许你未进入游戏 & 未使用管理员权限打开\r";
        s += "MovementFlags: " + (player.BaseAddr + Offsets.ObjMovementFlags) + '\r';
        return s;
    }
}