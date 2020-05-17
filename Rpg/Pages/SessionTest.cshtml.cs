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
    public class SessionTestModel : PageModel
    {
        private readonly SessionStorage sessionStorage;

        public SessionTestModel(SessionStorage sessionStorage)
        {
            this.sessionStorage = sessionStorage;

            Name = sessionStorage.PlayerStats?.Name ?? "Nobody";
            Items = sessionStorage.PlayerStats?.Inventory ?? new Dictionary<string, Item>();

            if (sessionStorage.PlayerStats == default)
            {
                sessionStorage.PlayerStats = new Model.Player();
                sessionStorage.PlayerStats.Inventory = new Dictionary<string, Item>();
                sessionStorage.PlayerStats.Name = "sessioner killer";
                sessionStorage.SavePlayerStats();
            }
        }

        public string Name { get; set; }
        public Dictionary<string, Item> Items { get; set; }

        public void OnGet()
        {

        }

        public void OnGetSet(string item)
        {

            sessionStorage.PlayerStats.Inventory.TryAdd(item, new Model.Item() { Count = 1, Name = item, Description = "The Miracle" });
            sessionStorage.SavePlayerStats();
        }
    }
}