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
        public Player Player { get; set; }
        public Npc Npc { get; set; }
        public string Result { get; set; }

        public void OnGet(int to)
        {
            BattleRoom = _rgl.Battle(to);
            Npc = _rgl.Npc;
            Player = _rgl.Player;
        }
        public void OnGetFight(BattleChoice choice)
        {
            BattleRoom = _rgl.BattleRoom;
            Npc = _rgl.Npc;
            Player = _rgl.Player;
            Result = _rgl.Battle(choice);
        }
        public void OnGetDefense()
        {
            BattleRoom = _rgl.BattleRoom;
            Npc = _rgl.Npc;
            Player = _rgl.Player;
            Result = _rgl.Battle(BattleChoice.Defend);
        }
        public void OnGetEquip(string item)
        {
            Player = _rgl.Player;
            Npc = _rgl.Npc;
            _rgl.Equip(item);
            BattleRoom = _rgl.BattleRoom;
        }
        public void OnGetUse(string item)
        {
            Player = _rgl.Player;
            Npc = _rgl.Npc;
            _rgl.Use(item);
            BattleRoom = _rgl.BattleRoom;
        }
    }
}