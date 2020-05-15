using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rpg.Model
{
    public enum BattleChoice
    {
        [Display(Name = "Bez volby")]
        None = 0,
        [Display(Name = "Útok")]
        Attack = 1,
        [Display(Name = "Obrana")]
        Defend = 2,
        [Display(Name = "Batoh")]
        Bag = 3
    }
}
