using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Logic
    { 
        public static double Sum(double x, double y)                                   //сложение
        {
            return x + y;
        }

        public static double Minus(double x, double y)                                 //вычитание
        {
            return x - y;
        }

        public static double Mult(double x, double y)                                  //умножение
        {
            return x * y;
        }

        public static double Devide(double x, double y)                                //деление
        {
            return x / y;
        }

        public static double Equal(Operations currOper, double x, double y)            //равно
        {
           switch (currOper)                                                           //выбор операции
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
            return y;
        }
    }
}
