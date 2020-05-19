using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class Battle
    {
        public int BattleID { get; set; }
        public int NextRoomID { get; set; }
        public Npc BossStats { get; set; }
        public string Description { get; set; }
        public Rewards Reward { get; set; }
    }
}
