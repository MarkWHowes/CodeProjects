using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLoad()
        {
            var controller = new ServerPerfLoad.Controllers.LoadController();
            for (int i=1; i<100; i++)
            {
                controller.Post("TestServer",i,16);
            }
            var PerfReport = new ServerReport.Controllers.ReportController();
            var perDayReport = PerfReport.PerDay();
            Assert.AreEqual("PerDay", perDayReport.ViewName);
            
            var perMinReport = PerfReport.PerMinute();
            Assert.AreEqual("PerMinute", perMinReport.ViewName);


        }
    }
}
