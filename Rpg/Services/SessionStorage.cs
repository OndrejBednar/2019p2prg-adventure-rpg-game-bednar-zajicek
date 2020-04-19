using Microsoft.AspNetCore.Http;
using Rpg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Services
{
    public class SessionStorage
    {
        readonly ISession _session;
        const string KEY = "key";

        public SessionStorage(IHttpContextAccessor hce)
        {
            _session = hce.HttpContext.Session;
        }

        private void Save(int data)
        {
            _session.SetInt32(KEY, data);

            int? id = _session.GetInt32(KEY);
            if (id == null)
            {
                new Room(0);
            }
        }
    }
}
