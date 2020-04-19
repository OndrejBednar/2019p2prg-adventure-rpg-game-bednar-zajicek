using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class Crossroad
    {
        public int CrossroadID { get; set; }
        public int RoomID { get; set; }
        public int NextRoomID { get; set; }
    }
}
