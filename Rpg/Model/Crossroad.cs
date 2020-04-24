using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Models
{
    public class Crossroad
    {
        public Crossroad(int roomID, int crossroadID)
        {
            RoomID = roomID;
            CrossroadID = crossroadID;
            SetParameters();
        }

        public int CrossroadID { get; set; }
        public int RoomID { get; set; }
        public int NextRoomID { get; set; }
        public string Description { get; set; }

        private void SetParameters()
        {
            Description = CrossroadID switch
            {
                //--------Tutorial--------//
                0 => "Rozumím a jsem připraven hrát",
                100 => "Vydám se do města",
                //--------Město(začáteční lokace)--------//
                200 => "Vydám se do jeskyně za městem",
                201 => "Vydám se do lesa",
                202 => "Vydám se na pobřeží",
                //--------Les--------//
                300 => "Půjdu dál houštím WORK IN PROGRESS",
                301 => "Vrátím se zpět do města",
                //--------Jeskyně--------//
                400 => "Půjdu hlouběji do jeskyně WORK IN PROGRESS",
                401 => "Vratím se zpátky do města",
                //--------Pobřeží--------//
                500 => "Půjdu dále podél pobřeží WORK IS PROGRESS",
                501 => "Vrátím se zpátky do města",
            };
            NextRoomID = CrossroadID switch
            {
                //0,1 -> Tutorial
                //2 -> Město
                //3 -> Les
                //4 -> Jeskyně
                //5 -> Pobřeží
                //--------Tutorial--------//
                0 => 1,
                100 => 2,
                //--------Město(začáteční lokace)--------//
                200 => 4,
                201 => 3,
                202 => 5,
                //--------Les--------//
                300 => 7,
                301 => 2,
                //--------Jeskyně--------//
                400 => 6,
                401 => 2,
                //--------Pobřeží--------//
                500 => 8,
                501 => 2,
            };
        }
    }
}
