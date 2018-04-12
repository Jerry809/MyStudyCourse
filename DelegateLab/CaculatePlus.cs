using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLab
{
    public class CaculatePlus : ICalulate
    {
        private int a, b;

        public CaculatePlus(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public string CaculateResult()
        {
            return $"加法 : {a + b} ";
        }
    }
}
