using System;
using ClashRoyale.Files;
using ClashRoyale.Logic.Battle;
using ClashRoyale.Files.CsvLogic;
using ClashRoyale.Logic.Home.Chests.Items;
using ClashRoyale.Logic.Home.Decks;
using ClashRoyale.Logic.Home.Decks.Items;
using Newtonsoft.Json;

namespace ClashRoyale.Logic.Home.Chests
{
    public class Chests
    {
        [JsonIgnore] public Home Home { get; set; }
       
        public Chest BuyChest(int instanceId, Chest.ChestType type)
        {
            var chests = Csv.Tables.Get(Csv.Files.TreasureChests);
            var mainchest = chests.GetDataWithInstanceId<TreasureChests>(instanceId);
            var baseChest = chests.GetData<TreasureChests>(mainchest.BaseChest);
            var chestArenas = Home.Arena.GetChestArenaNames();
            var random = new Random();

            var chest = new Chest
            {
                ChestId = instanceId,
                IsDraft = mainchest.DraftChest,
                Type = type
            };

            // Common 
            {               //Shop Slot
                if (type == Chest.ChestType.Shop)
                {
                    for (var i = 0; i < random.Next(2, 5); i++)
                        if (random.Next(1, 2) == 1)
                        {
                            var card = Cards.RandomByArena(Card.Rarity.Common, chestArenas);
                            if (card == null) continue;

                            card.Count = (random.Next(1, 300000));
                            card.IsNew = true;
                            chest.Add(card);
                            Home.Deck.Add(card);

                        }
                }
                else

                {           //Slot Chests
                    if (type == Chest.ChestType.Slot)
                    {
                        for (var i = 0; i < random.Next(5, 10); i++)
                            if (random.Next(1, 2) == 1)
                            {
                                var card = Cards.RandomByArena(Card.Rarity.Common, chestArenas);
                                if (card == null) continue;

                                card.Count = (random.Next(1, 300000));
                                card.IsNew = true;
                                chest.Add(card);
                                Home.Deck.Add(card);
                            }
                    }
                    else
                    {
                            //Crown & Free
                        for (var i = 0; i < random.Next(1, 2); i++)
                            if (random.Next(1, 2) == 1)
                            {
                                var card = Cards.RandomByArena(Card.Rarity.Common, chestArenas);
                                if (card == null) continue;

                                card.Count = (random.Next(1, 100));
                                card.IsNew = true;
                                chest.Add(card);
                                Home.Deck.Add(card);

                            }
                    }
                }

            }

            // Rare
            {
                if (type == Chest.ChestType.Shop)
                {
                    for (var i = 0; i < random.Next(1, 10); i++)
                        if (random.Next(1, 2) == 1)
                        {
                            var card = Cards.RandomByArena(Card.Rarity.Rare, chestArenas);
                            if (card == null) continue;

                            card.Count = (random.Next(1, 100));
                            card.IsNew = true;
                            chest.Add(card);
                            Home.Deck.Add(card);
                        }
                }
                else

                {           //Slot Chests
                    if (type == Chest.ChestType.Slot)
                    {
                        for (var i = 0; i < random.Next(5, 10); i++)
                            if (random.Next(1, 2) == 1)
                            {
                                var card = Cards.RandomByArena(Card.Rarity.Rare, chestArenas);
                                if (card == null) continue;

                                card.Count = (random.Next(1, 300000));
                                card.IsNew = true;
                                chest.Add(card);
                                Home.Deck.Add(card);

                            }
                    }
                    else
                    {
                        //Crown & Free
                        for (var i = 0; i < random.Next(1, 2); i++)
                            if (random.Next(1, 2) == 1)
                            {
                                var card = Cards.RandomByArena(Card.Rarity.Rare, chestArenas);
                                if (card == null) continue;

                                card.Count = (random.Next(1, 50));
                                card.IsNew = true;
                                chest.Add(card);
                                Home.Deck.Add(card);

                            }
                    }
                }
            }

            // Epic
            {
                if (type == Chest.ChestType.Shop)
                {
                    for (var i = 0; i < random.Next(1, 5); i++)
                        if (random.Next(1, 2) == 1)
                        {
                            var card = Cards.RandomByArena(Card.Rarity.Epic, chestArenas);
                            if (card == null) continue;

                            card.Count = (random.Next(1, 30));
                            card.IsNew = true;
                            chest.Add(card);
                            Home.Deck.Add(card);
                        }
                }
                else

                {           //Slot Chests
                    if (type == Chest.ChestType.Slot)
                    {
                        for (var i = 0; i < random.Next(5, 10); i++)
                            if (random.Next(1, 2) == 1)
                            {
                                var card = Cards.RandomByArena(Card.Rarity.Epic, chestArenas);
                                if (card == null) continue;

                                card.Count = (random.Next(1, 300000));
                                card.IsNew = true;
                                chest.Add(card);
                                Home.Deck.Add(card);

                            }
                    }
                    else
                    {
                        //Crown & Free
                        for (var i = 0; i < random.Next(0,2); i++)
                            if (random.Next(1, 2) == 1)
                            {
                                var card = Cards.RandomByArena(Card.Rarity.Epic, chestArenas);
                                if (card == null) continue;

                                card.Count = (random.Next(1, 10));
                                card.IsNew = true;
                                chest.Add(card);
                                Home.Deck.Add(card);

                            }
                    }
                }
            }

            // Legendary
            {
                if (type == Chest.ChestType.Shop)
                {
                    if (random.Next(1, 8) == 1)
                    {
                        var card = Cards.RandomByArena(Card.Rarity.Legendary, chestArenas);

                        if (card != null)
                        {
                            card.Count = (random.Next(1, 10));
                            card.IsNew = true;
                            chest.Add(card);
                            Home.Deck.Add(card);
                        }
                    }
                }
                else

                {           //Slot Chests
                    if (type == Chest.ChestType.Slot)
                    {
                        for (var i = 0; i < random.Next(5, 10); i++)
                            if (random.Next(1, 2) == 1)
                            {
                                var card = Cards.RandomByArena(Card.Rarity.Legendary, chestArenas);
                                if (card == null) continue;

                                card.Count = (random.Next(1, 300000));
                                card.IsNew = true;
                                chest.Add(card);
                                Home.Deck.Add(card);

                            }
                    }
                    else
                    {
                        //Crown & Free
                        if (type == Chest.ChestType.Shop)
                        {
                            if (random.Next(1, 8) == 1)
                            {
                                var card = Cards.RandomByArena(Card.Rarity.Legendary, chestArenas);

                                if (card != null)
                                {
                                    card.Count = (random.Next(1, 10));
                                    card.IsNew = true;
                                    chest.Add(card);
                                    Home.Deck.Add(card);
                                }
                            }
                        }
                    }
                }
            }

            if (type == Chest.ChestType.Shop)
            {
                // TODO: Cost
                //chest.Gems = 10000;
                chest.Gold = 10000;
            }
            else
            {
                //chest.Gems = 10000;
                chest.Gold = 10000;
            }

            if (type == Chest.ChestType.Slot)
            {
                // TODO: Cost
                chest.Gems = 10000;
                chest.Gold = 10000;
            }
            else
            {
                //chest.Gems = 10000;
                chest.Gold = 10000;
            }

            if (type == Chest.ChestType.Free)
            {
                // TODO: Cost
                //chest.Gems = 10000;
                chest.Gold = 10000;
            }
            else
            {
                //chest.Gems = 10000;
                chest.Gold = 10000;
            }

            if (type == Chest.ChestType.Crown)
            {
                // TODO: Cost
                // chest.Gems = 10000;
                chest.Gold = 10000;
            }
            else
            {
                //chest.Gems = 10000;
                chest.Gold = 10000;
            }
            Home.Gold += chest.Gold;
            Home.Diamonds += chest.Gems;

            /*var price =
                  ((baseChest.ShopPriceWithoutSpeedUp * Home.Arena.GetCurrentArenaData().ChestShopPriceMultiplier) / 100);

              Console.WriteLine(RoundPrice(price));*/

              return chest;
          }

            /// <summary>
            ///     by nameless
            /// </summary>
            /// <param name="price"></param>
            /// <returns></returns>
            private int RoundPrice(int price)
            {
                if (price > 500)
                    return 100 * ((price + 3) / 100);
                if (price > 100)
                    return 10 * ((price + 2) / 10);
                if (price > 20)
                    return 5 * ((price + 1) / 5);

                return price;
            }
        }
    }

