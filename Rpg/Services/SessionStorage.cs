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
        const string PLAYER = "PLAYER";
        const string NPC = "NPC";
        const string BATTLE = "BATTLE";
        const string SHOP = "SHOP";
        const string STORY = "STORY";

        public GameStory Story { get; set; }
        public Battle BattleRoom { get; set; }
        public Shop ShopRoom { get; set; }
        public Player Player { get; set; }
        public Npc Npc { get; set; }

        public SessionStorage(IHttpContextAccessor hce)
        {
            _session = hce.HttpContext.Session;
            Player = _session.Get<Player>(PLAYER);
            Npc = _session.Get<Npc>(NPC);
            BattleRoom = _session.Get<Battle>(BATTLE);
            ShopRoom = _session.Get<Shop>(SHOP);
            Story = _session.Get<GameStory>(STORY);
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
            _session.Set(PLAYER, this.Player);
            _session.Set(STORY, this.Story);
        }
        public void SavePlayerStats(Player stats)
        {
            _session.Set(PLAYER, stats);
            _session.Set(STORY, this.Story);
        }
        public void SaveNpcStats(Npc stats)
        {
            _session.Set(NPC, stats);
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
