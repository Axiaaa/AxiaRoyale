using System;
using System.Collections.Generic;
using System.Text;
using ClashRoyale.Logic;
using ClashRoyale.Logic.Home.Chests.Items;
using ClashRoyale.Protocol.Commands.Server;
using ClashRoyale.Protocol.Messages.Server;
using ClashRoyale.Utilities.Netty;
using DotNetty.Buffers;

namespace ClashRoyale.Protocol.Commands.Client
{
    public class LogicSellChestCommand : LogicCommand
    {
        public LogicSellChestCommand(Device device, IByteBuffer buffer) : base(device, buffer)

        {
        }

        public int InstanceId { get; set; }
        public override void Decode()
        {

            var chestID = 7;
            base.Decode();

            Reader.ReadVInt();

            chestID = Reader.ReadVInt();
            Console.WriteLine($"[Debug] [C] Slot Chest opened by {Device.Player.Home.Name}, {Device.Player.Home.Id} ");


        }
        public override async void Process()
        {
            var chest = Device.Player.Home.Chests.BuyChest(InstanceId, Chest.ChestType.Slot);

            await new AvailableServerCommand(Device)
            {
                Command = new ChestDataCommand(Device)
                {
                    Chest = chest

                }
            }.SendAsync();



        }
    }
}


