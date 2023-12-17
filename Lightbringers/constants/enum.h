enum ObjectType
{
    O_T_NONE = 0,               // 无类型
    O_T_ITEM = 1,               // 物品类型
    O_T_CONTAINER = 2,          // 容器类型
    O_T_UNIT = 3,               // 单位类型
    O_T_PLAYER = 4,             // 玩家类型
    O_T_GAMEOBJ = 5,            // 游戏对象类型
    O_T_DYNOBJ = 6,             // 动态对象类型
    O_T_CORPSE = 7,             // 尸体类型
    O_T_FORCEDWORD = 0xFFFFFFFF // 强制转换为无符号双字类型
};

enum ObjectMovement
{
    O_M_None = 0x00000000,      // 无移动状态
    O_M_Forward = 0x00000001,   // 向前移动
    O_M_Back = 0x00000002,      // 向后移动
    O_M_TurnLeft = 0x00000010,  // 向左转向
    O_M_TurnRight = 0x00000020, // 向右转向
    O_M_Stunned = 0x00001000,   // 昏迷状态
    O_M_Swimming = 0x00200000   // 游泳状态
};
