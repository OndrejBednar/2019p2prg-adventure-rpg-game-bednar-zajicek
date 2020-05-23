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

            Name = sessionStorage.Player?.Name ?? "Nobody";
            Items = sessionStorage.Player?.Inventory ?? new List<Item>();

            if (sessionStorage.Player == default)
            {
                sessionStorage.Player = new Model.Player();
                sessionStorage.Player.Inventory = new List<Item>();
                sessionStorage.Player.Name = "sessioner killer";
                sessionStorage.SavePlayerStats();
            }
        }

        public string Name { get; set; }
        public List<Item> Items { get; set; }

        public void OnGet()
        {

        }

        public void OnGetSet(string item)
        {

            sessionStorage.Player.Inventory.Add(new Model.Item() { Count = 1, Name = item, Description = "The Miracle", Cost = 10 });
            sessionStorage.SavePlayerStats();
        }
    }
}