using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class Npc : Stats
    {
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public int ManaPoints { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpellPower { get; set; }
    }
}
