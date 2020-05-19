using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rpg.Model
{
    public enum RoomType
    {
        [Display(Name = "Normální místnost")]
        Normal = 0,
        [Display(Name = "Bitva")]
        Battle = 1,
        [Display(Name = "Obchod")]
        Shop = 2,
    }
}
