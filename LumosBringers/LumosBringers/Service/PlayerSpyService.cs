using System;
using System.Threading;
using LumosBringers.Constants;
using LumosBringers.Lib;
using LumosBringers.Models;

namespace LumosBringers.Service;

public class PlayerSpyService
{
    public static void Teleport(Telepoint telepoint)
    {
        var p = Core.ObjectHolder.GetPlayerObject();
        if (p.Name == "") return;
        var playerAddr = p.BaseAddr;

        var process = Core.ProcessHolder.hProcess;

        MemoryHelper.WriteMemFloat(process, playerAddr + Offsets.ObjPosX, telepoint.PosX);
        MemoryHelper.WriteMemFloat(process, playerAddr + Offsets.ObjPosY, telepoint.PosY);
        MemoryHelper.WriteMemFloat(process, playerAddr + Offsets.ObjPosZ, telepoint.PosZ);
    }

    public static void ModifySpeed(float speed)
    {
        var p = Core.ObjectHolder.GetPlayerObject();
        if (p.HpMax == 0) return;
        var pAddr = p.BaseAddr;

        // 速度检测
        if (p.Speed == 0) return;
        var process = Core.ProcessHolder.hProcess;

        MemoryHelper.WriteMemFloat(process, pAddr + Offsets.ObjSpeed, speed);
    }

    public static void ModifyNoFalling()
    {
        var p = Core.ObjectHolder.GetPlayerObject();
        if (p.HpMax == 0) return;
        var pAddr = p.BaseAddr;

        // 状态检测
        if (p.MovementFlags == 0) return;
        var process = Core.ProcessHolder.hProcess;
        uint newFlag = p.MovementFlags % 8192;

        MemoryHelper.WriteMem32(process, pAddr + Offsets.ObjMovementFlags, (int)newFlag);
    }

    public static void DangerTryGetLevel()
    {
        foreach (var p in Core.TeleListHolder.points)
        {
            Teleport(p);
            Thread.Sleep(200);
        }
    }
}