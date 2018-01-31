using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Extensions;


namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        Stack<Operation> operations;
        public Form1()
        {
            InitializeComponent();
            operations = new Stack<Operation>();
        }
        //tatical arithmetic operations

        private void btn9_Click(object sender, EventArgs e)
        {
            string str = sumBox.Text.Append("9");
            sumBox.Text = str;
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {

            string str = sumBox.Text.Append("1");
            sumBox.Text = str;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            string str = sumBox.Text.Append("2");
            sumBox.Text = str;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            string str = sumBox.Text.Append("4");
            sumBox.Text = str;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            string str = sumBox.Text.Append("5");
            sumBox.Text = str;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            string str = sumBox.Text.Append("6");
            sumBox.Text = str;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            string str = sumBox.Text.Append("7");
            sumBox.Text = str;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            string str = sumBox.Text.Append("8");
            sumBox.Text = str;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            string str = sumBox.Text.Append("0");
            sumBox.Text = str;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            string str = sumBox.Text.Append("3");
            sumBox.Text = str;
        }

        private void btnpl_Click(object sender, EventArgs e)
        {
            try
            {
                double x = System.Convert.ToDouble(sumBox.Text);
                Adder add1 = new Adder(x);
                operations.Push(add1);
                clearText(x);
            }
            catch
            {

            }
        }
        private void btnmi_Click(object sender, EventArgs e)
        {
            try
            {
                double x = System.Convert.ToDouble(sumBox.Text);
                Subtractor sub1 = new Subtractor(x);
                operations.Push(sub1);
                clearText(x);
            }
            catch
            {

            }
        }

        private void btnmu_Click(object sender, EventArgs e)
        {
            try
            {
                double x = System.Convert.ToDouble(sumBox.Text);
                Multiplier mult1 = new Multiplier(x);
                operations.Push(mult1);
                clearText(x);
            }
            catch
            {

            }
        }

        private void btndi_Click(object sender, EventArgs e)
        {
            try
            {
                double x = System.Convert.ToDouble(sumBox.Text);
                Divider div1 = new Divider(x);
                operations.Push(div1);
                clearText(x);
            }catch
            {

            }
        }

        private void btneq_Click(object sender, EventArgs e)
        {
            Operation op1 = operations.Peek();
            operations.Pop();
            if (sumBox.Text != "")
            {
             op1.setnu2(System.Convert.ToDouble(sumBox.Text));
            }
            op1.Solve();
            sumBox.Text = op1.result.ToString();
            dispBox.Text = "";
        }
        private void clearText(double x)
        {
            sumBox.Text = "";
            dispBox.Text = x.ToString();
        }

        private void btncr_Click(object sender, EventArgs e)
        {
            sumBox.Text = "";
            dispBox.Text = "";
        }


        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btneq.PerformClick();
            }
        }


        private void sqrBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Squareroot sqr1 = new Squareroot(System.Convert.ToDouble(sumBox.Text));
                operations.Push(sqr1);
                clearText(System.Convert.ToDouble(sumBox.Text));
            }
            catch
            {

            }
        }
    }
}

namespace Extensions
{
    public static class Extender
    {
        public static string Append(this string str, string x)
        {
            int last = str.Length;
            string result = str.Insert(last, x);
            return result;
        }
    }
    
}

abstract class Operation
{
    public double num1;
    public double num2;

    public double result;
    public void setnu2(double x)
    {
        num2 = x;
    }
    public abstract void Solve();

}

class Adder : Operation
{

    public Adder(double x)
    {
        num1 = x;
    }
    override public void Solve()
    {
        result = num1 + num2;
    }
}

class Subtractor : Operation
{
    public Subtractor(double x)
    {
        num1 = x;
    }
    public override void Solve()
    {
        result = num1 - num2;
    }
}

class Multiplier : Operation
{

    public Multiplier(double x)
    {
        num1 = x;
    }
    public override void Solve()
    {
        result = num1 * num2;
    }
}

class Divider : Operation
{
    public Divider(double x)
    {
        num1 = x;
    }
    public override void Solve()
    {
        result = num1 / num2;
    }
}

class Squareroot: Operation
{
    public Squareroot(double x)
    {
        num1 = x;
        num2 = 0;
    }
    public override void Solve()
    {
        result = System.Math.Sqrt(num1);
    }
}