using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class Room
    {
        public int RoomID { get; set; }
        public string Description { get; set; }
        public List<Crossroad> Crossroads { get; set; }
        public bool Inventory { get; set; } = true;
        public Rewards Reward { get; set; }
    }
}
