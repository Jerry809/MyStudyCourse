using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLab
{
    class Program
    {
        static void Main(string[] args)
        {
            GetNumber getNumber = new GetNumber(new CaculatePlus(6,3));
            Console.WriteLine(getNumber.ReturnString());
            Console.ReadLine();
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
