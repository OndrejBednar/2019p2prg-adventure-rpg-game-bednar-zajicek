using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class Npc
    {
        public string Name { get; set; }
        public Stats NpcStats { get; set; }
        public BattleChoice Choice { get; set; }
    }
}
