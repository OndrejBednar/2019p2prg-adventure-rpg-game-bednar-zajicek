using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class Item
    {
        public string Name { get; set; }
        public int Count { get; set; } = 1;
        public string Description { get; set; }
        public int Cost { get; set; }
        public bool Sellable { get; set; } = true;
        public bool IsEquipped { get; set; } = false;
        public Stats BonusStats { get; set; }
        public ItemType Type { get; set; }
    }
}
