using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerData
{

    public class ServerData
    {
        public class ServerEventData
        {

            public String ServerName;
            public double CPU;
            public double RAM;
            public DateTime CollectionDate;

            public ServerEventData() { }

            public ServerEventData(String serverName, double cpu, double ram)
            {
                this.ServerName = serverName;
                this.CPU = cpu;
                this.RAM = ram;
                this.CollectionDate = DateTime.Now;
                ServerEventList.Add(this);
            }

        }

        public class ServerPerfAverage
        {
            public String ServerName;
            public double avgCPU;
            public double avgRam;

            public ServerPerfAverage(String ServerName, double avgCPU, double avgRam)
            {
                this.ServerName = ServerName;
                this.avgCPU = avgCPU;
                this.avgRam = avgRam;
            }
        }

        public static List<ServerEventData> ServerEventList = new List<ServerEventData>();

        public static List<ServerPerfAverage> MinuteAvg(int minutes)
        {
            List<ServerPerfAverage> result = new List<ServerPerfAverage>();

            var perfMinutes = (from perf in ServerEventList
                               where perf.CollectionDate > DateTime.Now.AddMinutes(-minutes)
                               group perf by perf.ServerName into grouping
                               select new
                               {
                                   grouping.Key,
                                   AvgCPU = (from perf2 in grouping
                                             select perf2.CPU).Average(),
                                   AvgRam = (from perf2 in grouping
                                             select perf2.RAM).Average()


                               });
            foreach (var p in perfMinutes)
            {
                result.Add(new ServerPerfAverage(p.Key, p.AvgCPU, p.AvgRam));
            }


            return result;

        }

        public static List<ServerPerfAverage> DayAvg()
        {
            List<ServerPerfAverage> result = new List<ServerPerfAverage>();

            var perfDay = (from perf in ServerEventList
                               where perf.CollectionDate > DateTime.Now.AddHours(-24)
                               group perf by perf.ServerName into grouping
                               select new
                               {
                                   grouping.Key,
                                   AvgCPU = (from perf2 in grouping
                                             select perf2.CPU).Average(),
                                   AvgRam = (from perf2 in grouping
                                             select perf2.RAM).Average()


                               });
            foreach (var p in perfDay)
            {
                result.Add(new ServerPerfAverage(p.Key, p.AvgCPU, p.AvgRam));
            }


            return result;
        }


    }
}
