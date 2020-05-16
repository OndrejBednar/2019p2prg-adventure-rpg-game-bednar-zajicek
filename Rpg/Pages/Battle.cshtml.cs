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
            NpcStats = _rgl.NpcStats;
            PlayerStats = _rgl.PlayerStats;
            if (PlayerStats.Attack - NpcStats.Defense < 1) { Result = $"Útočíš na {NpcStats.Name}a ... {NpcStats.Name} vykryl tvůj útok"; }
            else { Result = $"Útočíš na {NpcStats.Name}a ... Působíš {NpcStats.Name}ovi {PlayerStats.Attack} bodů poškození"; }
        }
        public void OnGetDefense()
        {
            Room = _rgl.Battle(BattleChoice.Defend);
            NpcStats = _rgl.NpcStats;
            PlayerStats = _rgl.PlayerStats;
            Room.Description = $"";
            if (NpcStats.Attack - PlayerStats.Defense < 1) { Result = $"Snažíš se ubránit {NpcStats.Name}ovi ... {NpcStats.Name} neprorazil tvou obranu"; }
            else { Result = $"Snažíš se ubránit {NpcStats.Name}ovi ... {NpcStats.Name} způsobuje {NpcStats.Attack} bodů poškození"; }
        }
    }
}