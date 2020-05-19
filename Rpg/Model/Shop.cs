using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class Shop
    {
        public int ShopID { get; set; }
        public int NextRoomID { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Item> Inventory { get; set; }
    }
}
