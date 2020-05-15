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
        readonly SessionStorage _session;
        readonly GameStory _gs;

        public RpgLogic(SessionStorage ss, GameStory gs)
        {
            _session = ss;
            _gs = gs;
        }

        public Room Play()
        {
            int? id = _session.GetRoomId();
            if (id == null)
            {
                return _gs.Rooms[0];
            }
            else
            {
                return _gs.Rooms[id.Value];
            }
        }
        public Battle Battle()
        {
            return _gs.Battles[_session.GetRoomId().Value];
        }
    }
}
