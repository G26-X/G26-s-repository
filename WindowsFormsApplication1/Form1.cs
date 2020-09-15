using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int a, b;
        string op;
        string time;
        int total;
        int result;
        int num = 0;
        int score = 0;
        int text1 = 1;
        double d;
        public Form1()
        {
            InitializeComponent();
        }

        public string label6text
        {
            set { this.label6.Text = value;
                this.text1 = int.Parse(value);
                total = int.Parse(value) * 10;
            }
            get { return this.label6.Text; }
        }

        public string label8text
        {
            set { this.label8.Text = value;
                time = value;
            }
            get { return this.label8.Text; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(time)*1000;
            timer1.Stop();
            timer2.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int text1 = int.Parse(label6.Text)+1;
            text1--;
            label6.Text = (text1-1).ToString();

            timer1.Stop();
            timer1.Interval = int.Parse(time) * 1000;
            timer1.Start();

            timer2.Stop();
            label8.Text = time;
            timer2.Start();

            string str = textBox1.Text;
            if (str != "")
            {
                d = double.Parse(str);
            }
            else
                d = 0;
            string disp = "" + a + op + b + "=" + str + "";
            if (d == result)
            {
                disp += "√";
                num++;
            }
            else
                disp += "×";
            listBox1.Items.Add(disp);
            Random rdm = new Random();
            a = rdm.Next(9) + 1;
            b = rdm.Next(9) + 1;
            int c = rdm.Next(4);
            switch (c)
            {
                case 0: op = "+"; result = a + b; break;
                case 1: op = "-"; result = a - b; break;
                case 2: op = "*"; result = a * b; break;
                case 3: op = "/"; result = a / b; break;
            }
            label1.Text = ("" + a);
            label2.Text = ("" + op);
            label3.Text = ("" + b);

            if (text1 == 0)
            {
                label1.Text = "null";
                label2.Text = "null";
                label3.Text = "null";
                label8.Text = "null";
                textBox1.Text = "";
                label6.Text = "0";
                timer1.Stop();
                timer2.Stop();
                score = num * 10;
                listBox1.Items.Add("答题结束，总分为" + total + "," + "您的得分为" + score);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add("超时！");
            text1--;
            button1_Click(null, null);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (int.Parse(label8.Text) >= 1)
            {
                int temp = int.Parse(label8.Text);
                temp--;
                label8.Text = temp.ToString();
            }
            else
                label8.Text = "0";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rdm = new Random();
            a = rdm.Next(9) + 1;
            b = rdm.Next(9) + 1;
            int c = rdm.Next(4);
            switch (c)
            {
                case 0: op = "+"; result = a + b; break;
                case 1: op = "-"; result = a - b; break;
                case 2: op = "*"; result = a * b; break;
                case 3: op = "/"; result = a / b; break;
            }
            label1.Text = ("" + a);
            label2.Text = ("" + op);
            label3.Text = ("" + b);
            textBox1.Text = ("");
            timer1.Start();
            timer2.Start();
            text1--;
            label6.Text = text1.ToString();
            
        }

    }
}
