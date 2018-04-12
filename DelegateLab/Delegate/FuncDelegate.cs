using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLab.Delegate
{
    public class FuncDelegate
    {
        public string Plus(int a, int b)
        {
            return string.Format("加法:{0}", a + b);
        }

        public string Minus(int a, int b)
        {
            return string.Format("減法:{0}", a - b);
        }

        public string Multiplied(int a, int b)
        {
            return string.Format("乘法:{0}", a * b);
        }

        public string Division(int a, int b)
        {
            return string.Format("除法:{0}", a / b);
        }
    }
}
