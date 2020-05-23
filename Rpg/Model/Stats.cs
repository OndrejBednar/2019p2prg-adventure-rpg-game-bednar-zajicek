using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class Stats
    {
        public int HealthPoints { get; set; }
        public int MaxHealthPoints { get; set; }
        public int ManaPoints { get; set; }
        public int MaxManaPoints { get; set; }
        public int Attack { get; set; }
        public int CritChance { get; set; }
        public int Defense { get; set; }
        public int Spellpower { get; set; }
    }
}
