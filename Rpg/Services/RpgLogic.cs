using Rpg.Model;
using System;
using System.Collections.Generic;

namespace Rpg.Services
{
    public class RpgLogic
    {
        readonly Random _rand;
        readonly SessionStorage _session;
        readonly GameStory _gs;

        public Room Rooms { get; set; }
        public Battle BattleRoom { get; set; }
        public Shop ShopRoom { get; set; }
        public Npc Npc { get; set; }
        public Player Player { get; set; }
        public int PlayerDmg { get; set; }
        public int NpcDmg { get; set; }
        public bool PlayerIsCritical { get; set; }
        public bool NpcIsCritical { get; set; }

        public RpgLogic(SessionStorage ss, GameStory gs, Random rand)
        {
            _rand = rand;
            _session = ss;
            _gs = gs;
            BattleRoom = _session.BattleRoom;
            ShopRoom = _session.ShopRoom;

            Player = _session.Player;
            if (Player == default) { Player = new Player(); }

            Npc = _session.Npc;
        }

        public Room Play(int id)
        {
            Rooms = _gs.Rooms[id];
            _session.SetRoomId(id);
            if (Rooms.Reward != null)
            {
                if (Rooms.Reward.GoldReward != 0) { Player.Gold += Rooms.Reward.GoldReward; Rooms.Reward.GoldReward = 0; }
                if (Rooms.Reward.ItemReward != null) { Player.Inventory.Add(Rooms.Reward.ItemReward); Rooms.Reward.ItemReward = null; }
            }
            _session.SavePlayerStats(Player);
            return Rooms;
        }
        public Battle Battle(int id)
        {
            BattleRoom = _gs.Battles[id];
            Npc = BattleRoom.Boss;
            _session.SavePlayerStats(Player);
            _session.SaveNpcStats(Npc);
            _session.SetRoomId(id);
            _session.SaveBattle(BattleRoom);
            return BattleRoom;
        }
        public string Battle(BattleChoice choice)
        {
            string result = "";
            int rand;
            switch (choice)
            {
                case BattleChoice.None:
                    break;
                case BattleChoice.Attack:
                    rand = _rand.Next(100);
                    PlayerIsCritical = Player.PlayerStats.CritChance >= rand ? true : false;
                    PlayerDmg = Player.PlayerStats.CritChance >= rand ? (Player.PlayerStats.Attack * 2) - Npc.NpcStats.Defense : Player.PlayerStats.Attack - Npc.NpcStats.Defense;
                    if (PlayerDmg > 0) { Npc.NpcStats.HealthPoints = Npc.NpcStats.HealthPoints - PlayerDmg; }

                    if (Npc.NpcStats.HealthPoints > 0)
                    {
                        rand = _rand.Next(100);
                        NpcIsCritical = Npc.NpcStats.CritChance >= rand ? true : false;
                        NpcDmg = Npc.NpcStats.CritChance >= rand ? (Npc.NpcStats.Attack * 2) - Player.PlayerStats.Defense : Npc.NpcStats.Attack - Player.PlayerStats.Defense;
                        if (NpcDmg > 0) { Player.PlayerStats.HealthPoints = Player.PlayerStats.HealthPoints - NpcDmg; }
                    }


                    if (PlayerIsCritical)
                    {
                        if (PlayerDmg < 1) { result = $"Dal jsi do toho útoku všechno ... ale bohužel si {Npc.Name}a minul X"; }
                        else { result = $"Dal jsi do toho útoku všechno ... daří se ti zasadit {Npc.Name}ovi kritický zásah za {PlayerDmg} bodů poškození X"; }
                    }
                    else
                    {
                        if (PlayerDmg < 1) { result = $"Útočíš na {Npc.Name}a ... ale bohužel si {Npc.Name}a minul X"; }
                        else { result = $"Útočíš na {Npc.Name}a ... Působíš {Npc.Name}ovi {PlayerDmg} bodů poškození X"; }
                    }
                    if (NpcIsCritical)
                    {
                        if (NpcDmg < 1) { result += $" {Npc.Name} se ti pokusil zasadit kritický zásah ... ale neprošel přes tvou obranu"; }
                        else { result += $" {Npc.Name}ovi se podarilo ti zasadit kritický zásah za {NpcDmg} bodů poškození "; }
                    }
                    else
                    {
                        if (NpcDmg < 1) { result += $" {Npc.Name} na tebe útočí ... ale neprošel přes tvou obranu"; }
                        else { result += $" {Npc.Name} na tebe útočí ... a způsobuje {NpcDmg} bodů poškození"; }
                    }
                    break;
                case BattleChoice.Defend:
                    rand = _rand.Next(100);
                    Player.PlayerStats.Defense += (Player.PlayerStats.Defense / 2);
                    NpcIsCritical = Npc.NpcStats.CritChance >= rand ? true : false;
                    NpcDmg = Npc.NpcStats.CritChance >= rand ? (Npc.NpcStats.Attack * 2) - Player.PlayerStats.Defense : Npc.NpcStats.Attack - Player.PlayerStats.Defense;
                    if (NpcDmg > 0) { Player.PlayerStats.HealthPoints = Player.PlayerStats.HealthPoints - NpcDmg; }

                    if (NpcIsCritical)
                    {
                        if (NpcDmg < 1) { result = $"{Npc.Name} se ti pokusil zasadit kritický zásah ... Tobě se ho však podařilo plně vykrít"; }
                        else { result = $"{Npc.Name}ovi se podařilo zasadit ti kritický zásah který způsobuje {NpcDmg} bodů poškození"; }
                    }
                    else
                    {
                        if (NpcDmg < 1) { result = $"Úspěšně jsi vykril {Npc.Name}ův útok "; }
                        else { result = $"Snažíš se ubránit {Npc.Name}ovi ale {Npc.Name} způsobuje {NpcDmg} bodů poškození"; }
                    }

                    break;
                default:
                    break;
            }
            if (Npc.NpcStats.HealthPoints < 1 && BattleRoom.Reward != null)
            {
                Player.Gold += BattleRoom.Reward.GoldReward;
                Player.Inventory.Add(BattleRoom.Reward.ItemReward);
            }
            _session.SavePlayerStats(Player);
            _session.SaveNpcStats(Npc);
            return result;
        }
        public Shop EnterShop(int id)
        {
            ShopRoom = _gs.Shops[id];
            _session.SetRoomId(id);
            if (ShopRoom.Reward != null)
            {
                if (ShopRoom.Reward.GoldReward != 0) { Player.Gold += ShopRoom.Reward.GoldReward; ShopRoom.Reward.GoldReward = 0; }
                if (ShopRoom.Reward.ItemReward != null) { Player.Inventory.Add(ShopRoom.Reward.ItemReward); ShopRoom.Reward.ItemReward = null; }

            }
            _session.SavePlayerStats(Player);
            _session.SaveShop(ShopRoom);
            return ShopRoom;
        }
        public string Buy(string item)
        {
            Item value = ShopRoom.Inventory.GetValueOrDefault(item);
            if (Player.Gold >= value.Cost)
            {
                if (Player.Inventory.Find(x => x.Name == value.Name) == null)
                {
                    Player.Inventory.Add(value);
                }
                else
                {
                    if (value.Name == Player.Inventory.Find(x => x.Name == value.Name).Name)
                    {
                        if (value.Type == ItemType.Weapon || value.Type == ItemType.Armor || value.Type == ItemType.Amulet) { return $"Nemůžeš vlastnit 2 zbraně/brnění/amulety stejného typu zárověň"; }
                        Player.Inventory.Find(x => x.Name == value.Name).Count++;
                    }
                    else { Player.Inventory.Add(value); }
                }
                Player.Gold -= value.Cost;
                ShopRoom.Inventory.Remove(item);
                _session.SavePlayerStats(Player);
                _session.SaveShop(ShopRoom);
                return $"Úspešně sis zakoupil {value.Name} za {value.Cost} zlaťáků";
            }
            else
            {
                _session.SavePlayerStats(Player);
                return "Nemůžeš si koupit něco na co nemáš zlaťáky ...";
            }
        }
        public string Sell(string ItemName)
        {
            Item EquipItem = Player.Inventory.Find(x => x.Name == ItemName);
            Player.Gold += EquipItem.Cost;
            EquipItem.Count--;
            if (EquipItem.Count < 1) { Player.Inventory.Remove(EquipItem); }
            _session.SavePlayerStats(Player);
            _session.SaveShop(ShopRoom);
            return $"Uspěšně si prodal {EquipItem.Name} za {EquipItem.Cost} zlaťáků";
        }
        public void Equip(string name)
        {
            Item item = Player.Inventory.Find(x => x.Name == name);
            switch (item.Type)
            {
                case ItemType.Weapon:
                    if (Player.Weapon.Name != "pěsti") { Player.Inventory.Find(x => x.Name == Player.Weapon.Name).IsEquipped = false; }
                    Player.Weapon = item;
                    Player.PlayerStats.Attack = Player.Power + Player.Weapon.BonusStats.Attack + Player.Amulet.BonusStats.Attack;
                    break;
                case ItemType.Armor:
                    if (Player.Armor.Name != "košile") { Player.Inventory.Find(x => x.Name == Player.Armor.Name).IsEquipped = false; }
                    Player.Armor = item;
                    Player.PlayerStats.Defense = 2 + Player.Armor.BonusStats.Defense;
                    Player.PlayerStats.MaxHealthPoints = 100 + Player.Armor.BonusStats.MaxHealthPoints + Player.Amulet.BonusStats.MaxHealthPoints;
                    Player.PlayerStats.MaxManaPoints = 50 + Player.Armor.BonusStats.MaxManaPoints + Player.Amulet.BonusStats.MaxManaPoints;
                    break;
                case ItemType.Amulet:
                    if (Player.Amulet.Name != "") { Player.Inventory.Find(x => x.Name == Player.Amulet.Name).IsEquipped = false; }
                    Player.Amulet = item;
                    Player.PlayerStats.Attack = Player.Power + Player.Weapon.BonusStats.Attack + Player.Amulet.BonusStats.Attack;
                    Player.PlayerStats.MaxHealthPoints = 100 + Player.Armor.BonusStats.MaxHealthPoints + Player.Amulet.BonusStats.MaxHealthPoints;
                    Player.PlayerStats.MaxManaPoints = 50 + Player.Armor.BonusStats.MaxManaPoints + Player.Amulet.BonusStats.MaxManaPoints;
                    break;
                default:
                    break;
            }
            item.IsEquipped = true;
            _session.SavePlayerStats(Player);
            Rooms = _gs.Rooms[_session.GetRoomId().Value];
        }
        public void Use(string name)
        {
            Item item = Player.Inventory.Find(x => x.Name == name);
            Player.PlayerStats.HealthPoints += item.BonusStats.HealthPoints;
            if (Player.PlayerStats.HealthPoints > Player.PlayerStats.MaxHealthPoints) { Player.PlayerStats.HealthPoints = Player.PlayerStats.MaxHealthPoints; }
            Player.PlayerStats.ManaPoints += item.BonusStats.ManaPoints;
            if (Player.PlayerStats.ManaPoints > Player.PlayerStats.MaxManaPoints) { Player.PlayerStats.ManaPoints = Player.PlayerStats.MaxManaPoints; }
            item.Count--;
            if (item.Count < 1) { Player.Inventory.Remove(item); }
            _session.SavePlayerStats(Player);
            Rooms = _gs.Rooms[_session.GetRoomId().Value];
        }
        public void Cast(string name)
        {
            Spells spell = Player.Spellbook.Find(x => x.Name == name);
            if (Player.PlayerStats.ManaPoints >= spell.SpellCost)
            {
                PlayerDmg = (spell.SpellPower + Player.PlayerStats.Spellpower);
                switch (spell.Type)
                {
                    case SpellType.Damage:
                        if (Npc.NpcStats.HealthPoints > 0)
                        {
                            Npc.NpcStats.HealthPoints -= PlayerDmg;
                            Player.PlayerStats.ManaPoints -= spell.SpellCost;
                        }
                        _session.SavePlayerStats();
                        _session.SaveNpcStats(Npc);
                        break;
                    case SpellType.HealthGain:
                        if (Player.PlayerStats.ManaPoints >= spell.SpellCost)
                        {
                            if (Player.PlayerStats.HealthPoints > 0)
                            {
                                Player.PlayerStats.HealthPoints += PlayerDmg;
                                if (Player.PlayerStats.HealthPoints > Player.PlayerStats.MaxHealthPoints) { Player.PlayerStats.HealthPoints = Player.PlayerStats.MaxHealthPoints; }
                                Player.PlayerStats.ManaPoints -= spell.SpellCost;
                            }
                        }
                        _session.SavePlayerStats();
                        _session.SaveNpcStats(Npc);
                        break;
                    case SpellType.ManaGain:
                        if (Player.PlayerStats.ManaPoints >= spell.SpellCost)
                        {
                            if (Player.PlayerStats.HealthPoints > 0)
                            {
                                Player.PlayerStats.ManaPoints += PlayerDmg;
                                if (Player.PlayerStats.ManaPoints > Player.PlayerStats.MaxManaPoints) { Player.PlayerStats.ManaPoints = Player.PlayerStats.MaxManaPoints; }
                            }
                        }
                        _session.SavePlayerStats();
                        _session.SaveNpcStats(Npc);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}