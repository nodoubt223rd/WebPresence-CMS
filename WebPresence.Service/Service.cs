using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebPresence.Data;
using WebPresence.Service.Interfaces;

namespace WebPresence.Service
{
    public class Service : IService
    {
        public Service()
        {
            StartUp.StartupOnce();
        }
    }
}
