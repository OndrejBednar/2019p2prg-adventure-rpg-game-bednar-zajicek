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
    public class ShopModel : PageModel
    {
        private readonly RpgLogic _rgl;

        public ShopModel(RpgLogic rgl)
        {
            _rgl = rgl;
        }

        public string Result { get; set; }
        public Shop Room { get; set; }
        public Player PlayerStats { get; set; }

        public void OnGet(int to)
        {
            PlayerStats = _rgl.PlayerStats;
            Room = _rgl.EnterShop(to);
        }
        public void OnGetBuy(string item)
        {
            Room = _rgl.ShopRoom;
            PlayerStats = _rgl.PlayerStats;
            Result = _rgl.Buy(item);
        }
        public void OnGetSell(string item)
        {
            Room = _rgl.ShopRoom;
            PlayerStats = _rgl.PlayerStats;
            Result = _rgl.Sell(item);
        }
    }
}