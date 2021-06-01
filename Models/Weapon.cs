using System;
using System.Collections.Generic;
using System.Text;

namespace engine.Models
{
    public class Weapon : GameItem
    {
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public Weapon(int itemTypeID, string name, int price, int minDmg, int maxDmg) : base(itemTypeID, name, price)
        {
            MinDmg = minDmg;
            MaxDmg = maxDmg; 
        }

        public new Weapon Clone()
        {
            return new Weapon(ItemTypeID, Name, Price, MinDmg, MaxDmg);
        }
    }
}
