using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLab
{
    public class CaculateMinus : ICalulate
    {
        private int a, b;

        public CaculateMinus (int a , int b)
        {
            this.a = a;
            this.b = b;
        }

        public string CaculateResult()
        {
            return $"減法 : {a - b} ";
        }
    }
}
