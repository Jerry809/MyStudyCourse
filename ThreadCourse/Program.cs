using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            var oper = new Oper();
            var tasks = new List<Task>();
            for (int i = 0; i < 100; i++)
            {
                var task = Task.Run(()=> {
                    oper.Add(1);
                });
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());


            Console.WriteLine($"income = {oper.GetIncome()}");
            Console.ReadLine();
        }
    }

    public class Oper
    {
        private int _income = 0;

        public int Add(int value)
        {
            lock (this)
            {
                return _income += value;
            }
        }

        public int GetIncome()
        {
            return _income;
        }
    }
}
