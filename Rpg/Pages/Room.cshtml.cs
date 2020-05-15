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
    public class RoomModel : PageModel
    {
        private readonly RpgLogic _rgl;

        public RoomModel(RpgLogic rgl)
        {
            _rgl = rgl;
        }

        public Room Room { get; set; }
        public Player PlayerStats { get; set; }

        public void OnGet(int to)
        {
            PlayerStats = _rgl.PlayerStats;
            Room = _rgl.Play(to);
        }
    }
}