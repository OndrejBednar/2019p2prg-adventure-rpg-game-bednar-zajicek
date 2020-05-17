using Microsoft.AspNetCore.Http;
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

        public Battle Room { get; set; }
        public Npc NpcStats { get; set; }
        public Player PlayerStats { get; set; }
        public int Dmg { get; set; }
        public bool IsCritical { get; set; }

        public RpgLogic(SessionStorage ss, GameStory gs, Random rand)
        {
            _rand = rand;
            _session = ss;
            _gs = gs;
            Room = _session.Room;
            PlayerStats = _session.PlayerStats;
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
            Room = _gs.Battles[to];
            NpcStats = Room.BossStats;
            _session.SavePlayerStats(PlayerStats);
            _session.SaveNpcStats(NpcStats);
            _session.SetRoomId(to);
            _session.SaveBattle(Room);
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
    }
}
