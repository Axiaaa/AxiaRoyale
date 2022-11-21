using ClashRoyale.Logic;
using ClashRoyale.Protocol.Messages.Server;
using DotNetty.Buffers;

namespace ClashRoyale.Protocol.Messages.Client.Login
{
    public class KeepAliveMessage : PiranhaMessage
    {
        public KeepAliveMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            Id = 10108;
            RequiredState = Device.State.NotDefinied;
        }

        public override async void Process()
        {
            await new KeepAliveOkMessage(Device).SendAsync();
            {


                //trophies
                var i = (int)Device.Player.Home.Arena.Trophies;
                if (i < 400) //shit but no ideas
                {
                    Device.Player.Home.Arena.CurrentArena = 1;
                }
                else
                {
                    if (i >= 400 && i < 800)
                    {
                        Device.Player.Home.Arena.CurrentArena = 2;
                    }
                    else
                    {
                        if (i >= 800 && i < 1100)
                        {
                            Device.Player.Home.Arena.CurrentArena = 3;
                        }
                        else
                        {
                            if (i >= 1100 && i < 1400)
                            {
                                Device.Player.Home.Arena.CurrentArena = 4;
                            }
                            else
                            {
                                if (i >= 1400 && i < 1700)
                                {
                                    Device.Player.Home.Arena.CurrentArena = 5;
                                }
                                else
                                {
                                    if (i >= 1700 && i < 2000)
                                    {
                                        Device.Player.Home.Arena.CurrentArena = 6;
                                    }
                                    else
                                    {
                                        if (i >= 2000 && i < 2300)
                                        {
                                            Device.Player.Home.Arena.CurrentArena = 7;
                                        }
                                        else
                                        {
                                            if (i >= 2300 && i < 2600)
                                            {
                                                Device.Player.Home.Arena.CurrentArena = 8;
                                            }
                                            else
                                            {
                                                if (i >= 2600 && i < 3000)
                                                {
                                                    Device.Player.Home.Arena.CurrentArena = 9;
                                                }
                                                else
                                                {
                                                    if (i >= 3000 && i < 3800)
                                                    {
                                                        Device.Player.Home.Arena.CurrentArena = 10;
                                                    }
                                                    else
                                                    {
                                                        if (i >= 3800 && i < 4000)
                                                        {
                                                            Device.Player.Home.Arena.CurrentArena = 11;
                                                        }
                                                        else
                                                        {
                                                            if (i >= 4000 && i < 4500)
                                                            {
                                                                Device.Player.Home.Arena.CurrentArena = 12;
                                                            }
                                                            else
                                                            {
                                                                if (i >= 4500 && i < 5000)
                                                                {
                                                                    Device.Player.Home.Arena.CurrentArena = 13;
                                                                }
                                                                else
                                                                {
                                                                    if (i >= 5000 && i < 5500)
                                                                    {
                                                                        Device.Player.Home.Arena.CurrentArena = 14;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (i >= 5500 && i < 6000)
                                                                        {
                                                                            Device.Player.Home.Arena.CurrentArena = 15;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (i >= 6000 && i < 7000)
                                                                            {
                                                                                Device.Player.Home.Arena.CurrentArena = 16;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (i >= 7000 && i < 8000)
                                                                                {
                                                                                    Device.Player.Home.Arena.CurrentArena = 17;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (i >= 8000 && i < 9000)
                                                                                    {
                                                                                        Device.Player.Home.Arena.CurrentArena = 18;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (i >= 9000 && i < 10000)
                                                                                        {
                                                                                            Device.Player.Home.Arena.CurrentArena = 19;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (i >= 10000)
                                                                                            {
                                                                                                Device.Player.Home.Arena.CurrentArena = 20;
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                await new KeepAliveOkMessage(Device).SendAsync();
            }
        }
    }
}