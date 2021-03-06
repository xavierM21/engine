﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace engine.Models
{
    public class Monsters : basenotification
    {
        private int _HP;

        public string Name { get; private set; }
        public string ImageName { get; set; }
        public int MaximumHP { get; private set; }
        public int HP
        {
            get { return _HP; }
            set
            {
                _HP = value;
                onPropertyChanged(nameof(HP));
            }
        }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public int RewardXP { get; private set; }
        public int RewardGold { get; private set; }

        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        public Monsters(string name, string imageName, int maxHP, int hP, int minDmg, int maxDmg, int rewardXP, int rewardGold)
        {
            Name = name;
            ImageName = string.Format("pack://application:,,,/Engine;component/Images/Monsters/{0}", imageName);
            MaximumHP = maxHP;
            HP = hP;
            MinDmg = minDmg;
            MaxDmg = maxDmg;
            RewardXP = rewardXP;
            RewardGold = rewardGold;

            Inventory = new ObservableCollection<ItemQuantity>();
        }
    }
}
