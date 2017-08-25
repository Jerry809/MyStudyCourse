using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MemoryCache_Course
{
    /// <summary>
    /// 要使用MemoryCache , 需先加入參考 System.Runtime.Caching
    /// </summary>
    public class DataSource
    {
        // fields
        private ObjectCache _cache = MemoryCache.Default;

        // proterties
        // 當Cache被移除時的Callback function
        public CacheEntryRemovedCallback OnFileContentsCacheRemove;

        public string PolicyType { get; set; }

        public string FileContents
        {
            get
            {
                string cacheKey = "FileContents";
                string fileContents = _cache[cacheKey] as string;
                if (string.IsNullOrWhiteSpace(fileContents))
                {

                    // load file
                    string filePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Data\\data.txt");

                    fileContents = File.ReadAllText(filePath, Encoding.Default);

                    // set policy (when to remove cache)
                    var policy = new CacheItemPolicy();
                    policy.RemovedCallback = OnFileContentsCacheRemove;

                    // dynamic change policy for testing 
                    switch (PolicyType)
                    {
                        case "1":
                            // 距離設定快取時間超過2秒後，回收快取
                            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(2);
                            break;
                        case "2":
                            // 3秒期限內未使用快取時，回收快取
                            policy.SlidingExpiration = TimeSpan.FromSeconds(3);
                            break;
                        default:
                            // 資料異動時，回收快取
                            policy.ChangeMonitors.Add(new HostFileChangeMonitor(new List<string>() { filePath }));
                            break;
                    }

                    // set cache
                    _cache.Set(cacheKey, fileContents, policy);
                }

                return fileContents;
            }
        }
    }
}
