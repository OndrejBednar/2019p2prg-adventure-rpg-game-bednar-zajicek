# Adventure/Rpg game - Bednář,Zajíček

## Obsah
Statistiky(hráče/nepřátel) - Životy | Mana | Poškození(zbraní, kouzel) | Kritické zásahy(% šance) | Obrana
Hráč -  Inventář
		Kouzla
		Vybavení (zbraň, amulet, brnění)
Obchody
Bitvy
Odměny za vstup do místnosti/bitvy/obchodu

## Použití
Vytvoření místnosti/lokace
```csharp
            Rooms.Add(1 //ID místnosti (1), new Room()
            {
                RoomID = 1, //ID místnosti (1)
                Description = "Popis místnosti",
                Inventory = false, //Pokud nechcete, aby se tlačítko inventáře zobrazilo ve výběru cest
                Crossroads = new List<Crossroad>() {
					new Crossroad() { CrossroadID = 20, Description = "Popis cesty", NextRoomID = ID další místnosti/bitvy/obchodu }, //Type = RoomType.Normal je výchozí hodnota
                    new Crossroad() { CrossroadID = 21, Description = "Popis cesty", NextRoomID = ID další místnosti/bitvy/obchodu, Type = RoomType.Shop }, //Type = RoomType.Shop nastavuje, že další místnost bude obchod
                    new Crossroad() { CrossroadID = 22, Description = "Popis cesty", NextRoomID = ID další místnosti/bitvy/obchodu, Type = RoomType.Battle }, //Type = RoomType.Battle nastavuje, že další místnost bude bitva
					Reward = new Rewards() { 
						ItemReward = new Item() { Name = "HealthPotion", Cost = 10, Count = 5, Description = "Tento lektvar ti doplní 25 životů",BonusStats = new Stats() { HealthPoints = 25}, Type = ItemType.Consumable } }
						//mužeme přidat odměnu za vstup do této místnosti (zlato,item)
                }
            });
```
Vytvoření bitvy
```csharp
Battles.Add(1 //ID boje (1), new Battle()
            {
                BattleID = 1, //ID boje (1)
                NextRoomID = 5, //ID místnosti kam se půjde po boji (5)
                Boss = new Npc() { Name = "Jméno nepřítele", NpcStats = new Stats() { HealthPoints = 40, Attack = 4, Defense = 2, CritChance = 0, ManaPoints = 0, Spellpower = 0 } }, //výchozí hodnoty jsou 0 takže nemusíte nastavovat vše
                Description = "Připravuješ se k boji proti Vlkovi",
                Reward = new Rewards() { 
					ItemReward = new Item() { Name = "Meat", Cost = 10, Count = 2, Description = "Toto maso můžeš sníst pro doplnění 20 životů, nebo prodat u obchodníka", BonusStats = new Stats() { HealthPoints = 20 }, Type = ItemType.Consumable }}
					//mužeme přidat odměnu za vyhraný boj (zlato,item) | v tomto případě BonusStats = new Stats() { HealthPoints = 20 } se vám po použití přičte 20 HP
            });
```
Vytvoření obchodu
```csharp
Shops.Add(1 //ID obchodu (1), new Shop()
            {
                ShopID = 1, //ID obchodu (1)
                NextRoomID = 5, //ID místnosti kam se půjde z obchodu (5)
                Description = "Můžeme přidat popis obchodu",
                Reward = new Rewards() { GoldReward = 50}, //mužeme přidat odměnu za vstup do obchodu (zlato,item)
                Inventory = new Dictionary<string, Item>() {
                    { "Basic Sword", new Item() { BonusStats = new Stats() { Attack = 5, Defense = 2}, Name = "Basic Sword", Description = "Základní meč z kamene pro bojovníky", Cost = 25, Type = ItemType.Weapon } },
                    { "Wood Staff", new Item() { BonusStats = new Stats() { Attack = 5, Spellpower = 2}, Name = "Wood Staff", Description = "Základní hůl pro kouzelníky", Cost = 25, Type = ItemType.Weapon } },
                    { "Wooden Bow", new Item() { BonusStats = new Stats() { Attack = 7}, Name = "Wooden Bow", Description = "Základní luk pro lukostřelce", Cost = 25, Type = ItemType.Weapon } }
					//Příklady přidání 3 zbraní do obchodu | BonusStats = new Stats() { Attack = 7} určuje co vám daná zbraň bude přidávat (to samé platí pro amulet/brnění) výchozí hodnoty jsou 0 takže nemusíte nastavovat vše
                }
            });
```
