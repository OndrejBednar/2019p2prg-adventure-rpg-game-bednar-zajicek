using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rpg.Model
{
    public enum ItemType
    {
        [Display(Name = "Ruka")]
        Fist = -1,
        [Display(Name = "Consumable")]
        Consumable = 0,
        [Display(Name = "Weapon")]
        Weapon = 1,
        [Display(Name = "Armor")]
        Armor = 2,
        [Display(Name = "Amulet")]
        Amulet = 3,
    }
}
