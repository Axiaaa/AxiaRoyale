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
    public class SlotChests
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
            {
                if (type == Chest.ChestType.Slot)
                {
                    for (var i = 0; i < random.Next(10, 15); i++)
                        if (random.Next(1, 2) == 1)
                        {
                            var card = Cards.RandomByArena(Card.Rarity.Common, chestArenas);
                            if (card == null) continue;

                            card.Count = (random.Next(1, 300));
                            card.IsNew = true;
                            chest.Add(card);
                            Home.Deck.Add(card);

                        }
                }
              }

            // Rare
            {
                if (type == Chest.ChestType.Slot)
                {
                    for (var i = 0; i < random.Next(10, 15); i++)
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
                
            }

            // Epic
            {
                if (type == Chest.ChestType.Slot)
                {
                    for (var i = 0; i < random.Next(10, 15); i++)
                        if (random.Next(1, 3) == 1)
                        {
                            var card = Cards.RandomByArena(Card.Rarity.Epic, chestArenas);
                            if (card == null) continue;

                            card.Count = (random.Next(1, 60));
                            card.IsNew = true;
                            chest.Add(card);
                            Home.Deck.Add(card);
                        }
                }
                
            }

            // Legendary
            {
                if (type == Chest.ChestType.Slot)
                {
                    if (random.Next(1, 8) == 10)
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

           
           return chest;
          }

        }
    }

