using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Model
{
    public class Spells
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SpellPower { get; set; }
        public int SpellCost { get; set; }
        public int SpellCooldown { get; set; } = 3;
        public int CurrentCooldown { get; set; } = 0;
        public bool IsUsable { get; set; } = true;
        public SpellType Type { get; set; }
    }

    public enum SpellType
    {
        Damage = 0,
        HealthGain = 1,
        ManaGain = 2
    }
}
