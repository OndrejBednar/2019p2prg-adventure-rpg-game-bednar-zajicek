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
        private readonly RpgLogic _ss;
        public string Description { get; set; }

        public Room Room { get; set; }
        public IndexModel(RpgLogic ss)
        {
            _ss = ss;
        }

        public void OnGet()
        {
            Room = _ss.Play();
            Description = Room.Description;
        }
    }
}
