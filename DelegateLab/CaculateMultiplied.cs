using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLab
{
    public class CaculateMultiplied : ICalulate
    {
        private int a, b;

        public CaculateMultiplied(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public string CaculateResult()
        {
            return $"乘法 : {a * b} ";
        }
    }
}
