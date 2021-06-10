using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using engine.Models;

namespace engine.Factories
{
    public static class MonsterFactory
    {
        public static Monsters GetMonster(int monsterID)
        {
            // add monsters and their loot tables here
            switch (monsterID)
            {
                case 1:
                    Monsters snake =
                        new Monsters("Snake", "Snake.png", 4, 4, 1, 2, 5, 1);

                    AddLootItem(snake, 9001, 25);
                    AddLootItem(snake, 9002, 75);

                    return snake;

                case 2:
                    Monsters rat =
                        new Monsters("Rat", "Rat.png", 5, 5, 1, 2, 5, 1);

                    AddLootItem(rat, 9003, 25);
                    AddLootItem(rat, 9004, 75);

                    return rat;

                case 3:
                    Monsters giantSpider =
                        new Monsters("Giant Spider", "Spider.png", 10, 10, 1, 4, 10, 3);

                    AddLootItem(giantSpider, 9005, 25);
                    AddLootItem(giantSpider, 9006, 75);

                    return giantSpider;

                default:
                    throw new ArgumentException(string.Format("MonsterType '{0}' does not exist", monsterID));
            }
        }

        private static void AddLootItem(Monsters monster, int itemID, int percentage)
        {
            if (RNG.SimpleNumberBetween(1, 100) <= percentage)
            {
                monster.Inventory.Add(new ItemQuantity(itemID, 1));
            }
        }
    }
}