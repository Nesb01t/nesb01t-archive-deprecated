using System;
using System.Collections.Generic;
using System.Threading;
using LumosBringers.Constants;
using LumosBringers.Service;
using static LumosBringers.Lib.MemoryHelper;
using Object = LumosBringers.Models.Object;

namespace LumosBringers.Lib;

public class ObjectHolder
{
    public ulong PlayerGuid = 0; // 玩家 Guid
    public IntPtr PlayerBase = IntPtr.Zero; // 玩家基址
    public Object PlayerObject = new();
    public List<Object> Objects = new List<Object>();

    public IntPtr hProcess { get; set; }

    private Thread _thread;

    public ObjectHolder(IntPtr hProcess)
    {
        this.hProcess = hProcess;

        _thread = new Thread(UpdateObjectInfo);
        _thread.IsBackground = true;
        _thread.Start();
    }

    /// <summary>
    /// 线程或直接调用, 更新用户信息
    /// </summary>
    public void UpdateObjectInfo()
    {
        while (true)
        {
            GetObjects();
            // PlayerSpyService.ModifySpeed(12.0f);
            Thread.Sleep(Core.UpdateIntervalObject);
        }
    }

    /// <summary>
    /// 查询池中的 PlayerObject
    /// </summary>
    /// <returns></returns>
    public Object GetPlayerObject()
    {
        // foreach (var obj in Objects)
        // {
        //     if (obj.Guid == PlayerGuid) return obj;
        // }
        //
        // return new();
        return PlayerObject;
    }

    /// <summary>
    /// 通过 hProcess 遍历对象
    /// </summary>
    /// <returns></returns>
    public void GetObjects()
    {
        // init
        PlayerGuid = (ulong)ReadMem64(hProcess, Offsets.Base + Offsets.PlayerGuid);
        PlayerBase = IntPtr.Zero;
        Objects = new List<Object>();

        // 读取第一个对象
        IntPtr mgrCurr = ReadMemPtr(hProcess, Offsets.Base + Offsets.ObjMgrCurr);
        IntPtr objFirst = ReadMemPtr(hProcess, mgrCurr + Offsets.ObjMgrOff);

        IntPtr baseAddr = objFirst;
        Object objCur = null;

        // 测试
        while (baseAddr != IntPtr.Zero && baseAddr.ToInt64() % 2 == 0)
        {
            Object objNew = new Object();
            objNew.Prev = objCur;

            objCur = objNew;
            objCur.BaseAddr = baseAddr;
            objCur.Guid = (ulong)ReadMem64(hProcess, objCur.BaseAddr + Offsets.ObjGuid);
            objCur.Type = (ushort)ReadMem16(hProcess, objCur.BaseAddr + Offsets.ObjType);

            switch ((Enums.ObjectType)objCur.Type)
            {
                case Enums.ObjectType.Unit: // 单位
                    break;

                case Enums.ObjectType.Player: // 玩家
                    // base
                    objCur.Level =
                        (uint)ReadMem64(hProcess, objCur.UnitfieldsAddr + Offsets.UnitLevel);
                    objCur.PosX =
                        ReadMemFloat(hProcess, objCur.BaseAddr + Offsets.ObjPosX);
                    objCur.PosY =
                        ReadMemFloat(hProcess, objCur.BaseAddr + Offsets.ObjPosY);
                    objCur.PosZ =
                        ReadMemFloat(hProcess, objCur.BaseAddr + Offsets.ObjPosZ);
                    objCur.Rotation =
                        ReadMemFloat(hProcess, objCur.BaseAddr + Offsets.ObjRotation);
                    objCur.MovementFlags =
                        (uint)ReadMem64(hProcess, objCur.BaseAddr + Offsets.ObjMovementFlags);
                    objCur.Speed =
                        (uint)ReadMemFloat(hProcess, objCur.BaseAddr + Offsets.ObjSpeed);

                    // unit
                    objCur.UnitfieldsAddr = ReadMemPtr(hProcess, objCur.BaseAddr + Offsets.ObjDataPtr);
                    objCur.HpCurr = (uint)ReadMem32(hProcess, objCur.UnitfieldsAddr + Offsets.UnitHpCurr);
                    objCur.HpMax = (uint)ReadMem32(hProcess, objCur.UnitfieldsAddr + Offsets.UnitHpMax);
                    objCur.ManaCurr = (uint)ReadMem32(hProcess, objCur.UnitfieldsAddr + Offsets.UnitManaCurr);
                    objCur.ManaMax = (uint)ReadMem32(hProcess, objCur.UnitfieldsAddr + Offsets.UnitManaMax);
                    objCur.SummonedBy = (ulong)ReadMem64(hProcess, objCur.UnitfieldsAddr + Offsets.UnitSummonedBy);
                    objCur.TargetGuid = (ulong)ReadMem64(hProcess, objCur.UnitfieldsAddr + Offsets.TargetGuid);

                    switch ((Enums.ObjectType)objCur.Type)
                    {
                        case Enums.ObjectType.Unit: // 单位
                            IntPtr u1 = ReadMem32(hProcess, objCur.BaseAddr + Offsets.UnitNameUnitName1);
                            objCur.Name = ReadMemStr(hProcess, u1, 50);
                            break;
                        case Enums.ObjectType.Player: // 玩家
                            IntPtr p1 = ReadMem32(hProcess, objCur.BaseAddr + Offsets.UnitNameObjName1);
                            objCur.Name = ReadMemStr(hProcess, p1, 50);
                            if (PlayerGuid == objCur.Guid)
                            {
                                PlayerBase = objCur.BaseAddr;
                                PlayerObject = objCur;
                            }

                            break;
                    }

                    break;

                case Enums.ObjectType.GameObj: // 游戏对象
                    objCur.PosX = ReadMemFloat(hProcess, objCur.BaseAddr + Offsets.GameObjectPosX);
                    objCur.PosY = ReadMemFloat(hProcess, objCur.BaseAddr + Offsets.GameObjectPosY);
                    objCur.PosZ = ReadMemFloat(hProcess, objCur.BaseAddr + Offsets.GameObjectPosZ);
                    objCur.UnitfieldsAddr = ReadMemPtr(hProcess, objCur.BaseAddr + Offsets.ObjDataPtr);

                    IntPtr n1 = ReadMem32(hProcess, objCur.BaseAddr + Offsets.UnitNameObjName1);
                    IntPtr n2 = n1 + Offsets.UnitNameObjName2;
                    objCur.Name = ReadMemStr(hProcess, n2, 50);
                    objCur.Type = (ushort)ReadMem32(hProcess, objCur.BaseAddr + Offsets.UnitNameItemType);
                    break;
            }

            Objects.Add(objCur);
            // get next obj ptr
            baseAddr = ReadMemPtr(hProcess, objCur.BaseAddr + Offsets.ObjMgrNext);
        }
    }
}