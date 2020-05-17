using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class Player : Stats
    {
        public string Name { get; set; } = "";
        public int HealthPoints { get; set; } = 100;
        public int ManaPoints { get; set; } = 50;
        public int Attack { get; set; } = 5;
        public int CritChance { get; set; } = 20;
        public int Defense { get; set; } = 5;
        public int SpellPower { get; set; } = 5;
        public Dictionary<string, Item> Inventory { get; set; }// = new Dictionary<string, Item>();
    }
}
