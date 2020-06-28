using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class GameStory2
    {
        public Dictionary<int, Room> Rooms { get; set; } = new Dictionary<int, Room>();
        public Dictionary<int, Battle> Battles { get; set; } = new Dictionary<int, Battle>();
        public Dictionary<int, Shop> Shops { get; set; } = new Dictionary<int, Shop>();
        public GameStory2()
        {
            //--------Tutorial--------//
            Rooms.Add(0, new Room() {
                RoomID = 0,
                Description = "Právě se nacházíš v tutoriálové místnosti.",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 0, Description = "Pokračovat", NextRoomID = 1 }
                }
            });
            Rooms.Add(1, new Room()
            {
                RoomID = 1,
                Description = "Vůbec nevíš kde jsi a jak jsi se tu ocitl. Jediný co si pamatuješ je, že jsi včera večer usnul s nohama na stole, když jsi sledoval hokej. Při snaze vstát se ti divně klepou nohy... V dáli vidíš vesnici, tak se do ní rozhodneš vydat.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 1, Description = "Vydat se do vesnice", NextRoomID = 2 },
                },
            });
            //--------vesnice(začáteční lokace)--------//
            Rooms.Add(2, new Room()
            {
                RoomID = 2,
                Description = "Pomalu procházíš vesnicí. Dojdeš až na náměstí, je liduprázdné a vedle kašny je stará mapa. Pozorně se na ni podíváš a vidíš nějaké divné ostrovy ve vzduchu... Co to sakra je???",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 3, Description = "Prozkoumat mapu", NextRoomID = 3 },
                    new Crossroad() { CrossroadID = 4, Description = "Prohlédnout si fontánu", NextRoomID = 1000 },
                }
            });
            Rooms.Add(1000, new Room()
            {
                RoomID = 1000,
                Description = "Prohlédl sis fontánu a našel v ní 5 zlaťáků!",
                Inventory = false,
                Reward = new Rewards() { GoldReward = 5 },
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 5, Description = "Prozkoumat mapu", NextRoomID = 3},
                }
            });
            Rooms.Add(3, new Room()
            {
                RoomID = 3,
                Description = ",,Nacházíš se na hlavním ostrově. Zde se nachází vesnice, farma, Železné doly, les a hřbitov.´´ říká mapa. V zápětí ti dojde, co bylo s tvýma nohama, když jsi se pokusil vstát - je tu jiná gravitace a jsi ve vzduchu na nějakém podivném ostrově!",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 5, Description = "...", NextRoomID = 4},
                }
            });
            Rooms.Add(4, new Room()
            {
                RoomID = 4,
                Description = "Stále nerozumíš tomu, co se děje a jak jsi se tu ocitl. Pro jistotu se štípneš do ramene... bez výsledku, neprobudil ses. Najednou zezadu slyšíš hlasité 'Hej ty! Jo ty! Co tu sakra děláš v tuhle hodinu?? To se nebojíš draků?'.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 6, Description = "Draků?", NextRoomID = 5 },
                    new Crossroad() { CrossroadID = 7, Description = "Já se nebojím chlape", NextRoomID = 6 },
                }
            });
            Rooms.Add(5, new Room()
            {
                RoomID = 5,
                Description = "'Jo, draků', odpoví vesničan. 'Předevčírem se tu jeden objevil a ukradl nám všechna zvířata z pastvin a zapálil stodolu'.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 8, Description = "Nabídnout pomocnou ruku", NextRoomID = 7},
                    new Crossroad() { CrossroadID = 9, Description = "Těmhle povídačkám nevěřím", NextRoomID = 8},
                }
            });
            Rooms.Add(6, new Room()
            {
                RoomID = 6,
                Description = "'Oooo, tak to pozooor, pán je ze zdola, tak si hned myslí, že je nesmrtelnej... Tady seš v Létákově brácho, tady machry házet nebudeš. Běž raději do hospody, tam patříš drzoto'.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 10, Description = "Jít do hospody", NextRoomID = 9},
                }
            });
            Rooms.Add(7, new Room()
            {
                RoomID = 7,
                Description = "(V hlavě se ti vybavuje, jak jsi kolil bestie v Metinu a zvýší se ti lehce ego) 'Rád bych vám tu pomohl se toho draka zbavit', odpovíš vesničanovi.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 11, Description = "...", NextRoomID = 10},
                }
            });
            Rooms.Add(8, new Room()
            {
                RoomID = 8,
                Description = "Vysměješ se mu do obličeje a v koutku oka spatříš poutací ceduli s pivem... Konečně, pivo už ti chybělo!",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 12, Description = "Jít do hospody", NextRoomID = 9},
                }
            });
            Rooms.Add(9, new Room()
            {
                RoomID = 9,
                Description = "Vlezeš do staré knajpy a usadíš se k volnému stolu v rohu. Za chvíli k tobě přijde mladá pohledná slečna a zeptá se tě, co bys rád.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 13, Description = "Pívo prosím!", NextRoomID = 110, Type = RoomType.Shop},
                }
            });
            Rooms.Add(10, new Room()
            {
                RoomID = 10,
                Description = "'No, tak jestli nám chceš pomoct, tak ti o tom třeba řeknou něco v hospodě'",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 9, Description = "Jít do hospody", NextRoomID = 9},
                }
            });
            Shops.Add(110, new Shop()
            {
                ShopID = 110,
                NextRoomID = 12,
                Description = "Vlevo máš své itemy, které můžeš prodat kliknutím na ně. Na pravé straně si mužeš koupit předměty od obchodníka.",
                Inventory = new Dictionary<string, Item>() {
                    { "Pívo", new Item() { BonusStats = new Stats() { HealthPoints = 20 }, Type = ItemType.Consumable, Name = "Pívo", Description = "Toto maso můžeš sníst pro doplnění 20 životů, nebo prodat u obchodníka", Cost = 6} },
            }
            });
            Rooms.Add(12, new Room()
            {
                RoomID = 12,
                Description = "Sáhneš do kapsy a... ejhle... nemáš na něj... 😞. Servírka si toho všimne a řekne ti, že je tu možnost, jak mít všechno pívo zdarma!",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 14, Description = "Jsem jedno ucho", NextRoomID = 11},
                }
            });
            Rooms.Add(11, new Room()
            {
                RoomID = 11,
                Description = "'Lítá tu drak a moc se ho bojíme. Celé pole je zničené a zvířata jsou taky pryč. Prý má doupě někde v horách... Hrdinovi co ho zabije a zachrání vesnici, naše hospoda naleje vždy zdarma... A tobě fešáku... tobě bych za to i ňadro ukázala 😉'.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 15, Description = "Nelze odmítnout!", NextRoomID = 13},
                }
            });
            Rooms.Add(13, new Room()
            {
                RoomID = 13,
                Description = "Tak to... to je ta nejlepší nabídka! Jsi ve snu, máš pívo zadáčo a k tomu bonus... musíš draka zabít, ihned!",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 16, Description = "Porozhlédnout se po hospodě", NextRoomID = 14},
                    new Crossroad() { CrossroadID = 17, Description = "Vydat se ven z hospody", NextRoomID = 15},
                }
            });
            Rooms.Add(14, new Room()
            {
                RoomID = 14,
                Description = "Nemůžeš ale odejít bez zbraně. A tamhleten ožrala jednu má... starej dřevěnej meč...",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 18, Description = "Ukrást ho a zmizet", NextRoomID = 16},
                }
            });
            Rooms.Add(15, new Room()
            {
                RoomID = 15,
                Description = "Vyjdeš ven a mezitím už se setmělo... jdeš podél hospody a najednou... ",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 19, Description = "...", NextRoomID = 17, Type = RoomType.Battle},
                }
            });
            Rooms.Add(16, new Room()
            {
                RoomID = 16,
                Description = "Povedlo se! Ani si tě nevšiml, a ty tak můžeš pokračovat dál cestou necestou k zabití draka...",
                Inventory = true,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 20, Description = "Jít k lesu", NextRoomID = 18},
                },
                Reward = new Rewards()
                {
                    ItemReward = new Item() { Name = "Basic Sword", Cost = 3, Description = "Meč, který jsi ukradl šupákovi z hospody", BonusStats = new Stats() { Attack = 5, Defense = 2 }, Type = ItemType.Weapon },
                    GoldReward = 2
                }
            });
            Battles.Add(17, new Battle()
            {
                BattleID = 17,
                NextRoomID = 18,
                Boss = new Npc() { Name = "křupan", NpcStats = new Stats() { HealthPoints = 40, Attack = 4, Defense = 2, CritChance = 0, ManaPoints = 0, Spellpower = 0 } },
                Description = "Těžkej fight s křupem.",
                Reward = new Rewards()
                {
                    ItemReward = new Item() { Name = "Meat", Cost = 10, Count = 2, Description = "Pozůstatek křupana", BonusStats = new Stats() { HealthPoints = 20 }, Type = ItemType.Consumable },
                    GoldReward= 1
                }            
            });
            Rooms.Add(18, new Room()
            {
                RoomID = 18,
                Description = "Dobrá tedy... máš vše, co potřebuješ. Teď už jenom dojít po cestě k horám.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 21, Description = "Vydat se klikatou cestičkou dál", NextRoomID = 120},
                }
            });
            Rooms.Add(120, new Room()
            {
                RoomID = 120,
                Description = "Po cestě jsi našel starou chaloupku, vydáš se dovnitř a vypadá to jako kovárna :O.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 22, Description = "Prozkoumat kovárnu a promluvit si s tím tupcem za pultem", NextRoomID = 121},
                }
            });
            Rooms.Add(121, new Room()
            {
                RoomID = 121,
                Description = "Ten tupec za pultem ti řekl, že ti nabídne jakoukoliv zbraň budeš chtít, když mu slíbíš, že dokážeš porazit draka... A jelikož jsi hrál i Drakensang a máš ty sKilLz, tak si nějakou vybereš. Některé jsou však až moc OuPé a musíš si připlatit pár zlaťáků.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 23, Description = "Jít si vybrat zbraň", NextRoomID = 122, Type = RoomType.Shop},
                }
            });
            Shops.Add(122, new Shop()
            {
                ShopID = 122,
                NextRoomID = 20,
                Description = "Vlevo máš své itemy, které můžeš prodat kliknutím na ně. Na pravé straně si mužeš koupit předměty od obchodníka.",
                Inventory = new Dictionary<string, Item>() {
                    { "Wood Staff", new Item() { BonusStats = new Stats() { Attack = 5, Spellpower = 2}, Name = "Wood Staff", Description = "Kus větve, se kterou sis hrál jako mladej a udělal sis z ní imaginární zbraň", Type = ItemType.Weapon } },
                    { "Wooden Bow", new Item() { BonusStats = new Stats() { Attack = 7}, Name = "Wooden Bow", Description = "Luk z Číny", Type = ItemType.Weapon } },
                    { "Divine Sword", new Item() { BonusStats = new Stats() { Attack = 7}, Cost = 6 ,Name = "Divine Sword", Description = "Mega najetej mečík", Type = ItemType.Weapon } },
                    { "Divine Bow", new Item() { BonusStats = new Stats() { Attack = 7}, Cost = 6 ,Name = "Divine Bow", Description = "Luk z Ameriky obsahující palebnou sílu celé armády USA", Type = ItemType.Weapon } },
            }
            }); ; ;
            Rooms.Add(20, new Room()
            {
                RoomID = 20,
                Description = "Vydáváš se podél temného lesíka směrem k horám... jde vidět, že tu dlouho nikdo nebyl. Cesta je zarostlá a ty pochybuješ, že v tom lese něco žije... Najednou se před tebou objeví rozcestí... kudma asi půjdeš?",
                Inventory = true,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 24, Description = "Jít doleva", NextRoomID = 21},
                    new Crossroad() { CrossroadID = 25, Description = "Jít doprostřed", NextRoomID = 22},
                    new Crossroad() { CrossroadID = 26, Description = "Jít doprava", NextRoomID = 29},
                }
            });
            Rooms.Add(21, new Room()
            {
                RoomID = 21,
                Description = "Pokračuješ cestičkou dál a najednou vidíš, že cesta končí... Otočíš se, ale co to??! Cesta za tebou zarostla a porost tě pomalu obkličuje... ",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 27, Description = "...", NextRoomID = 130, Type = RoomType.Battle},
                }
            });
            Battles.Add(130, new Battle()
            {
                BattleID = 130,
                NextRoomID = 29,
                Boss = new Npc() { Name = "křovák", NpcStats = new Stats() { HealthPoints = 100, Attack = 10, Defense = 2, CritChance = 2, ManaPoints = 0, Spellpower = 0 } },
                Description = "Připravuješ se k boji proti křovákovi",
            });
            Rooms.Add(22, new Room()
            {
                RoomID = 22,
                Description = "Pokračuješ klikatou cestičkou dál a dojdeš až k hnusné jeskyni, plné pavučin a pavouků... Za tebou zmizela cesta,ten tajemný les si roste jak chce, otočíš se zpátky směrem k jeskyni a stojí před ní obrovský pavouk.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 28, Description = "Bojovat s ním", NextRoomID = 23, Type = RoomType.Battle},
                }
            });
            Battles.Add(23, new Battle()
            {
                BattleID = 23,
                NextRoomID = 25,
                Boss = new Npc() { Name = "pavouk", NpcStats = new Stats() { HealthPoints = 75, Attack = 7, Defense = 0, CritChance = 2, ManaPoints = 0, Spellpower = 0 } },
                Description = "Připravuješ se k boji proti pavoukovi",
            });
            Rooms.Add(25, new Room()
            {
                RoomID = 25,
                Description = "Pavouka jsi porazil a teď se můžeš vydat jeskyní dál.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 30, Description = "Pokračovat v tůře přes jeskyni", NextRoomID = 27},
                }
            });
            Rooms.Add(27, new Room()
            {
                RoomID = 27,
                Description = "Vejdeš do jeskyně a proplahočíš se tím vším pavoučím hnusem až skoro na druhou stranu.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 31, Description = "Jít dál", NextRoomID = 44},
                }
            });
            Rooms.Add(44, new Room()
            {
                RoomID = 44,
                Description = "Vypadá to, že těm pavoukům není konec... před tebou se znenadání objevuje obří tarantule a tebe obklíčilo něco, co vypadá jako její vojsko...",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 32, Description =  "Vyjednávat", NextRoomID = 45},
                    new Crossroad() { CrossroadID = 33, Description =  "Nadělat si do trenek", NextRoomID = 48}
                }
            });
            Rooms.Add(45, new Room()
            {
                RoomID = 45,
                Description = "Pavouk si vyslechl tvůj příběh a uznává, že jsi krutý a velice (PŘEVELICE!!!!!!!) silný (A HLAVNĚ MUŽNÝ!!!!!) válečník, se kterým si není radno si zahrávat. Nechává tě tak projít, ale pouze jen, když porazíš jeho nejsilnějšího pavouka v souboji.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 34, Description = "Takzvaně 'fajtit' (fightit)", NextRoomID = 46, Type = RoomType.Battle},
                }
            });
            Rooms.Add(48, new Room()
            {
                RoomID = 48,
                Description = "Dobrej tah... Nebo bych měl říct dobře zahráno (zahnáno)? Všichni pavouci utekli a ty pokračuješ dále jeskyní.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 35, Description = "Pokračovat jeskyní", NextRoomID = 28},
                }
            });
            Battles.Add(46, new Battle()
            {
                BattleID = 46,
                NextRoomID = 28,
                Boss = new Npc() { Name = "tarantulák", NpcStats = new Stats() { HealthPoints = 25, Attack = 5, Defense = 5, CritChance = 2, ManaPoints = 0, Spellpower = 0 } },
                Description = "Připravuješ se k boji proti tarantulákovi",
            });
            Rooms.Add(28, new Room()
            {
                RoomID = 28,
                Description = "Snad sis vybral správně... před sebou vidíš cestičku... yay.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 36, Description = "Jít dál svou cestou necestou", NextRoomID = 30},
                }
            });
            Rooms.Add(29, new Room()
            {
                RoomID = 29,
                Description = "Po cestičce pokračuješ dál a nalevo vidíš východ z jeskyně... fuj... tam snad nikdy nebudeš muset jít.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 37, Description = "Jít dál svou cestou necestou", NextRoomID = 30}
                }
            });
            Rooms.Add(30, new Room()
            {
                RoomID = 30,
                Description = "Došels až na konec lesa a vidíš před sebou obrovskou horu... sakra... Je zde stará a opuštěná hornická osada a vede z ní cestička až k zdárnému vrcholu... Je tu ale taky na první pohled víc nebezpečná cesta skrz šachtu.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 38, Description = "Jít šachtou", NextRoomID = 31},
                    new Crossroad() { CrossroadID = 39, Description = "Jít cestičkou", NextRoomID = 32},
                }
            });
            Rooms.Add(31, new Room()
            {
                RoomID = 31,
                Description = "Vlezeš do temné šachty a plahočíš se dál na vrchol. Po cestě jsi našel starej výtah, a tak do něj nasedneš a pohodlně se svezeš do posledního patra šachet. Na konci cesty vidíš východ.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 40, Description = "Vyjít ze šachty", NextRoomID = 37},
                }
            });
            Rooms.Add(32, new Room()
            {
                RoomID = 32,
                Description = "Vydal ses po stráni směrem k vrcholu... Najednou však slyšíš strašlivý řev draka: AAAAAAAAAAAAAAAAAAAAAAAAHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH (představ si zvuk draka).",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 41, Description = "Schovat se za kámen", NextRoomID = 33},
                }
            });
            Rooms.Add(33, new Room()
            {
                RoomID = 33,
                Description = "Rychle se schováš za kámen a v tu chvíli nad tebou přeletí drak... naštěstí si tě nevšiml a ty vidíš, jak letí směrem k vrcholu - tam kde má své hnízdo.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 42, Description = "Pokračovat na horu", NextRoomID = 35},
                }
            });
            Rooms.Add(35, new Room()
            {
                RoomID = 35,
                Description = "Drak odlétl a ty tak můžeš jít dál směrem k hnízdu...",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 43, Description = "Vyšplhat už skoro poslední převis", NextRoomID = 36},
                }
            });
            Rooms.Add(36, new Room()
            {
                RoomID = 36,
                Description = "Dokázal jsi to... jsi skoro na vrcholu, teď už jen poslední kopa šutrů a jsi u něj",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 44, Description = "Dojít ke hnízdu", NextRoomID = 37},
                }
            });
            Rooms.Add(37, new Room()
            {
                RoomID = 37,
                Description = "Došel jsi úspěšně ke hnízdu, drak vypadá že spí... Teď co s tím?",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 45, Description = "Být férový a před bojem ho vzbudit", NextRoomID = 999, Type = RoomType.Battle},
                }
            });
            Battles.Add(999, new Battle()
            {
                BattleID = 999,
                NextRoomID = 38,
                Boss = new Npc() { Name = "drak", NpcStats = new Stats() { HealthPoints = 250, Attack = 2, Defense = 8, CritChance = 0, ManaPoints = 0, Spellpower = 0 } },
                Description = "Připravuješ se k boji proti drakovi",
            });
            Rooms.Add(38, new Room()
            {
                RoomID = 38,
                Description = "Drak ani neudělal ble a je po něm. Huráááááá!",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 46, Description = "Vydat se nazpátek do vesnice", NextRoomID = 39},
                }
            });
            Rooms.Add(39, new Room()
            {
                RoomID = 39,
                Description = "Tak jsi to dokázal... Zabil jsi toho draka... Teď už jen hurá do vesnice...Pro tu odměnu.",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 47, Description = "Vydat se pro odměnu", NextRoomID = 40},
                }
            });
            Rooms.Add(40, new Room()
            {
                RoomID = 40,
                Description = "Znenadání se ti však začnou zavírat oči... blouzníš a spadneš na zem... probouzíš se u svého stolu, doma a s hokejem v telce.... zvláštní to sen...",
                Inventory = false,
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 48, Description = "...", NextRoomID = 888},
                }
            });


            //---VÝHRA---//
            Rooms.Add(888, new Room()
            {
                RoomID = 888,
                Description = "Vyhrál jsi a nyní mužeš:",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 666, Description = "Hrát znovu", NextRoomID = 1},
                }
            });


            //---SMRT---//
            Rooms.Add(666, new Room()
            {
                RoomID = 666,
                Description = "Zemřel jsi krutou a ošklivou smrtí... nyní mužeš:",
                Crossroads = new List<Crossroad>() {
                    new Crossroad() { CrossroadID = 666, Description = "Hrát znovu", NextRoomID = 1},
                }
            });
        }
    }
}

/*Rooms.Add(21, new Room()
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
});*/
//---------SMRT--------//
