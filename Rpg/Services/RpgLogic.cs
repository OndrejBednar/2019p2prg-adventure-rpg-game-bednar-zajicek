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

        public void SetRoomId(int number)
        {
            _session.SetInt32(KEY, number);
        }

        public Room Play()
        {
            int? id = _session.GetInt32(KEY);
            if (id == null)
            {
                Room room = new Room(0);
                room.AddCrossroad(new Crossroad(0, 0));
                return room;
            }
            else
            {
                int ways;
                int C_ID;
                Room room = new Room((int)id);

                ways = id switch
                {
                    1 => 1,
                    2 => 3,
                    3 => 2,
                    4 => 2,
                    5 => 2,
                };
                for (int i = 0; i < ways; i++)
                {
                    C_ID = (int)id*100 + i;
                    room.AddCrossroad(new Crossroad((int)id, C_ID));
                }
                return room;
            }
        }
    }
}
