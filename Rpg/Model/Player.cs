using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class Player : Stats
    {
        public int HealthPoints { get; set; } = 100;
        public int ManaPoints { get; set; } = 50;
        public int Attack { get; set; } = 5;
        public int Defense { get; set; } = 5;
        public int SpellPower { get; set; } = 5;
    }
}
