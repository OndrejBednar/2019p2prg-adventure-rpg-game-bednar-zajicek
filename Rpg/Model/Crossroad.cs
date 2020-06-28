using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class Crossroad
    {
        public int CrossroadID { get; set; }
        public int NextRoomID { get; set; }
        public string Description { get; set; }
        public bool Locked { get; set; }
        public RoomType Type { get; set; } = RoomType.Normal;
    }
}
