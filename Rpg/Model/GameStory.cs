using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class GameStory
    {
        public Dictionary<int, Room> Rooms { get; set; } = new Dictionary<int, Room>();
        public Dictionary<int, Battle> Battles { get; set; } = new Dictionary<int, Battle>();
        public Dictionary<int, Shop> Shops { get; set; } = new Dictionary<int, Shop>();
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
                    { "Wood Staff", new Item() { BonusStats = new Stats() { Attack = 5, Spellpower = 2}, Name = "Wood Staff", Description = "Základní hůl pro kouzelníky", Cost = 25, Type = ItemType.Weapon } },
                    { "Wooden Bow", new Item() { BonusStats = new Stats() { Attack = 7}, Name = "Wooden Bow", Description = "Základní luk pro lukostřelce", Cost = 25, Type = ItemType.Weapon } }
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

            //---4. varianta města
            Rooms.Add(24, new Room()
            {
                RoomID = 24,
                Description = "Když přicházíš na náměsti již se smráká",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 240, Description = "Jít do hospody", NextRoomID = 240},
                    new Crossroad() { CrossroadID = 241, Description = "Jít k obchodníkovi", NextRoomID = 241},
                }
            });
            Rooms.Add(2401, new Room()
            {
                RoomID = 2401,
                Description = "Vrátil ses na náměstí ...",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 240, Description = "Jít do hospody", NextRoomID = 240},
                    new Crossroad() { CrossroadID = 241, Description = "Jít k obchodníkovi", NextRoomID = 241},
                }
            });
            //----hospoda
            Rooms.Add(240, new Room()
            {
                RoomID = 240,
                Description = "Vešel jsi do hospody, porozhlédl se a uviděl jsi Ctibora s jeho partou",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2400, Description = "Jít za nimi", NextRoomID = 2400},
                    new Crossroad() { CrossroadID = 2401, Description = "Pokračovat na pokoj", NextRoomID = 242},
                    new Crossroad() { CrossroadID = 2402, Description = "Vrátit se na náměstí", NextRoomID = 2401},
                },
                Inventory = false
            });
            Rooms.Add(2400, new Room()
            {
                RoomID = 2400,
                Description = "Přisedl sis k nim a zeptal se jak úspěšný byl lov ... Jeden z nich zabrumlal a Ctibor ti odvětil \"Bohužel jsme ho nechytili\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 24000, Description = "Ho ?", NextRoomID = 24000},
                },
                Inventory = false
            });
            Rooms.Add(24000, new Room()
            {
                RoomID = 24000,
                Description = "\"Ano ... pátráme po lidech, kteří něco špatného provedli, ale to je teď jedno ... co si dělal celý den ty ?\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 24000, Description = "Říct jim o staříkovi", NextRoomID = 24001},
                    new Crossroad() { CrossroadID = 24001, Description = "Zalhat", NextRoomID = 240000},
                },
                Inventory = false
            });
            //---rict jim o starikovi
            Rooms.Add(24001, new Room()
            {
                RoomID = 24001,
                Description = "\"Aha to jsi měl teda velice náročný den\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 240010, Description = "Říct jim o dopisu", NextRoomID = 24002, Locked = true},
                    new Crossroad() { CrossroadID = 240011, Description = "Zeptat se jestli nevědí kdo je Eret", NextRoomID = 24003},
                    new Crossroad() { CrossroadID = 240012, Description = "Přikývnout a rozloučit se", NextRoomID = 242},
                },
                Inventory = false
            });
            Rooms.Add(24002, new Room()
            {
                RoomID = 24002,
                Description = "\"Nejspíš by jsi měl nalézt tu slečnu o které se v dopisu píše\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 240011, Description = "Zeptat se jestli nevědí kdo je Eret", NextRoomID = 24003},
                    new Crossroad() { CrossroadID = 240012, Description = "Rozloučit se a jít spát", NextRoomID = 242},
                },
                Inventory = false,
            });
            Rooms.Add(24003, new Room()
            {
                RoomID = 24003,
                Description = "\"Jak jsi se o něm dozvěděl ??\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 240012, Description = "Stařík o něm mluvil", NextRoomID = 24005},
                    new Crossroad() { CrossroadID = 240012, Description = "Slyšel jsem jak se o něm baví vesničané (zalhat)", NextRoomID = 24006},
                },
                Inventory = false,
            });
            Rooms.Add(24005, new Room()
            {
                RoomID = 24005,
                Description = "\"Kolují zvěsti, že je to muž, kterému patří celý vzdálený východ za řekou a také může za vše špatné co se děje ve městě\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 240050, Description = "Rozloučit se a jít spát", NextRoomID = 242},
                },
                Inventory = false,
            });
            Rooms.Add(24006, new Room()
            {
                RoomID = 24006,
                Description = "\"Kolují zvěsti, že může za vše špatné co se děje ve městě\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 240060, Description = "Rozloučit se a jít spát", NextRoomID = 242},
                },
                Inventory = false,
            });
            //---zalhat o starikovi
            Rooms.Add(240000, new Room()
            {
                RoomID = 240000,
                Description = "Říkáš jim \"Byl jsem na louce za vesnicí a znovu hledal cizince\" ... Ctibor se zeptá \"A co si našel ?\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2400000, Description = "Nic, až na stopy, které zmizely ve křoví", NextRoomID = 240001},
                },
                Inventory = false
            });
            Rooms.Add(240001, new Room()
            {
                RoomID = 240001,
                Description = "\"Teď jdeme spát ... Derek už vypil 10 piv. Zítra se po něm můžeme znovu podívat .. jestli chceš\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2400010, Description = "Jít také spát", NextRoomID = 242},
                },
                Inventory = false
            });

            Rooms.Add(242, new Room()
            {
                RoomID = 242,
                Description = "Jdeš po schodech do pokoje a všiml sis znaku na zdi který vypadal stejně jako na staříkově hrudi. Jen sis ho prohlédl a pokračoval na pokoj, kde jsi po náročném dni ihned usnul",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2420, Description = "...", NextRoomID = 243},
                },
                Inventory = false
            });
            Rooms.Add(243, new Room()
            {
                RoomID = 243,
                Description = "Ze spánku tě v hluboké noci probudil hluk z venčí, a tak si se podíval z okna, kde jsi uviděl černě zahalené postavy s kápí na hlavě, jak okrádají obchodníka",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2430, Description = "...", NextRoomID = 244},
                },
                Inventory = false
            });
            Rooms.Add(244, new Room()
            {
                RoomID = 244,
                Description = "",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2440, Description = "...", NextRoomID = 245},
                },
                Inventory = false
            });

            //----obchodník
            Rooms.Add(241, new Room()
            {
                RoomID = 241,
                Description = "Dobrý podvěčír, nevíte něco o staříkovi, který bydlí v chatrči v lese ? Obchodník odpoví \"Proč se ptáte ?\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 2410, Description = "Říci pravdu", NextRoomID = 2410},
                    new Crossroad() { CrossroadID = 2411, Description = "Dnes jsem ho potkal (zalhat)", NextRoomID = 2411},
                },
                Inventory = false
            });
            Rooms.Add(2410, new Room()
            {
                RoomID = 2410,
                Description = "\"Aha, měli bychom tam poslat vesnickou stráž. Byl to příslušník řádu Aurelion.\" Pomyslíš si \"To by mohlo vysvětlit ten znak na hrudi\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 24100, Description = "Dozvědět se víc o řádu Aurelion", NextRoomID = 2411},
                    new Crossroad() { CrossroadID = 24101, Description = "Poděkovat a odejít do hospody", NextRoomID = 240},
                    new Crossroad() { CrossroadID = 24102, Description = "Podívat se co nabízíš", NextRoomID = 2, Type = RoomType.Shop},
                },
                Inventory = false
            });
            Rooms.Add(2411, new Room()
            {
                RoomID = 2411,
                Description = "\"Je to velmi prastarý řád mágů, kteří mají velmi drahocenné vědění o totemech magie, které jim dávají velikou moc, kterou si obyčejný člověk nedokáže představit, ale je jich v dnešním světě mnohem méně, protože Eret chce znát jejich vědění a proto je chytá a vraždí\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 24110, Description = "Dozvědět se více o Eretovi", NextRoomID = 2412},
                    new Crossroad() { CrossroadID = 24111, Description = "Poděkovat a odejít do hospody", NextRoomID = 240},
                    new Crossroad() { CrossroadID = 24112, Description = "Podívat se co nabízíš", NextRoomID = 2, Type = RoomType.Shop},
                },
                Inventory = false
            });
            Rooms.Add(2412, new Room()
            {
                RoomID = 2412,
                Description = "\"Moc o něm nevím jen to, že může za vše špatného, co se děje ve vesnici\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 24121, Description = "Poděkovat a odejít do hospody", NextRoomID = 240},
                    new Crossroad() { CrossroadID = 24122, Description = "Podívat se co nabízíš", NextRoomID = 2, Type = RoomType.Shop},
                },
                Inventory = false
            });
            Shops.Add(2, new Shop()
            {
                ShopID = 2,
                NextRoomID = 240,
                Description = "Moje štědrá nabídka předmětů",
                Inventory = new Dictionary<string, Item>() {
                    { "Basic Sword", new Item() { BonusStats = new Stats() { Attack = 5, Defense = 2}, Name = "Basic Sword", Description = "Základní meč z kamene pro bojovníky", Cost = 25, Type = ItemType.Weapon } },
                    { "Wood Staff", new Item() { BonusStats = new Stats() { Attack = 5, Spellpower = 2}, Name = "Wood Staff", Description = "Základní hůl pro kouzelníky", Cost = 25, Type = ItemType.Weapon } },
                    { "Wooden Bow", new Item() { BonusStats = new Stats() { Attack = 7}, Name = "Wooden Bow", Description = "Základní luk pro lukostřelce", Cost = 25, Type = ItemType.Weapon } },
                    { "HealthPotion", new Item() { Name = "HealthPotion", Cost = 10, Count = 5, Description = "Tento lektvar ti doplní 25 životů", BonusStats = new Stats() { HealthPoints = 25}, Type = ItemType.Consumable } },
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
                Description = "Šel jsi v pravo ... došel jsi na mýtinu, kde sis všimnul chtátrající chatrče",
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
                Description = "Vešel jsi dovnitř zkrze polorozpadlé dveře a všiml sis zakrváceného staříka ležícího uprostřed místnosti s vážným zraněním na břiše a nožem v ruce",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 3010, Description = "Zkusit pomoci staříkovi", NextRoomID = 302 },
                    new Crossroad() { CrossroadID = 3011, Description = "Raději odejít", NextRoomID = 3010 },
                }
            });
            //----1.varianta
            Rooms.Add(302, new Room()
            {
                RoomID = 302,
                Description = "Rozeběhl ses ke stařikovi a přitiskl jsi ruku na jeho ránu na břiše. Stařík ti s těžkostí říká \"To mi udělal Erot \". Poté stařík vydechl naposledy",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 3020, Description = "Porozhlédnou se po chatrči", NextRoomID = 303 },
                    new Crossroad() { CrossroadID = 3021, Description = "Prohledat staříka", NextRoomID = 304 },
                    new Crossroad() { CrossroadID = 3022, Description = "Raději odejít a vrátit se do města", NextRoomID = 24 },
                }
            });
            Rooms.Add(303, new Room()
            {
                RoomID = 303,
                Description = "Porozhlédl ses po chatrči a bylo ti hned jasné, že tam někdo něco hledal a staříka tam dotyčný neočekával",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 3030, Description = "Prohledat staříka", NextRoomID = 304 },
                    new Crossroad() { CrossroadID = 3031, Description = "Odejít z chatrče", NextRoomID = 24 },
                }
            });
            Rooms.Add(304, new Room()
            {
                RoomID = 304,
                Description = "Ještě předtím než jsi ho prohleda tak sis všiml, že má pod roztrhaným tričkem na hrudníku nějaký znak ... poté si u něj našel zapečetěný dopis",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 3041, Description = "Odejít z chatrče a vyrazit do města", NextRoomID = 24 },
                },
                Reward = new Rewards() { ItemReward = new Item() { Name = "Zapečetěný dopis", Description = "Dopis který jsi nalezl u staříka", Sellable = false} }
            });
            //----2.varianta
            Rooms.Add(3010, new Room()
            {
                RoomID = 3010,
                Description = "Rychlým krokem odcházíš pryč se strachem v očích a z chatrče slyšíš staříka naříkat \"To byl Erot\"",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 30100, Description = "Vrátit se do města", NextRoomID = 24 },
                    new Crossroad() { CrossroadID = 30101, Description = "Jít zpět do chatrče", NextRoomID = 303 },
                }
            });




            //--------Jeskyně--------//s
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
