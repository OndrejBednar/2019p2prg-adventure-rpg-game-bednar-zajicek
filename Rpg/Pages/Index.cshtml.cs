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
        private readonly SessionStorage _ss;
        private readonly RpgLogic _rgl;

        public IndexModel(SessionStorage ss,RpgLogic rgl)
        {
            _ss = ss;
            _rgl = rgl;
        }

        public Room Room { get; set; }

        public void OnGet()
        {
            Room = _rgl.Play();
        }

    }
}
