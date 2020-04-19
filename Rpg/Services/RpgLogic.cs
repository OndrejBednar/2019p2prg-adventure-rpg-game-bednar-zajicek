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

        public Room Play()
        {
            int? id = _session.GetInt32(KEY);
            if (id == null)
            {
                Room room = new Room(0);
                room.AddCrossroad(new Crossroad(0, 0, 1));
                return room;
            }
            else
            {
                Room room = new Room((int)id);

                return room;
            }
        }
    }
}
