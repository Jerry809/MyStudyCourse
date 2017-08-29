using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLogging_NLog
{
    public class CommonLoggingNLog
    {
        private ILog log = LogManager.GetLogger<CommonLoggingNLog>();

        public void Trace(string message)
        {
            log.Trace(message);
        }
    }
}
