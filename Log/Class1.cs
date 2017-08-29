using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;

namespace Log
{
    public class Class1
    {
        private ILog log = LogManager.GetLogger<Class1>();

        public void SayHello()
        {
            this.log.Info("Hello");
        }
    }
}
