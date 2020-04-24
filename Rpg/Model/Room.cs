using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rpg.Models
{
    public class Room
    {
        public Room(int id)
        {
            RoomID = id;
            SetDescription();
        }
        public int RoomID { get; set; }
        public string Description { get; set; }
        public List<Crossroad> Crossroads { get; } = new List<Crossroad>();

        public void AddCrossroad(Crossroad crossroad)
        {
            Crossroads.Add(crossroad);
        }
            
        private void SetDescription()
        {
            Description = RoomID switch
            {
                0 => "Právě se nacházíš v tutoriálové místnosti",
                1 => "Právě se nacházíš na louce",
                2 => "Právě se nacházíš v městě",
                3 => "Právě se nacházíš v lese",
                4 => "Právě se nacházíš v jeskyni",
                5 => "Právě se nacházíš na pobřeží",
            };
        }
    }
}
