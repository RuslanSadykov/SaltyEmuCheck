﻿using System.Collections.Generic;
using System.Linq;
using ChickenAPI.Core.ECS.Entities;
using ChickenAPI.Enums.Game.Entity;
using ChickenAPI.Game.Entities.Npc;
using ChickenAPI.Game.Entities.Player;
using ChickenAPI.Game.Features.Shops;
using ChickenAPI.Game.Features.Shops.Args;
using ChickenAPI.Packets.Game.Client.Shops;

namespace NosSharp.PacketHandler.Shops
{
    public class NpcReqPacketHandling
    {
        public static void OnShoppingPacketReceived(ReceivedNpcReqPacket packet, IPlayerEntity player)
        {
            IEnumerable<INpcEntity> npcs = player.EntityManager.GetEntitiesByType<INpcEntity>(EntityType.Npc);

            INpcEntity npc = npcs.FirstOrDefault(s => s.MapNpc.Id == packet.VisualId);
            if (npc == null || !(npc is NpcEntity npcEntity))
            {
                return;
            }

            player.SendPacket(new SentNpcReqPacket()
            {
                VisualType = VisualType.Npc,
                VisualId = npc.MapNpc.Id,
                Dialog = npc.MapNpc.Dialog,
            });
        }

        public static void BuyPcket(BuyPacket packet, IPlayerEntity player)
        {
            player.NotifyEventHandler<ShopEventHandler>(new BuyShopEventArgs
            {
                Amount = packet.Amount,
                OwnerId = packet.OwnerId,
                Slot = packet.Slot,
                Type = packet.Type
            });
        }
    }
}