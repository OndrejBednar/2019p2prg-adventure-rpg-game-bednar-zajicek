using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rpg.Model;
using Rpg.Services;

namespace Rpg.Pages
{
    public class RoomModel : PageModel
    {
        private readonly RpgLogic _rgl;

        public RoomModel(RpgLogic rgl)
        {
            _rgl = rgl;
        }

        public Room Room { get; set; }
        public Player Player { get; set; }

        public void OnGet(int to)
        {
            Player = _rgl.Player;
            Room = _rgl.Play(to);
        }
        public void OnGetEquip(string item)
        {
            Player = _rgl.Player;
            _rgl.Equip(item);
            Room = _rgl.Rooms;
        }
        public void OnGetUse(string item)
        {
            Player = _rgl.Player;
            _rgl.Use(item);
            Room = _rgl.Rooms;
        }
    }
}