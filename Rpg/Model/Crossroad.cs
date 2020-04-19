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
            SetDescription();
        }

        public int CrossroadID { get; set; }
        public int RoomID { get; set; }
        public int NextRoomID { get; set; }
        public string Description { get; set; }

        private void SetDescription()
        {
            Description = RoomID switch
            {
                0 => "Rozumím a jsem připraven hrát",
                1 => "Vydám se do města",
                2 => "Toto je město"
            };
        }
    }
}
