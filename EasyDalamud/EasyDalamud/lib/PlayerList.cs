using System.Collections.Generic;
using Dalamud.Game.ClientState.Party;
using EasyDalamud.lib;

namespace EasyDalamud.utils;

public static class PlayerList
{
    public static List<PartyMember> GetPartyMembers(PartyList partyList)
    {
        List<PartyMember> partyMembers = new List<PartyMember>();
        int partyMemberAmount = partyList.Length; // 队伍长度
        for (int i = 0; i < partyMemberAmount; i++)
        {
            nint partyMemberAddress = partyList.GetPartyMemberAddress(i);
            PartyMember? partyMember = partyList.CreatePartyMemberReference(partyMemberAddress);
            partyMembers.Add(partyMember);
        }

        return partyMembers;
    }

    public static List<Player> GetPlayerList(PartyList partyList)
    {
        List<Player> players = new List<Player>();
        List<PartyMember> partyMembers = PlayerList.GetPartyMembers(partyList);
        foreach (var i in partyMembers)
        {
            string name = i.Name.ToString();
            string server = i.World.GameData.Name;
            players.Add(new Player(name, server));
        }

        return players;
    }
}
