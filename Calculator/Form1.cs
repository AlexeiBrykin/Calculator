using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public enum Operations                                                  //перечисление операций
    {
        None,
        Summ,
        Minus,
        Mult,
        Devide
    }

    public partial class Form1 : Form
    {
        double result = 0d;
        double first = 0d;
        bool isDot = false;                                                 //целочисленная точка
        int disCharge = -1;                                                 //разряд
        Operations currOper = Operations.None;
        bool equalUsed = false;
        double secOp = 0d;

        private void SecondNum()
        {
            first = result;
            result = 0d;
            isDot = false;
            disCharge = -1;
            showTablo();
        }

        public void NumberAdd(int num)                                      //добавление цифры в число
        {
            if (equalUsed)
            {
                result = 0d;
            }
            equalUsed = false;

            if (isDot)
            {
                result += num / Math.Pow(10, ++disCharge);                  //добавление дробной части
            }
            else
            {
                result *= 10;                                               //добавление целой части
                result += num;
            }
            showTablo();
        }

        public void NumberRemove()                                          //удаление цифры из числа
        {
            if (isDot && disCharge == -1)                                    
            {
                isDot = false;                                              //удаление точки
            }
            else if (isDot)
            {
                int currentCharge = disCharge;
                double temp = result;
                do
                {
                    temp -= (int)temp;                                      //удаление дробной части
                    temp *= 10;
                    currentCharge--;
                }
                while (currentCharge > 0);
                result -= (int)temp / Math.Pow(10, disCharge);
                disCharge--;
            }
            else
            { 
                result -= result % 10;                                      //удаление целой части
                result /= 10;
            }
            showTablo();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void showTablo()
        {
            tablo.Text = result.ToString(disCharge < 0 ? string.Empty : "F" + disCharge);                  //вывод результата
            if (isDot && disCharge == 0) tablo.Text += ',';
        }


        private void Clean()                                                //очистка
        {
            result = 0d;                                                    
            first = 0d;
            isDot = false;
            disCharge = -1;
            equalUsed = false;
            secOp = 0d;
            currOper = Operations.None;
            showTablo();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Clean();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NumberAdd(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NumberAdd(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NumberAdd(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NumberAdd(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NumberAdd(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NumberAdd(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NumberAdd(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NumberAdd(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NumberAdd(9);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            NumberAdd(0);
        }

        private void buttonBackSpace_Click(object sender, EventArgs e)
        {
            NumberRemove();
            equalUsed = false;
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            isDot = true;
            disCharge = 0;
            showTablo();
            equalUsed = false;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            currOper = Operations.Summ;
            SecondNum();
            equalUsed = false;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            currOper = Operations.Minus;
            SecondNum();
            equalUsed = false;
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            currOper = Operations.Mult;
            SecondNum();
            equalUsed = false;
        }

        private void buttonDev_Click(object sender, EventArgs e)
        {
            currOper = Operations.Devide;
            SecondNum();
            equalUsed = false;
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            if (equalUsed == false) {
                secOp = result;
                result = Logic.Equal(currOper, first, result);
                showTablo();
            }
            else
            {
                result = Logic.Equal(currOper, result, secOp);
                showTablo();
            }
            equalUsed = true;
        }

        private void allClear_Click(object sender, EventArgs e)
        {
            Clean();
        }
    }
}
            