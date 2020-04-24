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
        const string KEY = "ROOMID";

        public SessionStorage(IHttpContextAccessor hce)
        {
            _session = hce.HttpContext.Session;
        }

        public void SetRoomId(int number)
        {
            _session.SetInt32(KEY, number);
        }
        public int? GetRoomId()
        {
            return _session.GetInt32(KEY);
        }
    }
}
