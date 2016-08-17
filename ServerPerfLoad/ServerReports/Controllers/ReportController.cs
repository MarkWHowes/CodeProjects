using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServerData;
using System.Web.Mvc;

namespace ServerReport.Controllers
{
    public class ReportController : Controller
    {
        
        
        public ViewResult PerMinute()
        {
            
            return View("PerMinute",ServerData.ServerData.MinuteAvg(60));
        }

        public ViewResult PerDay()
        {
            return View("PerDay",ServerData.ServerData.DayAvg());
        }

       
    }
}
