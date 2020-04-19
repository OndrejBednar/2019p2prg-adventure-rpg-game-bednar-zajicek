using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class Crossroad
    {
        public Crossroad(int crossroadID, int roomID, int nextRoomID)
        {
            CrossroadID = crossroadID;
            RoomID = roomID;
            NextRoomID = nextRoomID;
        }

        public int CrossroadID { get; set; }
        public int RoomID { get; set; }
        public int NextRoomID { get; set; }
    }
}
