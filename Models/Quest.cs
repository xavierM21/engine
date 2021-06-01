using System;
using System.Collections.Generic;
using System.Text;
using engine.Models;

namespace engine.Models
{
    public class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ItemQuantity> ItemsToComplete { get; set; }

        public int RewardXP { get; set; }
        public int RewardGold { get; set; }
        public List<ItemQuantity> RewardItems { get; set; }

        public Quest(int id, string name, string description, List<ItemQuantity> itemToComplete, int rewardXP, int rewardGold, List<ItemQuantity> rewardItems)
        {
            ID = id;
            Name = name;
            Description = description;
            ItemsToComplete = itemToComplete;
            RewardXP = rewardXP;
            RewardGold = rewardGold;
            RewardItems = rewardItems;
        }
    }
}
