using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if  (Check.CheckData(textBox1.Text, textBox2.Text, textBox3.Text) &&
                Check.CheckFullData(textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text))
            { 
                button1.DialogResult = DialogResult.OK; 
            }
            DataBank.in1 = textBox1.Text;
            DataBank.in2 = textBox2.Text;
            DataBank.in3 = textBox3.Text;
            DataBank.in4 = textBox4.Text;
            DataBank.in5 = textBox5.Text;
            DataBank.in6 = textBox6.Text;
            /*textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();*/
        }
    }
}
