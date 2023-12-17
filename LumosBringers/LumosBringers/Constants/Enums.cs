namespace LumosBringers.Constants;

public class Enums
{
    public enum ObjectType
    {
        None = 0, // 无类型
        Item = 1, // 物品类型
        Container = 2, // 容器类型
        Unit = 3, // 单位类型
        Player = 4, // 玩家类型
        GameObj = 5, // 游戏对象类型
        DynObj = 6, // 动态对象类型
        Corpse = 7, // 尸体类型
        ForcedWord = 0xFFFFFFF // 强制转换为无符号双字类型
    }

    public enum ObjectMovement
    {
        None = 0x00000000, // 无移动状态
        Forward = 0x00000001, // 向前移动
        Back = 0x00000002, // 向后移动
        TurnLeft = 0x00000010, // 向左转向
        TurnRight = 0x00000020, // 向右转向
        Stunned = 0x00001000, // 昏迷状态
        Swimming = 0x00200000 // 游泳状态
    }
}