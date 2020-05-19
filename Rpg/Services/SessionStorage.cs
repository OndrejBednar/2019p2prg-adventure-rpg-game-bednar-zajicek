using Microsoft.AspNetCore.Http;
using Rpg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpers;

namespace Rpg.Services
{
    public class SessionStorage
    {
        readonly ISession _session;
        const string KEY = "ROOMID";
        const string PLAYERSTATS = "P.STATS";
        const string NPCSTATS = "N.STATS";
        const string BATTLE = "BATTLE";
        const string SHOP = "SHOP";

        public Battle BattleRoom { get; set; }
        public Shop ShopRoom { get; set; }
        public Player PlayerStats { get; set; }
        public Npc NpcStats { get; set; }

        public SessionStorage(IHttpContextAccessor hce)
        {
            _session = hce.HttpContext.Session;
            PlayerStats = _session.Get<Player>(PLAYERSTATS);
            NpcStats = _session.Get<Npc>(NPCSTATS);
            BattleRoom = _session.Get<Battle>(BATTLE);
            ShopRoom = _session.Get<Shop>(SHOP);
        }

        public void SetRoomId(int number)
        {
            _session.SetInt32(KEY, number);
        }
        public int? GetRoomId()
        {
            return _session.GetInt32(KEY);
        }
        public void SavePlayerStats()
        {
            _session.Set(PLAYERSTATS, this.PlayerStats);
        }
        public void SavePlayerStats(Player stats)
        {
            _session.Set(PLAYERSTATS, stats);
        }
        public void SaveNpcStats(Npc stats)
        {
            _session.Set(NPCSTATS, stats);
        }
        public void SaveBattle(Battle room)
        {
            _session.Set(BATTLE, room);
        }
        public void SaveShop(Shop room)
        {
            _session.Set(SHOP, room);
        }
    }
}
