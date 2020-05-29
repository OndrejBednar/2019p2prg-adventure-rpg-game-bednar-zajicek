using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                    new Crossroad() { CrossroadID = 0, Description = "Pokračovat", NextRoomID = 1 }
                }
            });
            Rooms.Add(1, new Room()
            {
                RoomID = 1,
                Description = "Probudil ses na louce, nevíš kde ses tu vzal. Po chvíli na tebe začne křičet nějaký neznámý člověk, který vypadá, jako by před něčím utíkal. \"Ty tam, utíkej do vesnice na sever, pokud chceš žít !\"",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 1, Description = "Poslechnout ho a utéct do města", NextRoomID = 2 },
                },
            });
            //--------vesnice(začáteční lokace)--------//
            Rooms.Add(2, new Room()
            {
                RoomID = 2,
                Description = "Doběhl si do vesnice, ale vypadá to, že ten cizinec to nezvládl. Vůbec nevíš, kdo to byl. Nejspíš by ses měl porozhlédnout po vesnici a říct někomu, co se stalo",
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
                    new Crossroad() { CrossroadID = 21201, Description = "Já nevím ...", NextRoomID = 21201},
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
                Description = "\"Tady ve vesnici se tradují povídky o lidech, kteří se probudí poblíž vesnice, ale nic si nepamatují\"",
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
                    new Crossroad() { CrossroadID = 212051, Description = "Tak na zdraví !", NextRoomID = 21206},
                }
            });
            Rooms.Add(21206, new Room()
            {
                RoomID = 21206,
                Description = "Po 30 minutách říkáš Ctiborovi (vůdci skupiny) že máš dost, jestli by neměl nějaké místo, kde bys mohl přespat. On ti na to odpoví \"Ale jistě, běž nahoru po schodech pokoj číslo 5 ... a podal ti klíč\"",
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
                Description = "Vlevo máš své itemy, které můžeš prodat kliknutím na ně. Na pravé straně si mužeš koupit předměty od obchodníka. Ctibor ti dal 50 zlaťáků, aby sis koupil svou zbraň.",
                Reward = new Rewards() { GoldReward = 50},
                Inventory = new Dictionary<string, Item>() {
                    { "Basic Sword", new Item() { BonusStats = new Stats() { Attack = 5, Defense = 2}, Name = "Basic Sword", Description = "Základní meč z kamene pro bojovníky", Cost = 25, Type = ItemType.Weapon } },
                    { "Wood Staff", new Item() { BonusStats = new Stats() { Attack = 5, Spellpower = 2}, Name = "Wood Staff", Description = "Základní luk pro lukostřelce", Cost = 25, Type = ItemType.Weapon } },
                    { "Wooden Bow", new Item() { BonusStats = new Stats() { Attack = 7}, Name = "Wooden Bow", Description = "Základní hůl pro kouzelníky", Cost = 25, Type = ItemType.Weapon } }
                }
            });
            Rooms.Add(232, new Room()
            {
                RoomID = 232,
                Description = "Nyní pokud máš vše co potřebuješ, můžeme vyrazit ?  Odemknul se ti inventář, nasaď si svou novou zbraň",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2320, Description = "Ano, pojďme na cestu", NextRoomID = 233 },
                    new Crossroad() { CrossroadID = 2321, Description = "Ještě nemám vše (zpět k obchodníkovi)", NextRoomID = 1, Type = RoomType.Shop },
                }
            });
            Rooms.Add(233, new Room()
            {
                RoomID = 233,
                Description = "Vyrazili jste společně na louku, kde se to všechno odehrálo ... Po chvíli pátrání po cizinci jste našli stopy krve",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2330, Description = "Pojďme po stopách", NextRoomID = 234},
                    new Crossroad() { CrossroadID = 2331, Description = "Zkusit zavolat na cizince", NextRoomID = 2330},
                }
            });
            Rooms.Add(2330, new Room()
            {
                RoomID = 2330,
                Description = "Na volání nikdo neodpovídá",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 23300, Description = "Pojďme po stopách", NextRoomID = 234},
                    new Crossroad() { CrossroadID = 23301, Description = "Vrátit se do vesnice (přeskočit tutorial)", NextRoomID = 24},
                }
            });
            Rooms.Add(234, new Room()
            {
                RoomID = 234,
                Description = "Krvavá stopa vás zavedla až k jeskyni na konci louky ... Vypadá to na vlčí doupě",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2340, Description = "Jít se podívat dovnitř", NextRoomID = 235},
                    new Crossroad() { CrossroadID = 2341, Description = "Není šance aby tohle přežil", NextRoomID = 2340},
                }
            });
            Rooms.Add(2340, new Room()
            {
                RoomID = 2340,
                Description = "To je sice možné, ale přece se jen tak neotočíme, když už jsme tady",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 23400, Description = "Jít dovnitř", NextRoomID = 235},
                }
            });
            Rooms.Add(235, new Room()
            {
                RoomID = 235,
                Description = "Ctibor ti předtím než jste vlezli do jeskyně dal 5 lečících lektvarů ... Po vstupu do jeskyně jste si potvrdili, že je to vlčí doupě. Vlci si vás všimli a zaútočili",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2350, Description = "Připravit se k boji", NextRoomID = 1, Type = RoomType.Battle},
                },
                Reward = new Rewards() { ItemReward = new Item() { Name = "HealthPotion", Cost = 10, Count = 5, Description = "Tento lektvar ti doplní 25 životů",BonusStats = new Stats() { HealthPoints = 25}, Type = ItemType.Consumable } }
            }); //vlčí doupě
            Battles.Add(1, new Battle()
            {
                BattleID = 1,
                NextRoomID = 236,
                Boss = new Npc() { Name = "Vlk", NpcStats = new Stats() { HealthPoints = 40, Attack = 4, Defense = 2 } },
                Description = "Připravuješ se k boji proti Vlkovi",
                Reward = new Rewards() { ItemReward = new Item() { Name = "Meat", Cost = 10, Count = 2, Description = "Toto maso můžeš sníst pro doplnění 20 životů, nebo prodat u obchodníka", BonusStats = new Stats() { HealthPoints = 20 }, Type = ItemType.Consumable } }
            });
            Rooms.Add(236, new Room()
            {
                RoomID = 236,
                Description = "Zabili jste všechny vlky. Ctibor říká: \"měli bychom se podívat hlouběji\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2360, Description = "Vydat se hlouběji do jeskyně", NextRoomID = 23600},
                    new Crossroad() { CrossroadID = 2361, Description = "Vyčkat na zbytek skupiny u vchodu", NextRoomID = 2360},
                }
            });
            Rooms.Add(23600, new Room()
            {
                RoomID = 23600,
                Description = "Na konci jeskyně jste viděli spoustu kostí je ti jasné, že pokud byl tady tak už není",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 236000, Description = "Tady už nic neuděláme ... vraťme se do vesnice", NextRoomID = 237},
                }
            });
            Rooms.Add(2360, new Room()
            {
                RoomID = 2360,
                Description = "Čekáš na ostatní než se vrátí a mezitím se snažíš si vzpomenout, kdo jsi a co se ti stalo",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 23600, Description = "Čekat než se vrátí", NextRoomID = 2361},
                }
            });
            Rooms.Add(2361, new Room()
            {
                RoomID = 2361,
                Description = "Po návratu se jich ptáš co tam našli. Ctibor zklesle odpoví: \"Našli jsme kosti ... spoustu kostí, pokud byl tady, tak už není\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 23610, Description = "... Pojďme se vrátit do vesnice", NextRoomID = 237},
                }
            });
            Rooms.Add(237, new Room()
            {
                RoomID = 237,
                Description = "Po návratu do vesnice ti Ctibor řekl: \"Ještě dojdeme prodat ty vlky řezníkovi, tak si běž odpočinout, pak ti dám podíl\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2370, Description = "Jít si odpočinout", NextRoomID = 2370},
                }
            });
            Rooms.Add(2370, new Room()
            {
                RoomID = 2370,
                Description = "Když se ráno probudíš tak vedle sebe najdeš 50 zlaťáků",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 23700, Description = "Jít se podívat po ostatních", NextRoomID = 2371},
                    new Crossroad() { CrossroadID = 23701, Description = "Jít na průzkum kolem vesnice", NextRoomID = 2372},
                },
                Reward = new Rewards() { GoldReward = 50 }
            });
            Rooms.Add(2371, new Room()
            {
                RoomID = 2371,
                Description = "Nenašel jsi nikoho, ale hostinský ti řekl, že je viděl odcházet brzy ráno na lov",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 23710, Description = "Jít na průzkum kolem vesnice", NextRoomID = 2372},
                }
            });
            Rooms.Add(2372, new Room()
            {
                RoomID = 2372,
                Description = "Zjistil si, že kousek za vesnicí je les. Odemčena nová lokace: Les",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 23720, Description = "Vydat se do lesa", NextRoomID = 3},
                }
            });
            //--------Les--------//
            Rooms.Add(3, new Room()
            {
                RoomID = 3,
                Description = "Šel jsi podél cesty, až si došel na k rozcestníku",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 30, Description = "Vydat se v pravo", NextRoomID = 30 },
                    new Crossroad() { CrossroadID = 31, Description = "Vydat se v levo", NextRoomID = 31 },
                }
            });
            Rooms.Add(30, new Room()
            {
                RoomID = 30,
                Description = "Šel jsi v pravo ... došel jsi na mýtinu, kde sis všimnul chtátrající chalupy",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 300, Description = "Prozkoumat chátrající chalupu (neni)", NextRoomID = 301 },
                    new Crossroad() { CrossroadID = 301, Description = "Vrátit se na rozcestí", NextRoomID = 3 },
                }
            });
            Rooms.Add(31, new Room()
            {
                RoomID = 31,
                Description = "Šel jsi v levo ... došel jsi na slepý konec, celý zarostlý",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 310, Description = "Vrátit se na rozcestí", NextRoomID = 3 },
                }
            });
            Rooms.Add(301, new Room()
            {
                RoomID = 301,
                Description = "Vešel jsi dovnitř zkrze polorozpadlé dveře a okamžitě sis všiml staříka sedícího poblíž krbu na dřevěné židli ... něco se ti zde nezdá",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 3010, Description = "Oslovit staříka", NextRoomID = 302 },
                    new Crossroad() { CrossroadID = 3010, Description = "Raději odejít", NextRoomID = 3010 },
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
            //--------Testy-------//
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
                Boss = new Npc() { Name = "Krab", NpcStats = new Stats() { HealthPoints = 100, ManaPoints = 0, Attack = 4, CritChance = 0, Defense = 2, Spellpower = 0 } },
                Description = $"Tasíš svůj meč a připravuješ se k boji proti Krabovi" });
            Battles.Add(61, new Battle() { BattleID = 2, NextRoomID = 2,
                Boss = new Npc() { Name = "Krab", NpcStats = new Stats() { HealthPoints = 20, ManaPoints = 0, Attack = 20, Defense = 2, Spellpower = 0 } },
                Description = "Pokusil ses utéct, ale nevyšlo ti to ... Krab útočí" });
            Shops.Add(999, new Shop()
            {
                ShopID = 999,
                NextRoomID = 2,
                Description = "Testovací obchod",
                Inventory = new Dictionary<string, Item>() {
                    { "Divine Bow", new Item() { BonusStats = new Stats() { Attack = 13}, Name = "Divine Bow", Description = "!!! Cheated item !!!", Cost = 0, Type = ItemType.Weapon } },
                    { "Divine Sword", new Item() {  BonusStats = new Stats() { Attack = 10, Defense = 5}, Name = "Divine Sword", Description = "!!! Cheated item !!!", Cost = 0, Type = ItemType.Weapon } }
                }
            });
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
