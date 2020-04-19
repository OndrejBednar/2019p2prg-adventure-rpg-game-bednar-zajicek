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
        private readonly RpgLogic _ss;
        public RoomModel(RpgLogic ss)
        {
            _ss = ss;
        }
        public string Description { get; set; }

        public Room Room { get; set; }

        public void OnGet(int to)
        {
            _ss.SetRoomId(to);
            Room = _ss.Play();
            Description = Room.Description;
        }
    }
}