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
    public enum Operations
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
        bool isDot = false;
        int disCharge = 0;
        Operations currOper = Operations.None;

        public void NumberAdd(int num)
        {
            if (isDot)
            {
                result += num / Math.Pow(10, ++disCharge);
            }
            else
            {
                result *= 10;
                result += num;
            }
            showTablo();
        }

        public void NumberRemove()
        {
            if (isDot && disCharge == 0)
            {
                isDot = false;
            }
            else if (isDot)
            {
                int currentCharge = disCharge;
                double temp = result;
                do
                {
                    temp -= (int)temp;
                    temp *= 10;
                    currentCharge--;
                }
                while (currentCharge > 0);
                result -= (int)temp / Math.Pow(10, disCharge);
                disCharge--;
            }
            else
            { 
                result -= result % 10;
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
            tablo.Text = result.ToString("F" + disCharge);
            if (isDot && disCharge == 0) tablo.Text += ',';
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            result = 0d;
            isDot = false;
            disCharge = 0;
            showTablo();
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
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            isDot = true;
            showTablo();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            currOper = Operations.Summ;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            currOper = Operations.Minus;
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            currOper = Operations.Mult;
        }

        private void buttonDev_Click(object sender, EventArgs e)
        {
            currOper = Operations.Devide;
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            Logic.Equals(result, first);
        }
    }
}
