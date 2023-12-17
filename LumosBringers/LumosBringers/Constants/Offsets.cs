using System;

namespace LumosBringers.Constants;

public class Offsets
{
    public static readonly IntPtr Base = 0x400000; // 基地址

    public static readonly IntPtr PlayerGuid = 0x741E30; // 玩家的全局唯一标识符地址
    public static readonly IntPtr TargetGuid = 0x74E2d8; // 目标的全局唯一标识符地址
    public static readonly IntPtr IsInGame = 0xB4B424; // 游戏是否处于运行状态的地址
    public static readonly IntPtr LastHardwareAction = 0xCF0BC8; // 最后一次硬件操作的时间戳地址

    public static readonly IntPtr ObjMgrCurr = 0x00741414; // 当前对象管理器地址
    public static readonly IntPtr ObjMgrOff = 0xAC; // 对象管理器偏移量
    public static readonly IntPtr ObjMgrNext = 0x3C; // 下一个对象管理器地址的偏移量
    public static readonly IntPtr ObjMgrFirst = 0xAC; // 第一个对象管理器地址的偏移量
    public static readonly IntPtr ObjMgrLocalGuid = 0xC0; // 本地对象管理器的全局唯一标识符地址

    public static readonly IntPtr ObjDataPtr = 0x8; // WoW对象数据指针地址的偏移量
    public static readonly IntPtr ObjType = 0x14; // WoW对象类型地址的偏移量
    public static readonly IntPtr ObjGuid = 0x30; // WoW对象全局唯X一标识符地址的偏移量
    public static readonly IntPtr ObjPosX = 0x9B8; // WoW对象纵坐标地址的偏移量
    public static readonly IntPtr ObjPosY = ObjPosX + 0x4; // WoW对象横坐标地址的偏移量
    public static readonly IntPtr ObjPosZ = ObjPosX + 0x8; // WoW对象高度坐标地址的偏移量
    public static readonly IntPtr ObjRotation = ObjPosY + 0x10; // WoW对象旋转角度地址的偏移量

    public static readonly IntPtr ObjMovementFlags = 0x9E8; // WoW对象移动标志地址

    // public static readonly IntPtr ObjSpeed = 0xA34; // OLD -> WoW对象速度地址
    public static readonly IntPtr ObjSpeed = 0xA2C; // WoW对象速度地址
    public static readonly IntPtr ObjSpeedModifierRun = 0xA34; // WoW对象速度地址

    public static readonly IntPtr GameObjectPosY = 0x2C4; // WoW游戏对象纵坐标地址的偏移量
    public static readonly IntPtr GameObjectPosX = GameObjectPosY + 0x4; // WoW游戏对象横坐标地址的偏移量
    public static readonly IntPtr GameObjectPosZ = GameObjectPosY + 0x8; // WoW游戏对象高度坐标地址的偏移量

    public static readonly IntPtr UnitCharm = 0x18; // WoW单位被控制的标志地址的偏移量
    public static readonly IntPtr UnitSummon = 0x20; // WoW单位召唤物的标志地址的偏移量
    public static readonly IntPtr UnitCharmedBy = 0x28; // WoW单位控制该单位的单位的全局唯一标识符地址的偏移量
    public static readonly IntPtr UnitSummonedBy = 0x30; // WoW单位召唤该单位的单位的全局唯一标识符地址的偏移量
    public static readonly IntPtr UnitCreatedBy = 0x38; // WoW单位创建该单位的单位的全局唯一标识符地址的偏移量
    public static readonly IntPtr UnitTarget = 0x40; // WoW单位当前目标的全局唯一标识符地址的偏移量
    public static readonly IntPtr UnitChannelObject = 0x50; // WoW单位引导法术的对象的全局唯一标识符地址的偏移量
    public static readonly IntPtr UnitHpCurr = 0x58; // WoW单位当前生命值地址的偏移量
    public static readonly IntPtr UnitManaCurr = 0x5C; // WoW单位当前法力值地址的偏移量
    public static readonly IntPtr UnitHpMax = 0x70; // WoW单位最大生命值地址的偏移量
    public static readonly IntPtr UnitManaMax = 0x74; // WoW单位最大法力值地址的偏移量
    public static readonly IntPtr UnitLevel = 0x88; // WoW单位等级地址

    public static readonly IntPtr UnitNameObjName1 = 0x214; // WoW单位名称的第一个部分（对象名称）地址的偏移量
    public static readonly IntPtr UnitNameObjName2 = 0x8; // WoW单位名称的第二个部分（对象名称）地址的偏移量
    public static readonly IntPtr UnitNameItemType = 0x2DC; // WoW单位名称的物品类型地址的偏移量
    public static readonly IntPtr UnitNameUnitName1 = 0xB30; // WoW单位名称的第一个部分（单位名称）地址的偏移量
}