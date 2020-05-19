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
    public class TutorialModel : PageModel
    {
        private readonly RpgLogic _rgl;

        public TutorialModel(RpgLogic rgl)
        {
            _rgl = rgl;
        }

        public Room Room { get; set; }

        public void OnGet()
        {
            Room = _rgl.Play(0);
        }
    }
}