using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class GameStory
    {
        public Dictionary<int, Room> Rooms { get; } = new Dictionary<int, Room>();
        public GameStory()
        {
            //--------Tutorial--------//
            Rooms.Add(0, new Room() {
                RoomID = 0,
                Description = "Právě se nacházíš v tutoriálové místnosti",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 0, Description = "Pokračovat", NextRoomID = 1 },
                }
            });
            Rooms.Add(1, new Room()
            {
                RoomID = 1,
                Description = "Právě se nacházíš na louce",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 1, Description = "Vydám se do města", NextRoomID = 2 },
                }
            });
            //--------Město(začáteční lokace)--------//
            Rooms.Add(2, new Room()
            {
                RoomID = 2,
                Description = "Právě se nacházíš ve městě",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 21, Description = "Vydám se do lesa", NextRoomID = 3 },
                    new Crossroad() { CrossroadID = 20, Description = "Půjdu do jeskyně za městem", NextRoomID = 4 },
                    new Crossroad() { CrossroadID = 22, Description = "Půjdu na pobřeží", NextRoomID = 5 },
                    new Crossroad() { CrossroadID = 23, Description = "Walk straight", NextRoomID = 6 },
                }
            });
            //--------Les--------//
            Rooms.Add(3, new Room()
            {
                RoomID = 3,
                Description = "Právě se nacházíš v lese",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 30, Description = "Vrátím se do města", NextRoomID = 2 },
                    new Crossroad() { CrossroadID = 31, Description = "Půjdu dál houštím", NextRoomID = 4 },
                }
            });
            //--------Jeskyně--------//
            Rooms.Add(4, new Room()
            {
                RoomID = 4,
                Description = "Právě se nacházíš v jeskyni",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 40, Description = "Vrátím se do města", NextRoomID = 2 },
                    new Crossroad() { CrossroadID = 41, Description = "Půjdu hlouběji do jeskyně", NextRoomID = 41 },
                }
            });
            //--------Pobřeží--------//
            Rooms.Add(5, new Room()
            {
                RoomID = 5,
                Description = "Právě se nacházíš v jeskyni",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 50, Description = "Vrátím se do města", NextRoomID = 2 },
                    new Crossroad() { CrossroadID = 51, Description = "Půjdu dál podél pobřeží", NextRoomID = 51 },
                }
            });
            Rooms.Add(6, new Room()
            {
                RoomID = 6,
                Description = "You feel like you're gonna have a b ad time",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 61, Description = "Go back to town", NextRoomID = 2 },
                }
            });
        }
    }

    public class Room
    {
        public int RoomID { get; set; }
        public string Description { get; set; }
        public List<Crossroad> Crossroads { get; set; }
    }

    public class Crossroad
    {
        public int CrossroadID { get; set; }
        public int NextRoomID { get; set; }
        public string Description { get; set; }
    }
}
