using ClashRoyale.Logic;
using ClashRoyale.Utilities.Netty;


namespace ClashRoyale.Protocol.Messages.Server
{
    public class InboxListMessage : PiranhaMessage
    {
        public InboxListMessage(Device device) : base(device)
        {
            Id = 24445;
        }

        public override void Encode()
        {
            {
                var CommandOn = "✔";
                //var CommandOff = "❌";
                Writer.WriteInt(1);


                Writer.WriteScString("https://56f230c6d142ad8a925f-b174a1d8fb2cf6907e1c742c46071d76.ssl.cf2.rackcdn.com/inbox/ClashRoyale_logo_small.png");
                Writer.WriteScString(".::<c2>Here are all commands !</c>::."); //Title
                Writer.WriteScString("🏆 / max : Get all cards with max level\n" +
                                    "🏆 /unlock : Get all cards\n" +
                                    "🏆 /ressources : Get max gold and max gems\n" +
                                    "🏆 /status : Get info about server\n " +
                                    "🏆 /free : Allows you to have the crown chest\n" +
                                    "🏆 /ltrophies [Number] : Allows you to have Legendary trophies\n" +
                                    "🏆 /rshop : Refresh the shop\n" +
                                    "🏆 /trophies :  Allows to have a desired trophies number\n" +
                                    "🏆 /reset [WIP] : Reset every data of your account (literraly everything)\n" +
                                    "🏆 /klvl : Allows to set you're king level at desired number (1 - 13)" +
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
                                    $"🔥 /rshop {CommandOn}\n" +
                                    $"🔥 /ltropies {CommandOn}\n" +
                                    $"🔥 /trophies {CommandOn}\n" +
                                    $"🔥 /reset {CommandOn}\n" +
                                    $"🔥 /klvl {CommandOn}\n\n\n"+
                "❤️ Special thanks to Incredible, Nameless, Vitalik, HuzaModz");//Description






                Writer.WriteScString("Test");//Button Name
                Writer.WriteScString("");//Button link
                Writer.WriteScString("");//Unk
                Writer.WriteScString("");//Unk
            }

        }
    }
}