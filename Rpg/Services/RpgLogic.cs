using Microsoft.AspNetCore.Http;
using Rpg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Services
{
    public class RpgLogic
    {
        readonly ISession _session;
        const string KEY = "ROOMID";

        public RpgLogic(IHttpContextAccessor hce)
        {
            _session = hce.HttpContext.Session;
        }

        public void Play()
        {
            int? id = _session.GetInt32(KEY);
            if (id == null)
            {
                new Room(0);
            }
            else
            {
                new Room((int)id);
            }
        }
    }
}
