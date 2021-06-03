﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using engine.Models;

namespace engine.Factories
{
    public static class ItemFactory
    {
        private static List<GameItem> _standardGameItems;
        // add items below
        static ItemFactory()
        {
            _standardGameItems = new List<GameItem>();

            _standardGameItems.Add(new Weapon(1001, "Ivan's Stick", 10, 1, 2));
            _standardGameItems.Add(new Weapon(1002, "Xav's Sword", 50, 1, 3));
            _standardGameItems.Add(new GameItem(9001, "Snake fang", 1));
            _standardGameItems.Add(new GameItem(9002, "Snakeskin", 2));
            _standardGameItems.Add(new GameItem(9003, "Rat's Stick", 1));
            _standardGameItems.Add(new GameItem(9004, "Rat's fur", 2));
            _standardGameItems.Add(new GameItem(9005, "Spider's log", 1));
            _standardGameItems.Add(new GameItem(9006, "Spider's fang", 2));
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);

            if(standardItem != null)
            {
                return standardItem.Clone();
            }
            return null;
        }
    }
}
