﻿using System;
using System.Linq;
using ChickenAPI.Core.ECS.Entities;
using ChickenAPI.Enums.Game.Entity;
using ChickenAPI.Game.Entities.Extensions;
using ChickenAPI.Game.Entities.Monster;
using ChickenAPI.Game.Entities.Player;
using ChickenAPI.Packets.Game.Client._NotYetSorted;

namespace NosSharp.PacketHandler
{
    public class NcifPacketHandling
    {
        public static void OnNcifPacket(NcifPacket packetBase, IPlayerEntity player)
        {
            try
            {
                IEntity entity;
                switch (packetBase.Type)
                {
                    case VisualType.Character:
                        break;
                    case VisualType.Npc:
                        entity = player.EntityManager.GetEntitiesByType<IEntity>(EntityType.Npc).FirstOrDefault(s => s.GetComponent<NpcMonsterComponent>().MapNpcMonsterId == packetBase.TargetId);
                        if (entity == null)
                        {
                            return;
                        }

                        player.SendPacket(entity.GenerateStPacket());
                        break;
                    case VisualType.Monster:
                        entity = player.EntityManager.GetEntitiesByType<IEntity>(EntityType.Monster).FirstOrDefault(s => s.GetComponent<NpcMonsterComponent>().MapNpcMonsterId == packetBase.TargetId);
                        if (entity == null)
                        {
                            return;
                        }

                        player.SendPacket(entity.GenerateStPacket());
                        break;
                    default:
                        return;
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}