using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rpg.Model;
using Rpg.Services;

namespace Rpg.Pages
{
    public class BattleModel : PageModel
    {
        private readonly RpgLogic _rgl;

        public BattleModel(RpgLogic rgl)
        {
            _rgl = rgl;
        }

        public Battle Room { get; set; }
        public Player PlayerStats { get; set; }
        public Npc NpcStats { get; set; }
        public string Result { get; set; }

        public void OnGet(int to)
        {
            Room = _rgl.Battle(to);
            NpcStats = _rgl.NpcStats;
            PlayerStats = _rgl.PlayerStats;
        }
        public void OnGetAttack()
        {
            Room = _rgl.Battle(BattleChoice.Attack);
            Room.Description = "Útočíš na protivníka ... ";
            NpcStats = _rgl.NpcStats;
            PlayerStats = _rgl.PlayerStats;
            Result = $"Dáváš {PlayerStats.Attack} poškození";
        }
        public void OnGetDefense()
        {
            Room = _rgl.Battle(BattleChoice.Defend);
            Room.Description = "Snažíš se ubránit protivníkovi ...";
            NpcStats = _rgl.NpcStats;
            PlayerStats = _rgl.PlayerStats;
            Result = $"Dostáváš {NpcStats.Attack} poškození";
        }
    }
}