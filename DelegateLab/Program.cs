using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelegateLab.Delegate;

namespace DelegateLab
{
    class Program
    {
        static void Main(string[] args)
        {
            // No delegate
            GetNumber getNumber = new GetNumber(new CaculatePlus(6, 3));
            Console.WriteLine(getNumber.ReturnString());

            //funcDelegate
            var func = new FuncDelegate();
            var getNumberDelegate = new GetNumberByDelegate();
            Console.WriteLine(getNumberDelegate.ReturnString(func.Plus,5,3));

            Console.ReadLine();
        }

        public class GetNumberByDelegate
        {
            public string ReturnString(Func<int, int, string> func, int a, int b)
            {
                return "delegate結果為:" + func(a, b);
            }
        }

        public class GetNumber
        {
            private ICalulate caculate;
     
            public GetNumber(ICalulate caculate)
            {
                this.caculate = caculate;
            }

            public string ReturnString()
            {
                return "結果為" + this.caculate.CaculateResult();
            }
        }
    }
}
