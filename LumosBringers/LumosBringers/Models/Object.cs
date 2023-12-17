using System;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;

namespace LumosBringers.Models;

public class Object
{
    // base
    public ulong Guid; // 对象的唯一标识符
    public ulong SummonedBy; // 召唤该对象的对象的唯一标识符
    public float PosX; // 对象的 X 坐标
    public float PosY; // 对象的 Y 坐标
    public float PosZ; // 对象的 Z 坐标
    public float Rotation; // 对象的旋转角度
    public uint MovementFlags; // 对象的移动状态
    public uint Speed; // 对象的移动速度
    public IntPtr BaseAddr; // 对象的基址
    public IntPtr UnitfieldsAddr; // 对象的单位字段地址
    public ushort Type; // 对象的类型

    // unit
    public string Name; // 对象的名称
    public ulong TargetGuid; // 目标的 Guid
    public uint HpCurr; // 当前生命值
    public uint HpMax; // 最大生命值
    public uint ManaCurr; // 当前法力值
    public uint ManaMax; // 最大法力值
    public uint Level; // 对象的等级

    public uint ObjType; // 对象的类型
    public Object Prev; // 上一个对象的指针
    
    public override string ToString()
    {
        if (HpMax == 0) return "";
        return HpCurr + "/" + HpMax + " " + Level;
    }
}