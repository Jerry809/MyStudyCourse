using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield_Course
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in GetNum(1, 5))
            {
                Console.WriteLine("2 ====> Main Function ====> {0}", item);
            }
            Console.ReadKey();
        }

        private static IEnumerable<int> GetNum(int start, int end)
        {
            //yield return , 一次返回一個值而不是所有的結果
            //待主程式再次調用 , 會回到上次yield return 的位置再往下走
            //傳回值需為IEnumerable
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine("1 ====> yield Function Start");
                yield return i;
                Console.WriteLine("3 ====> yield Function Countinue");
            }
        }
    }
}
