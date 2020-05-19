using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Rpg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Services
{
    public class RpgLogic
    {
        readonly Random _rand;
        readonly SessionStorage _session;
        readonly GameStory _gs;

        public Battle BattleRoom { get; set; }
        public Shop ShopRoom { get; set; }
        public Npc NpcStats { get; set; }
        public Player PlayerStats { get; set; }
        public int Dmg { get; set; }
        public bool IsCritical { get; set; }

        public RpgLogic(SessionStorage ss, GameStory gs, Random rand)
        {
            _rand = rand;
            _session = ss;
            _gs = gs;
            BattleRoom = _session.BattleRoom;
            ShopRoom = _session.ShopRoom;
            PlayerStats = new Player() { Attack = _session.PlayerStats.Attack, CritChance = _session.PlayerStats.CritChance, Defense = _session.PlayerStats.Defense, HealthPoints = _session.PlayerStats.HealthPoints, ManaPoints = _session.PlayerStats.ManaPoints, Name = _session.PlayerStats.Name, SpellPower = _session.PlayerStats.SpellPower, Inventory = _session.PlayerStats.Inventory, Gold = _session.PlayerStats.Gold };
            NpcStats = _session.NpcStats;
        }

        public Room Play(int id)
        {
            _session.SetRoomId(id);
            _session.SavePlayerStats(PlayerStats);
            return _gs.Rooms[id];
        }
        public void Battle(int to)
        {
            BattleRoom = _gs.Battles[to];
            NpcStats = BattleRoom.BossStats;
            _session.SavePlayerStats(PlayerStats);
            _session.SaveNpcStats(NpcStats);
            _session.SetRoomId(to);
            _session.SaveBattle(BattleRoom);
        }
        public int Battle(BattleChoice choice)
        {
            int rand;
            switch (choice)
            {
                case BattleChoice.None:
                    break;
                case BattleChoice.Attack:
                    rand = _rand.Next(100);
                    IsCritical = PlayerStats.CritChance >= rand ? true : false;
                    Dmg = PlayerStats.CritChance >= rand ? (PlayerStats.Attack * 2) - NpcStats.Defense: PlayerStats.Attack - NpcStats.Defense;
                    if (Dmg < 1)
                    {
                        _session.SavePlayerStats(PlayerStats);
                        _session.SaveNpcStats(NpcStats);
                    }
                    else
                    {
                        NpcStats.HealthPoints = NpcStats.HealthPoints - Dmg;
                        _session.SavePlayerStats(PlayerStats);
                        _session.SaveNpcStats(NpcStats);
                    }
                    break;
                case BattleChoice.Defend:
                    rand = _rand.Next(100);
                    IsCritical = NpcStats.CritChance >= rand ? true : false;
                    Dmg = NpcStats.CritChance >= rand ? (NpcStats.Attack * 2) - PlayerStats.Defense: NpcStats.Attack - PlayerStats.Defense;
                    if (Dmg < 1)
                    {
                        _session.SavePlayerStats(PlayerStats);
                        _session.SaveNpcStats(NpcStats);
                    }
                    else
                    {
                        PlayerStats.HealthPoints = PlayerStats.HealthPoints - Dmg;
                        _session.SavePlayerStats(PlayerStats);
                        _session.SaveNpcStats(NpcStats);
                    }
                    break;
                default:
                    break;
            }
            return Dmg;
        }
        public Shop EnterShop(int id)
        {
            ShopRoom = _gs.Shops[id];
            _session.SetRoomId(id);
            _session.SavePlayerStats(PlayerStats);
            _session.SaveShop(ShopRoom);
            return _gs.Shops[id];
        }
        public string Buy(string item)
        {
            Item value = ShopRoom.Inventory.GetValueOrDefault(item);
            if (PlayerStats.Gold >= value.Cost)
            {
                PlayerStats.Gold -= value.Cost;
                PlayerStats.Inventory.TryAdd(value.Name, value);
                ShopRoom.Inventory.Remove(item);
                _session.SavePlayerStats(PlayerStats);
                _session.SaveShop(ShopRoom);
                return $"Úspešně sis zakoupil {value.Name} za {value.Cost} zlaťáků";
            }
            else
            {
                _session.SavePlayerStats(PlayerStats);
                return "Nemůžeš si koupit něco na co nemáš zlaťáky ...";
            }
        }
        public string Sell(string item)
        {
            Item value = PlayerStats.Inventory.GetValueOrDefault(item);
            PlayerStats.Gold += value.Cost;
            PlayerStats.Inventory.Remove(value.Name);
            _session.SavePlayerStats(PlayerStats);
            _session.SaveShop(ShopRoom);
            return $"Uspěšně si prodal {value.Name} za {value.Cost} zlaťáků";
        }
    }
}
