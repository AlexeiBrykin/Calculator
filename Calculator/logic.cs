using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Logic
    { 
        public double Sum(double x, double y)
        {
            return x + y;
        }

        public double Minus(double x, double y)
        {
            return x - y;
        }

        public double Mult(double x, double y)
        {
            return x * y;
        }

        public double Devide(double x, double y)
        {
            return x / y;
        }

        public double Equal(Operations currOper, double x, double y)
        {
           switch (currOper)
            {
                case Operations.Summ:
                    return Sum(x, y);
                case Operations.Minus:
                    return Minus(x, y);
                case Operations.Mult:
                    return Mult(x, y);
                case Operations.Devide:
                    return Devide(x, y);
            }
            return 0d;
        }
    }
}
