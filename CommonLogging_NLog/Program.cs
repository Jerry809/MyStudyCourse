using Common.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLogging_NLog
{
    class Program
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            logger.Trace("未使用Common.Logging NLog Trace");

            var commonNLog = new CommonLoggingNLog();
            commonNLog.Trace("使用Common.Logging NLog Trace");
        }
    }
}
