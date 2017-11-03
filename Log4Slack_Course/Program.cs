using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Slack_Course
{
    class Program
    {
        private string webHookUrl = "https://hooks.slack.com/services/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";
        static void Main(string[] args)
        {
            // 取得Logger(Logger以Program的Type Name命名)
            var log = LogManager.GetLogger(typeof(Program));

            //BasicConfigurator.Configure();
            // 因為要讀取從App.config讀取設定，所以使用XmlConfigurator
            string log4netPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "../../log4net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(log4netPath));

            for (var i = 0; i < 10; i++)
            {
                log.Info(i);
                log.Debug(i);
            }

        }
    }
}
