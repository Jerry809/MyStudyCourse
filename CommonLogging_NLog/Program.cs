using Common.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
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
            //設定針測的檔案類型，如不指定可設定*.*
            var watch = new FileSystemWatcher(@"C:\Sample","*.*");

            //是否連子資料夾都要偵測
            watch.IncludeSubdirectories = true;
            watch.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName ;

            watch.InternalBufferSize = 2 * 1000 * 1024;
            //開啟監聽
            watch.EnableRaisingEvents = true;

            Console.WriteLine($"File  Watching..... Start  [{DateTime.Now}");
        
            //新增時觸發事件
            watch.Created += (
                (object sender, FileSystemEventArgs e) =>
                {
                    Console.WriteLine("Created...");
                    var fileName = e.FullPath;
                    if (File.Exists(fileName))
                    {
                        logger.Trace(fileName);
                        File.Move(fileName, fileName + "temp");
                        Console.WriteLine($"FullPath = {e.FullPath} , Name =  {e.Name}");
                    }                   
                });
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
            Console.WriteLine($"File  Watching..... End  [{DateTime.Now}");

            //logger.Trace("未使用Common.Logging NLog Trace");

            //var commonNLog = new CommonLoggingNLog();
            //commonNLog.Trace("使用Common.Logging NLog Trace");
        }
    }
}
