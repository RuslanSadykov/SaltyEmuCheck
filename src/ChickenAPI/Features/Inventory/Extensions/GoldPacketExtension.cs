﻿using ChickenAPI.Game.Entities.Player;
using ChickenAPI.Packets.Game.Server.Inventory;

namespace ChickenAPI.Game.Features.Inventory.Extensions
{
    public static class GoldPacketExtension
    {
        public static GoldPacket GenerateGoldPacket(this IPlayerEntity player)
        {
            return new GoldPacket
            {
                Gold = player.Character.Gold
            };
        }
    }
}