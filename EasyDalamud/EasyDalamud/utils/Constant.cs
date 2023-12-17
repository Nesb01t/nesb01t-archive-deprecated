using System.Collections.Generic;

namespace EasyDalamud.utils;

public static class Constant
{
    public static Dictionary<ushort, string> OpCodeDict = new Dictionary<ushort, string>
    {
        { 0x038E, "ActorMove" },
        { 0x02A5, "ActorControl" },
        { 0x01A3, "ActorControlSelf" },
        { 0x02D0, "ActorControlTarget" },
        { 0x0247, "UpdateHpMpTp" },
        { 0x0325, "ClientTrigger" },
        { 0x0315, "UpdatePositionHandler" },
        { 0x00C8, "PlayerSpawn" },
        { 0x0303, "CFPreferredRole" },

        { 0x02F0, "Unknown" },
        { 0x012A, "Unknown" },
        { 0x00A7, "Unknown" },
        
        {0x00F5, "推测是打开界面"},
        // {0x01C1, "推测是金蝶币相关"},
        
        // 点击NPC, 弹出选择界面
        // 0258, 00DE, 0286, 03CE
        
        // 点击开始游戏
        // 00F5, 01C1, 038C, 03E5
        
        // 在游戏中
        // 00F5, 0328
        
        // 游戏结算
        // 02B1, 0286, 008B, 01C1, 03E5
    };
}
