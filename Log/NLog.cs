using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;

namespace Log
{
    public class NLog
    {
        private ILog log = LogManager.GetLogger<NLog>();

        public void SayHello()
        {
            this.log.Info("Hello NLog");
        }
    }
}
