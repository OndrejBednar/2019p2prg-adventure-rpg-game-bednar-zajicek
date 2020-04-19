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
        public Room(int id, int[] crossroads)
        {
            RoomID = id;
            SetDescription();
            for (int i = 0; i < crossroads.Length; i++)
            {
                if(crossroads[i] != -1)
                {
                    Crossroads.Add(new Crossroad(i, RoomID, crossroads[i]));
                }
            }
        }
        public int RoomID { get; set; }
        public string Description { get; set; }
        public List<Crossroad> Crossroads { get; set; }
            
        private void SetDescription()
        {
            Description = RoomID switch
            {
                0 => "Toto je tutoriálová místnost",
                1 => "Toto je louka",
                2 => "Toto je město"
            };
        }
    }
}
