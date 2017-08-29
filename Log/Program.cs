using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;

namespace Log
{
    class Program
    {

        static void Main(string[] args)
        {
            var nLog = new NLog();
            //nLog.SayHello();

            var log4Net = new Log4Net();
            log4Net.SayHello();
        }
    }
}
