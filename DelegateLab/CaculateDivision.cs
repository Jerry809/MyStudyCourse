using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLab
{
    public class CaculateDivision : ICalulate
    {
        private int a, b;

        public CaculateDivision(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public string CaculateResult()
        {
            return $"除法 : {a / b} ";
        }
    }
}
