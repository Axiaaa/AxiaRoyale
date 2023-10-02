using System;
using System.Linq;
using ClashRoyale.Database;
using ClashRoyale.Logic;
using ClashRoyale.Logic.Clan.StreamEntry.Entries;
using ClashRoyale.Logic.Home.Decks;
using ClashRoyale.Protocol.Messages.Server;
using ClashRoyale.Utilities;
using ClashRoyale.Utilities.Netty;
using DotNetty.Buffers;

namespace ClashRoyale.Protocol.Messages.Client.Alliance
{
    public class ChatToAllianceStreamMessage : PiranhaMessage
    {
        public ChatToAllianceStreamMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            Id = 14315;
        }

        public string Message { get; set; }

        public override void Decode()
        {
            Message = Reader.ReadScString();
        }

        public override async void Process()
        {
            var info = Device.Player.Home.AllianceInfo;
            if (!info.HasAlliance) return;

            var alliance = await Resources.Alliances.GetAllianceAsync(info.Id);
            if (alliance == null) return;

            if (Message.StartsWith('/'))
            {
                var cmd = Message.Split(' ');
                var cmdType = cmd[0];
                var cmdValue = 0;

                if (cmd.Length > 1)
                    if (Message.Split(' ')[1].Any(char.IsDigit))
                        int.TryParse(Message.Split(' ')[1], out cmdValue);

                switch (cmdType)
                {
                    case "/max":
                    {
                        var deck = Device.Player.Home.Deck;

                        foreach (var card in Cards.GetAllCards())
                        {
                            deck.Add(card);

                            for (var i = 0; i < 13; i++) deck.UpgradeCard(card.ClassId, card.InstanceId, true);
                        }

                        await new ServerErrorMessage(Device)
                        {
                            Message = "Added all cards with max level"
                        }.SendAsync();
                            Console.WriteLine($"[Debug] [C] /max has been correctly executed by {Device.Player.Home.Name}, {Device.Player.Home.Id} ");
                            break;
                    }

                    case "/unlock":
                    {
                        var deck = Device.Player.Home.Deck;

                        foreach (var card in Cards.GetAllCards()) deck.Add(card);

                        await new ServerErrorMessage(Device)
                        {
                            Message = "Added all cards"
                        }.SendAsync();
                            Console.WriteLine($"[Debug] [C] /unlock has been correctly executed by {Device.Player.Home.Name}, {Device.Player.Home.Id} ");

                            break;
                    }

                    case "/klvl":

                        {

                            {
                                if (cmdValue > 13)
                                    await new ServerErrorMessage(Device)
                                    { Message = "You can't type a number over 13 !" }.SendAsync();




                                else
                                    Device.Player.Home.ExpLevel = cmdValue;
                                await new ServerErrorMessage(Device)
                                { Message = $"You are now level {cmdValue}"  }.SendAsync();
                                Console.WriteLine($"[Debug] [C] /klvl has been correctly executed by {Device.Player.Home.Name}, {Device.Player.Home.Id} ");
                            }
                            
                            break;
                        }

                    case "/ressources":
                    {
                        Device.Player.Home.Gold = 100000000;
                        Device.Player.Home.Diamonds = 100000000;
                            await new ServerErrorMessage(Device)
                            {
                                Message = $"You now have full ressources !"
                            }.SendAsync();
                            Console.WriteLine($"[Debug] [C] /gold has been correctly executed by {Device.Player.Home.Name}, {Device.Player.Home.Id} ");
                            break;
                    }

                    case "/ltrophies":
                        {
                            Device.Player.Home.Arena.SetLTrophies(cmdValue);
                            await new ServerErrorMessage(Device)
                            {
                                Message = $"You now have {cmdValue} Legendary trophies !"
                            }.SendAsync();
                            Console.WriteLine($"[Debug] [C] /ltrophies has been correctly executed by {Device.Player.Home.Name}, {Device.Player.Home.Id} ");
                            break;
                        }

                    case "/rshop":
                        {
                            Device.Player.Home.Shop.Refresh();
                            await new ServerErrorMessage(Device)
                            {
                                Message = $"Shop is refreshed !"
                            }.SendAsync();
                            Console.WriteLine($"[Debug] [C] /rshop has been correctly executed by {Device.Player.Home.Name}, {Device.Player.Home.Id} ");
                            break;
                        }


                    case "/status":
                    {
                        await new ServerErrorMessage(Device)
                        {
                            Message =
                                $"Online Players: {Resources.Players.Count}\nTotal Players: {await PlayerDb.CountAsync()}\n1v1 Battles: {Resources.Battles.Count}\n2v2 Battles: {Resources.DuoBattles.Count}\nTotal Clans: {await AllianceDb.CountAsync()}\nUptime: {DateTime.UtcNow.Subtract(Resources.StartTime).ToReadableString()}"
                        }.SendAsync();
                            Console.WriteLine($"[Debug] [C] /status has been correctly executed by {Device.Player.Home.Name}, {Device.Player.Home.Id} ");

                            break;
                    }

                    
                    case "/help":
                        {
                            var CommandOn = "✔";
                            var CommandOff = "❌";

                            await new ServerErrorMessage(Device)

                            {
                                Message = "         .::Here are all commands::.\n \n" +
                                "🏆 /max : Get all cards with max level\n\n" +
                                "🏆 /unlock : Get all cards\n" +
                                "🏆 /ressources : Get max gold and max gems\n" +
                                "🏆 /status : Get info about server\n " +
                                "🏆 /free : Allows you to have the crown chest\n" +
                                "🏆 /ltrophies [Number] : Allows you to have Legendary trophies\n" +
                                "🏆 /rshop : Refresh the shop\n" +
                                "🏆 /trophies [Number] :  Allows to have a desired trophies number\n" +
                                "🏆 /reset [WIP] : Reset every data of your account (literraly everything)\n" +
                                "🏆 /klvl : Allows to set you're king level at desired number (1 - 13)"+
                                "\n" +
                                "\n" +
                                "\n" +
                                "🔥 Available Commands 🔥\n" +
                                "\n" +
                                $"🔥 /max {CommandOn}\n" +
                                $"🔥 /unlock {CommandOn}\n" +
                                $"🔥 /ressources {CommandOn}\n" +
                                $"🔥 /status {CommandOn}\n" +
                                $"🔥 /free {CommandOn}\n" +
                                $"🔥 /ltropies {CommandOn}\n" +
                                $"🔥 /rshop {CommandOn}\n" +
                                $"🔥 /trophies {CommandOn}\n" +
                                $"🔥 /reset {CommandOn}\n" +
                                $"🔥 /klvl {CommandOn}"
                            }.SendAsync();

                            Console.WriteLine($"[Debug] [C] /help has been correctly executed by {Device.Player.Home.Name}, {Device.Player.Home.Id} ");
                            break;
                        }


                    case "/reset":

                        {
                            Device.Player.Home.Diamonds = 1;
                            Device.Player.Home.Gold = 1;
                            Device.Player.Home.Crowns = 0;
                            Device.Player.Home.ExpLevel = 1;
                            Device.Player.Home.Arena.Trophies = 0;
                            Device.Player.Home.Shop.Refresh();


                            await new ServerErrorMessage(Device)
                            { 
                                Message = $"BANG ! Everything has been reset"
                                
                                }.SendAsync();

                            

                            Console.WriteLine($"[Debug] [C] /reset has been correctly executed by {Device.Player.Home.Name}, {Device.Player.Home.Id} ");
                            break;
                        }

                    case "/free":
                    {
                        Device.Player.Home.FreeChestTime = Device.Player.Home.FreeChestTime.Subtract(TimeSpan.FromMinutes(245));
                        Device.Player.Home.Crowns = 10;
                            await new ServerErrorMessage(Device)
                            {
                                Message = $"You now have your free chest/ crown chest!"
                            }.SendAsync();
                            Console.WriteLine($"[Debug] [C] /free has been correctly executed by {Device.Player.Home.Name}, {Device.Player.Home.Id} ") ;
                        break;
                    }

                        /*case "/replay":
                        {
                            await new HomeBattleReplayDataMessage(Device).SendAsync();
                            break;
                        }*/

                    case "/trophies":
                        {   
                            Device.Player.Home.Arena.SetTrophies(cmdValue);


                            Console.WriteLine($"[Debug] [C] /trophies has been correctly executed by {Device.Player.Home.Name}, {Device.Player.Home.Id} ");
                            await new ServerErrorMessage(Device)
                            {
                                Message = $"You now have {cmdValue} trophies !"
                            }.SendAsync();
                            break;
                        }
                    case "/rdmdeck":
                    {

                        bool rdm_deck = true; //Ajoute des randoms 
                        Console.WriteLine($"[Debug] [C] /rdmdeck has been correctly executed by {Device.Player.Home.Name}, {Device.Player.Home.Id} ");
                    }
                    case "/rdmlvl"
                    {
                        bool rdm_lvl = true; //Ajoute des randoms 
                        Console.WriteLine($"[Debug] [C] /rdm_lvl has been correctly executed by {Device.Player.Home.Name}, {Device.Player.Home.Id} ");
                    }


                  }
            }
            else
            {
                var entry = new ChatStreamEntry
                {
                    Message = Message
                };

                entry.SetSender(Device.Player);

                alliance.AddEntry(entry);
            }
        }
    }
}