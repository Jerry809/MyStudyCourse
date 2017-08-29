using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    public class Log4Net
    {
        private ILog log = LogManager.GetLogger<Log4Net>();

        public void SayHello()
        {
            log.Info("Hello Log4Net");
        }
    }
}
