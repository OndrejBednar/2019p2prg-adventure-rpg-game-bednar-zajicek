using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Services
{
    public class SessionStorage
    {
        readonly ISession _session;
        const string key = "key";

        public SessionStorage(IHttpContextAccessor hce)
        {
            _session = hce.HttpContext.Session;
        }

        private void Save(int data)
        {
            _session.SetInt32(key, data);
        }
    }
}
