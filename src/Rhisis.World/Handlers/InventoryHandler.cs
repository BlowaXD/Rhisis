﻿using Ether.Network.Packets;
using Rhisis.Core.Network;
using Rhisis.Core.Network.Packets;
using Rhisis.Core.Network.Packets.World;
using Rhisis.World.Systems;
using Rhisis.World.Systems.Events.Inventory;

namespace Rhisis.World.Handlers
{
    public static class InventoryHandler
    {
        [PacketHandler(PacketType.MOVEITEM)]
        public static void OnMoveItem(WorldClient client, NetPacketBase packet)
        {
            var moveItemPacket = new MoveItemPacket(packet);
            var inventoryEvent = new InventoryEventArgs(InventoryActionType.MoveItem, moveItemPacket.SourceSlot, moveItemPacket.DestinationSlot);

            client.Player.Context.NotifySystem<InventorySystem>(client.Player, inventoryEvent);
        }

        [PacketHandler(PacketType.DOEQUIP)]
        public static void OnDoEquip(WorldClient client, NetPacketBase packet)
        {
            var equipItemPacket = new EquipItemPacket(packet);
            var inventoryEvent = new InventoryEventArgs(InventoryActionType.Equip, equipItemPacket.UniqueId, equipItemPacket.Part);

            client.Player.Context.NotifySystem<InventorySystem>(client.Player, inventoryEvent);
        }
    }
}
