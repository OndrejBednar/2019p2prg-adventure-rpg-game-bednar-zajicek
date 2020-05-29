using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Rpg.Model;
using Rpg.Services;

namespace Rpg.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SessionStorage _ss;

        public IndexModel(SessionStorage ss)
        {
            _ss = ss;
        }

        [BindProperty]
        public Player PlayerStats { get; set; }

        [BindProperty]
        public string Name { get; set; }

        public void OnGet()
        {
            PlayerStats = new Player();
        }
        public void OnPost()
        {
            PlayerStats.Name = Name;
            PlayerStats.Spellbook.Add(new Spells() { Name = "Bolt", Description = "A lightning bolt", SpellPower = 10, SpellCost = 5, Type = SpellType.Damage });
            PlayerStats.Spellbook.Add(new Spells() { Name = "Heal", Description = "Heal", SpellPower = 10, SpellCost = 5, Type = SpellType.HealthGain });
            PlayerStats.Spellbook.Add(new Spells() { Name = "Mana", Description = "Mana", SpellPower = 10, SpellCost = 5, Type = SpellType.ManaGain });
            _ss.SavePlayerStats(PlayerStats);
        }
    }
}
