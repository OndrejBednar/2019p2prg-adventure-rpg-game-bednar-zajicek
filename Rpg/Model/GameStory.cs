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
                Description = "Probudil ses na louce, nevíš kde ses tu vzal. Po chvíli na tebe začne křičet nějaký neznámý člověk, který vypadá, jako by před něčím utíkal. \"Ty tam, utíkej do vesnice na sever, pokud chceš žít !\"",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 1, Description = "Poslechnout ho a utéct do města", NextRoomID = 2 },
                }
            });
            //--------vesnice(začáteční lokace)--------//
            Rooms.Add(2, new Room()
            {
                RoomID = 2,
                Description = "Doběhl si do vesnice, ale vypadá to, že ten cizinec to nezvládl. Vůbec nevíš, kdo to byl. Nejspíš by ses měl porozhlédnout po cesnici a říct někomu, co se stalo",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 20, Description = "Porozhlédnout se po městě", NextRoomID = 21 },
                    new Crossroad() { CrossroadID = 21, Description = "Walk straight (test boje)", NextRoomID = 6 },
                }
            });
            Rooms.Add(21, new Room()
            {
                RoomID = 21,
                Description = "Porozhlédnul ses po vesnici a slyšel jsi, že v hospodě jsou známí bojovníci, kteří by možná mohli pomoct onu cizinci. Odemčena nová lokace: Hospoda",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 212, Description = "Jít do hospody", NextRoomID = 212 },
                }
            });
            Rooms.Add(22, new Room()
            {
                RoomID = 22,
                Description = "Vrátil jsi se na náměstíčko",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 212, Description = "Jít do hospody", NextRoomID = 212},
                }
            });
            //--Hospoda
            Rooms.Add(212, new Room()
            {
                RoomID = 212,
                Description = "Došel jsi do hospody a vidíš skupinku bojovníků sedících u stolu v rohu hospody.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2121, Description = "Jít za nimi a říct jim o tom, co se stalo", NextRoomID = 2121},
                    new Crossroad() { CrossroadID = 2120, Description = "Jít ke stolu a objednat si pivo", NextRoomID = 21200},
                    new Crossroad() { CrossroadID = 2111, Description = "Vrátit se na náměstí", NextRoomID = 22},
                }
            });
            //--1.varianta
            Rooms.Add(2121, new Room()
            {
                RoomID = 2121,
                Description = "Přišel jsi za nimi ke stolu a pověděl jim o tom co se stalo ... Po chvíli mlčení jejich vůdce promluvil \"Pokud to co říkáš je pravda, tak tu máme problém a je nutno ho řešit.\"",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 21210, Description = "Ano, je to pravda ...", NextRoomID = 2122},
                    
                }
            });
            Rooms.Add(2122, new Room()
            {
                RoomID = 2122,
                Description = "\"Ale je tu problém ... není nás dost, takhle se tam nemůžeme vydat.\" \"Pokud by ses nabídl, že nám pomužeš tak ti dáme nějaké vybavení a naučíme tě základům boje\"",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 21220, Description = "Rád se k vám přidám a pokusím se pomoct onu cizinci, co mě zachránil ...", NextRoomID = 2123},
                }
            });
            Rooms.Add(2123, new Room()
            {
                RoomID = 2123,
                Description = "\"Taková odvaha, to se jen tak nevidí ! ... Pověz nám, odkud jsi mladíku ?\"",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 21230, Description = "Já nevím ...", NextRoomID = 21201},
                }
            });
            //--2.varianta
            Rooms.Add(21200, new Room()
            {
                RoomID = 21220,
                Description = "Sedl sis ke stolu, objednal sis jedno a po chvilce si tě všimla skupinka bojovníků a jejich velitel na tebe promluví \"Hej ty, vypadáš zmateně ... Odkud jsi ?\"",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 21221, Description = "Já nevím ...", NextRoomID = 21221},
                }
            });
            Rooms.Add(21201, new Room()
            {
                RoomID = 21201,
                Description = "\"Jak to myslíš, že nevíš ?\"",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 212011, Description = "Probudil jsem se na louce za městem a nevím kde jsem se tam vzal", NextRoomID = 21202},
                }
            });
            Rooms.Add(21202, new Room()
            {
                RoomID = 21202,
                Description = "\"To si děláš srandu !?\" \"Takže ty jsi jeden z NICH ?\"",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 212021, Description = "Z koho ? co ? O čem to mluvíš ?", NextRoomID = 21203},
                }
            });
            Rooms.Add(21203, new Room()
            {
                RoomID = 21203,
                Description = "\"Tady ve vesnici se tradují povídky o lidech, kteří se probudí kousek od vesnice, ale nic si nepamatují\"",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 212031, Description = "Takže nejsem jediný ?", NextRoomID = 21204},
                }
            });
            Rooms.Add(21204, new Room()
            {
                RoomID = 21204,
                Description = "\"To rozhodně ne, tady Kryštov je jedním z vás\" ... \"Hele ... nechceš se k nám přidat ? Aspoň na jednu výpravu, naučíme tě pár základům boje\"",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 212041, Description = "To zní skvěle aspoň se dozvím víc o tomhle světě", NextRoomID = 21205},
                }
            });
            Rooms.Add(21205, new Room()
            {
                RoomID = 21205,
                Description = "\"Skvělá zpráva ! Tak poďme ztvrdit toto nové přátelství přípitkem.\"",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 212051, Description = "Tak pojďme na to ! ...", NextRoomID = 21226},
                }
            });
            Rooms.Add(21206, new Room()
            {
                RoomID = 21206,
                Description = "Po 30 minutách říkáš Ctiborovi (vůdci skupiny) že máš dost, jestli by neměl nějaké místo, kde bys mohl přespat. On ti na to odpoví \"Ale jistě běž nahoru po schodech pokoj číslo 5 ... a podal ti klíč\"",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 212061, Description = "Tak zítra Ctibore ... Dobrou", NextRoomID = 23},
                }
            });
            //--Prolog
            Rooms.Add(23, new Room()
            {
                RoomID = 23,
                Description = "Ráno po probuzení přemýšlíš nad snem, který se ti zdál ... al řekneš si \"Byl to jen sen\" a mávneš nad tím rukou",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 230, Description = "Vyrazit na náměstíčko", NextRoomID = 230},
                }
            });
            Rooms.Add(230, new Room()
            {
                RoomID = 230,
                Description = "Při příchodu na náměstí na tebe Ctibor mává, abys šel k nim ... Když k nim dojdeš tak ti říká \"Měli bychom ti obstarat nějaké vybavení, pojď s námi za obchodníkem\"",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2301, Description = "Jít za nimi k obchodníkovi", NextRoomID = 231},
                }
            });
            Rooms.Add(231, new Room()
            {
                RoomID = 231,
                Description = "Obchodník: \"Zdravím vás, přejete si něco koupit ?\" ... Ctibor odpovída: \"tady tento mladík by chtěl svou první zbraň\"",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2310, Description = "Ukaž mi co nabízíš", NextRoomID = 1, Type = RoomType.Shop },
                }
            }); //Obchodník
            Shops.Add(1, new Shop()
            {
                ShopID = 1,
                NextRoomID = 232,
                Description = "Vlevo máš své itemy, které můžeš prodat kliknutím na ně. Na pravé straně si mužeš koupit předměty od obchodníka",
                Reward = new Rewards() { GoldReward = 50, ItemReward = new Item() { Name = "test", Cost = 25, Count = 1, Sellable = true, Description = "test item"} },
                Inventory = new Dictionary<string, Item>() {
                    { "meč", new Item() { Name = "meč", Cost = 2 } }
                }
            });
            Rooms.Add(232, new Room()
            {
                RoomID = 232,
                Description = "Nyní pokud máš vše co potřebuješ můžeme vyrazit ?",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2320, Description = "Ano, pojďme na cestu (neni)", NextRoomID = 233 },
                    new Crossroad() { CrossroadID = 2321, Description = "Ještě nemám vše (z5 k obchodníkovi)", NextRoomID = 1, Type = RoomType.Shop },
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
                BossStats = new Npc() { Name = "Krab", HealthPoints = 20, ManaPoints = 0, Attack = 4, CritChance = 20, Defense = 7, Knowledge = 0},
                Description = $"Tasíš svůj meč a připravuješ se k boji proti Krabovi" });
            Battles.Add(61, new Battle() { BattleID = 2, NextRoomID = 2,
                BossStats = new Npc() { Name = "Krab", HealthPoints = 20, ManaPoints = 0, Attack = 20, Defense = 2, Knowledge = 0 },
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
