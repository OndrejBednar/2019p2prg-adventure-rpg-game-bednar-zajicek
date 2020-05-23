using Microsoft.CodeAnalysis.FlowAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class Player
    {
        public string Name { get; set; } = "";
        public int Power { get; set; } = 2;
        public int Knowledge { get; set; } = 0;
        public Stats PlayerStats { get; set; } = new Stats() {
            MaxHealthPoints = 100, 
            HealthPoints = 100,
            MaxManaPoints = 50,
            ManaPoints = 50,
            Attack = 2, 
            CritChance = 5, 
            Defense = 2, 
            Spellpower = 0
        };
        public int Gold { get; set; } = 0;
        public Item Weapon { get; set; } = new Item() { Name = "pěsti", BonusStats = new Stats() { Attack = 5 }, Sellable = false, IsEquipped = true, Type = ItemType.Weapon};
        public Item Amulet { get; set; } = new Item() { Name = "", BonusStats = new Stats(), Sellable = false, IsEquipped = true, Type = ItemType.Amulet};
        public Item Armor { get; set; } = new Item() { Name = "košile", BonusStats = new Stats(), Sellable = false, IsEquipped = true, Type = ItemType.Armor };
        public List<Item> Inventory { get; set; } = new List<Item>();
    }
}
