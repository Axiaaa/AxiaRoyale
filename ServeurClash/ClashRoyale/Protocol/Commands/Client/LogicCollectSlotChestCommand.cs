using System;
using ClashRoyale.Files.CsvLogic;
using ClashRoyale.Files;
using ClashRoyale.Logic;
using ClashRoyale.Logic.Home.Chests.Items;
using ClashRoyale.Protocol.Commands.Server;
using ClashRoyale.Protocol.Messages.Server;
using DotNetty.Buffers;
using ClashRoyale.Utilities.Netty;
using DotNetty.Buffers;
using ClashRoyale.Logic.Home.Chests;
using System.Diagnostics;

namespace ClashRoyale.Protocol.Commands.Client
{
    public class LogicCollectSlotChestCommand : LogicCommand
    {
        public LogicCollectSlotChestCommand(Device device, IByteBuffer buffer) : base(device, buffer)

        {
        }
        public override void Decode()
        {
            var chestID = 8;
            base.Decode();

            Reader.ReadVInt();

            chestID = Reader.ReadVInt();
            Console.WriteLine($"[Debug] [C] Slot Chest opened by {Device.Player.Home.Name}, {Device.Player.Home.Id} ");
        }
        public override async void Process()
        {
            var home = Device.Player.Home;

            await new AvailableServerCommand(Device)
            {
                Command = new ChestDataCommand(Device)
                {
                    Chest = Device.Player.Home.Chests.BuyChest(1, Chest.ChestType.Slot)
                }
            }.SendAsync();

        }
    }
}

