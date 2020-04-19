using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rpg.Model
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
        public List<Crossroad> Crossroad { get; set; }
            
        private void SetDescription()
        {
            Description = RoomID switch
            {
                1 => "yes",

            };
        }
    }
}
