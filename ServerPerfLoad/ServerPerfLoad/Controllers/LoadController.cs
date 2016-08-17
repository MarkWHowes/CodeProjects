using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServerData;

namespace ServerPerfLoad.Controllers
{
    public class LoadController : Controller
    {
        public void Post(String ServerNmae, double CPU, double RAM)
        {
            ServerData.ServerData.ServerEventData sd = new ServerData.ServerData.ServerEventData(ServerNmae, CPU, RAM);
        }

       
    }
}