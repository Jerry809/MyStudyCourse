using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLogging_Log4net
{
    public class Log4net
    {
        private ILog log = LogManager.GetLogger<Log4net>();

        public void Info(string message)
        {
            log.Info(message);
        }
    }
}
