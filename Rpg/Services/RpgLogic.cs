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
        readonly SessionStorage _session;
        readonly GameStory _gs;

        public Npc NpcStats { get; set; }
        public Player PlayerStats { get; set; }

        public RpgLogic(SessionStorage ss, GameStory gs)
        {
            _session = ss;
            _gs = gs;
            PlayerStats = _session.PlayerStats;
            NpcStats = _session.NpcStats;
        }

        public Room Play(int id)
        {
            _session.SetRoomId(id);
            _session.SavePlayerStats(PlayerStats);
            return _gs.Rooms[id];
        }
        public Battle Battle(int to)
        {
            Battle room = _gs.Battles[to];
            NpcStats = room.BossStats;
            _session.SavePlayerStats(PlayerStats);
            _session.SaveNpcStats(NpcStats);
            _session.SetRoomId(to);
            return room;
        }
        public Battle Battle(BattleChoice choice)
        {
            switch (choice)
            {
                case BattleChoice.None:
                    break;
                case BattleChoice.Attack:
                    if (PlayerStats.Attack - NpcStats.Defense < 1)
                    {
                        _session.SavePlayerStats(PlayerStats);
                        _session.SaveNpcStats(NpcStats);
                    }
                    else
                    {
                        NpcStats.HealthPoints = NpcStats.HealthPoints - (PlayerStats.Attack - NpcStats.Defense);
                        _session.SavePlayerStats(PlayerStats);
                        _session.SaveNpcStats(NpcStats);
                    }
                    break;
                case BattleChoice.Defend:
                    if (NpcStats.Attack - PlayerStats.Defense < 1)
                    {
                        _session.SavePlayerStats(PlayerStats);
                        _session.SaveNpcStats(NpcStats);
                    }
                    PlayerStats.HealthPoints = PlayerStats.HealthPoints - NpcStats.Attack;
                    _session.SavePlayerStats(PlayerStats);
                    _session.SaveNpcStats(NpcStats);
                    break;
                case BattleChoice.Bag:
                    break;
                default:
                    break;
            }
            return _gs.Battles[_session.GetRoomId().Value];
        }
    }
}
