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

        public Battle BattleRoom { get; set; }
        public Player PlayerStats { get; set; }
        public Npc NpcStats { get; set; }
        public string Result { get; set; }
        private int Dmg { get; set; }

        public void OnGet(int to)
        {
            _rgl.Battle(to);
            BattleRoom = _rgl.BattleRoom;
            NpcStats = _rgl.NpcStats;
            PlayerStats = _rgl.PlayerStats;
        }
        public void OnGetAttack()
        {
            BattleRoom = _rgl.BattleRoom;
            Dmg = _rgl.Battle(BattleChoice.Attack);
            NpcStats = _rgl.NpcStats;
            PlayerStats = _rgl.PlayerStats;
            if (_rgl.IsCritical)
            {
                if (Dmg < 1) { Result = $"Dal jsi do toho útoku všechno ... ale bohužel si {NpcStats.Name} minul"; }
                else { Result = $"Dal jsi do toho útoku všechno ... daří se ti zasadit {NpcStats.Name}ovi kritický zásah za {Dmg} bodů poškození"; }
            }
            else
            {
                if (Dmg < 1) { Result = $"Útočíš na {NpcStats.Name}a ... {NpcStats.Name} vykryl tvůj útok"; }
                else { Result = $"Útočíš na {NpcStats.Name}a ... Působíš {NpcStats.Name}ovi {Dmg} bodů poškození"; }
            }
        }
        public void OnGetDefense()
        {
            BattleRoom = _rgl.BattleRoom;
            Dmg = _rgl.Battle(BattleChoice.Defend);
            NpcStats = _rgl.NpcStats;
            PlayerStats = _rgl.PlayerStats;
            if (_rgl.IsCritical)
            {
                if (Dmg < 1) { Result = $"{NpcStats.Name} se ti pokusil zasadit kritický zásah ... Tobě se ho však podařilo plně vykrít"; }
                else { Result = $"{NpcStats.Name}ovi se podařilo zasadit ti kritický zásah ... způsobuje {Dmg} bodů poškození"; }
            }
            else
            {
                if (Dmg < 1) { Result = $"Snažíš se ubránit {NpcStats.Name}ovi ... {NpcStats.Name} neprorazil tvou obranu"; }
                else { Result = $"Snažíš se ubránit {NpcStats.Name}ovi ... {NpcStats.Name} způsobuje {Dmg} bodů poškození"; }
            }
        }
    }
}