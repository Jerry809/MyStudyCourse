using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MemoryCache_Course
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataSource = new DataSource();

            // 要指定給委派的Function , 需傳入與委派相同型別的參數
            dataSource.OnFileContentsCacheRemove = Log;

            // choose cache policy
            Console.WriteLine("[1] AbsoluteExpiration(2s) [2秒就刪除Cache]");
            Console.WriteLine("[2] SlidingExpiration(3s) [3秒沒有人讀取就刪除Cache]");
            Console.WriteLine("[3] ChangeMonitors [加入監看的檔案有異動, 就刪除Cache]");
            Console.Write("Please choose cache policy: ");
            dataSource.PolicyType = Console.ReadLine();


            // show data for testing cache
            while (true)
            {
                Console.WriteLine("[time] " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                Console.WriteLine("[cache value] " + dataSource.FileContents);

                string cmd = Console.ReadLine();
                if (cmd == "exit") { break; }
            }
        }

        private static void Log(CacheEntryRemovedArguments arg)
        {
            Console.WriteLine("CacheKey[{0}] , CacheValue[{1}] =======> Cache removed", arg.CacheItem.Key, arg.CacheItem.Value);
        }
    }
}
