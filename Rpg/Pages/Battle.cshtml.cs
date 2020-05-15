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
        private readonly SessionStorage _ss;
        private readonly RpgLogic _rgl;

        public BattleModel(SessionStorage ss, RpgLogic rgl)
        {
            _ss = ss;
            _rgl = rgl;
            PlayerStats = _ss.PlayerStats;
            NpcStats = _ss.NpcStats;
        }

        public Battle Room { get; set; }
        public Player PlayerStats { get; set; }
        public Npc NpcStats { get; set; }
        public string Result { get; set; }

        public void OnGet(int to)
        {
            _ss.SetRoomId(to);
            Room = _rgl.Battle();
            NpcStats = Room.BossStats;
            _ss.SavePlayerStats(PlayerStats);
            _ss.SaveNpcStats(NpcStats);
        }
        public void OnGetAttack()
        {
            Room = _rgl.Battle();
            Room.Description = "Útočíš na protivníka ... ";
            Result = $"Dáváš {PlayerStats.Attack} poškození";
            NpcStats.HealthPoints = NpcStats.HealthPoints - PlayerStats.Attack;
            _ss.SavePlayerStats(PlayerStats);
            _ss.SaveNpcStats(NpcStats);
        }
        public void OnGetDefense()
        {
            Room = _rgl.Battle();
            Room.Description = "Snažíš se ubránit protivníkovi ...";
            Result = $"Dostáváš {NpcStats.Attack} poškození";
            PlayerStats.HealthPoints = PlayerStats.HealthPoints - NpcStats.Attack;
            _ss.SavePlayerStats(PlayerStats);
            _ss.SaveNpcStats(NpcStats);
        }
    }
}