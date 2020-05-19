using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class GameStory
    {
        public Dictionary<int, Room> Rooms { get; } = new Dictionary<int, Room>();
        public Dictionary<int, Battle> Battles { get; } = new Dictionary<int, Battle>();
        public Dictionary<int, Shop> Shops { get; } = new Dictionary<int, Shop>();
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
                Description = "Probudil ses na louce, nevíš kde ses tu vzal. Po chvíli na tebe začne křičet nějaký neznámý člověk, který vypadá, jako by před něčím utíkal. \"Ty tam, utíkej do města na konci louky !\"",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 1, Description = "Poslechnout ho a utéct do města", NextRoomID = 2 },
                }
            });
            //--------Město(začáteční lokace)--------//
            Rooms.Add(2, new Room()
            {
                RoomID = 2,
                Description = "Doběhl si do města, ale vypadá to, že ten cizinec to nezvládl. Vůbec nevíš, kdo to byl. Nejspíš by ses měl porozhlédnout po městě a říct někomu, co se stalo",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 20, Description = "Porozhlédnout se po městě", NextRoomID = 21 },
                    new Crossroad() { CrossroadID = 21, Description = "Walk straight (test boje)", NextRoomID = 6 },
                }
            });
            Rooms.Add(21, new Room()
            {
                RoomID = 21,
                Description = "Porozhlédnul ses po městě a slyšel jsi, že v hospodě jsou známí bojovníci, kteří by možná mohli pomoct onu cizinci. Také jsi nedaleko hospody našel obchod. Odemčeny nové lokace: Hospoda, Obchodník",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 212, Description = "Jít do hospody", NextRoomID = 212 },
                    new Crossroad() { CrossroadID = 211, Description = "Jít k obchodníkovi", NextRoomID = 211 },
                }
            });
            Rooms.Add(211, new Room()
            {
                RoomID = 211,
                Description = "Právě se nacházíš u obchodníka, zde si mužeš za zlaťáky kupovat vylepšení nebo také prodávat věci, které již nepotřebuješ",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2110, Description = "Podívat se co nabízí", NextRoomID = 1, Type = RoomType.Shop },
                    new Crossroad() { CrossroadID = 2111, Description = "Vrátit se na náměstí", NextRoomID = 22},
                }
            }); //Obchodník
            Shops.Add(1, new Shop()
            {
                ShopID = 1,
                NextRoomID = 22,
                Description = "Vlevo máš tvé itemy, které mužeš prodat kliknutím na ně (některé však nelze) a na pravé straně si mužeš koupit předměty od obchodníka také kliknutím",
                Inventory = new Dictionary<string, Item>() {
                    { "mec", new Item() { Name = "mec", Cost = 2 } }
                }
            });
            Rooms.Add(212, new Room()
            {
                RoomID = 212,
                Description = "Došel jsi do hospody a vidíš skupinku bojovníků sedících u stolu v rohu hospody.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2121, Description = "Jít za nimi a říct jim o tom, co se stalo", NextRoomID = 2121},
                    new Crossroad() { CrossroadID = 2122, Description = "Jít ke stolu a objednat si pivo", NextRoomID = 2122},
                    new Crossroad() { CrossroadID = 2111, Description = "Vrátit se na náměstí", NextRoomID = 22},
                }
            });
            Rooms.Add(22, new Room()
            {
                RoomID = 22,
                Description = "Vrátil jsi se na náměstí",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 212, Description = "Jít do hospody", NextRoomID = 212},
                    new Crossroad() { CrossroadID = 211, Description = "Jít k obchodníkovi", NextRoomID = 211 },
                }
            });
            //--------Les--------//
            Rooms.Add(3, new Room()
            {
                RoomID = 3,
                Description = "Právě se nacházíš v lese",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 31, Description = "Půjdu dál houštím", NextRoomID = 7 },
                    new Crossroad() { CrossroadID = 30, Description = "Vrátím se do města", NextRoomID = 2 },
                }
            });
            Rooms.Add(7, new Room()
            {
                RoomID = 7,
                Description = "Prošel jsi houštím až na mýtinu za lesem. Poohlédneš se po okolí a všimneš si chátrající chaloupky",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 71, Description = "Prozkoumat chátrající chaloupku (neni ve hre)", NextRoomID = 8 },
                    new Crossroad() { CrossroadID = 70, Description = "Vrátím se do města", NextRoomID = 2 },
                }
            });
            //--------Jeskyně--------//
            Rooms.Add(4, new Room()
            {
                RoomID = 4,
                Description = "Právě se nacházíš v jeskyni",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 41, Description = "Půjdu hlouběji do jeskyně (neni ve hre)", NextRoomID = 41 },
                    new Crossroad() { CrossroadID = 40, Description = "Vrátím se do města", NextRoomID = 2 },
                }
            });
            //--------Pobřeží--------//
            Rooms.Add(5, new Room()
            {
                RoomID = 5,
                Description = "Právě se nacházíš na pobřeží",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 51, Description = "Půjdu dál podél pobřeží", NextRoomID = 6 },
                    new Crossroad() { CrossroadID = 50, Description = "Vrátím se do města", NextRoomID = 2 },
                }
            });
            //--------Test Boje-------//
            Rooms.Add(6, new Room()
            {
                RoomID = 6,
                Description = "You feel like you're gonna have a bad time",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 60, Description = "FIGHT !", NextRoomID = 60, Type = RoomType.Battle},
                    new Crossroad() { CrossroadID = 61, Description = "Go back to town", NextRoomID = 61, Type = RoomType.Battle },
                },
            });
            Battles.Add(60, new Battle() { BattleID = 1, NextRoomID = 2,
                BossStats = new Npc() { Name = "Krab", HealthPoints = 20, ManaPoints = 0, Attack = 4, CritChance = 20, Defense = 7, SpellPower = 0},
                Description = $"Tasíš svůj meč a připravuješ se k boji proti Krabovi" });
            Battles.Add(61, new Battle() { BattleID = 2, NextRoomID = 2,
                BossStats = new Npc() { Name = "Krab", HealthPoints = 20, ManaPoints = 0, Attack = 20, Defense = 2, SpellPower = 0 },
                Description = "Pokusil ses utéct, ale nevyšlo ti to ... Krab útočí" });
            //---------SMRT--------//
            Rooms.Add(666, new Room()
            {
                RoomID = 666,
                Description = "Zemřel jsi a nyní mužeš:",
                Crossroads = new List<Crossroad>() { }
            });
        }
    }
}
