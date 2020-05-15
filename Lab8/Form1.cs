using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Lab8
{
    public partial class Form1 : Form
    {

        // Название препарата должно начинаться с заглавной буквы
        // Номер аптеки любое число
        // Дата не больше текущей
        // 
        Form2 frm2;
        Form3 frm3;

        static string filename;
        public XDocument doc;
        public bool opendoc=false;
       
        int currentYear = DateTime.Now.Year;
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (opendoc)
            {
                string q1 = textBox1.Text;
                string q2 = textBox2.Text;
                string q3 = textBox3.Text;
                FindRecord(q1, q2, q3);
            }
            else MessageBox.Show("File has not been loaded");
        }
        private void FindRecord(string q1, string q2, string q3)
        {
            if (Check.CheckData(q1, q2, q3))
            {
                if (!Check.FindMatch(q1, q2, q3,doc))
                {
                    IEnumerable<XElement> Medicine =
                     from el in doc.Root.Elements("Medicine")
                     where (string)el.Attribute("DrugStoreId") == q1 &&
                     (string)el.Attribute("MedicineName") == q2 &&
                    (string)el.Attribute("DateArrival") == q3
                     select el;
                    foreach (XElement item in Medicine)
                    {
                        DataBank.Output = DataBank.Output + item.Name.ToString() + " ";
                        //textBox.Text = textBox.Text + '\r' + '\n';
                        //Выводим все аттрибуты
                        foreach (XAttribute attr in item.Attributes())
                        {
                            DataBank.Output = DataBank.Output + attr + " ";
                            DataBank.Output = DataBank.Output + '\r' + '\n';
                        }

                        //Названия всех дочерних элементов
                        foreach (XElement el in item.Elements())
                        {
                            DataBank.Output = DataBank.Output + el.Name + " " + el.Value + " ";
                            DataBank.Output = DataBank.Output + '\r' + '\n';
                        }
                        DataBank.Output = DataBank.Output + '\r' + '\n';
                    }
                    frm2 = new Form2();
                    frm2.Show();
                    DataBank.Output = "";
                }
                else MessageBox.Show("The record does not exist");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (opendoc)
            {
                string q1 = textBox1.Text;
                string q2 = textBox2.Text;
                string q3 = textBox3.Text;
                DeleteRecord(q1, q2, q3);
            }
            else MessageBox.Show("File has not been loaded");

        }
        private void DeleteRecord(string q1, string q2, string q3)
        {
            if (Check.CheckData(q1, q2, q3))
            {
                if (!Check.FindMatch(q1, q2, q3,doc))
                {
                    IEnumerable<XElement> Medicine = doc.Root.Descendants("Medicine").Where(
                        t => t.Attribute("DrugStoreId").Value == q1
                        && t.Attribute("MedicineName").Value == q2
                        && t.Attribute("DateArrival").Value == q3).ToList();

                    foreach (XElement t in Medicine)
                        t.Remove();
                    ShowRecords();
                }
                else MessageBox.Show("The record does not exist");
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (opendoc)
            {
                frm3 = new Form3();

                if (frm3.ShowDialog() == DialogResult.OK)
                    AddRecord();
            }
            else MessageBox.Show("File has not been loaded");
        }
        
        private void AddRecord()
        {
            string q1 = DataBank.in1;
            string q2 = DataBank.in2;
            string q3 = DataBank.in3;
            string q4 = DataBank.in4;
            string q5 = DataBank.in5;
            string q6 = DataBank.in6;
            
            
                if (Check.FindMatch(q1, q2, q3, doc))
                {

                    XElement Medicine = new XElement("Medicine",
                         new XAttribute("DrugStoreId", q1),
                                new XAttribute("MedicineName", q2),
                                new XAttribute("DateArrival", q3),
                                new XElement("Amount", q4),
                                new XElement("Price", q5),
                                new XElement("StoragePeriod", q6));

                    doc.Root.Add(Medicine);
                    doc.Save("bs.xml");
                }
                else MessageBox.Show("The record already exists");
            
            DataBank.in1 = "";
            DataBank.in2 = "";
            DataBank.in3 = "";
            DataBank.in4 = "";
            DataBank.in5 = "";
            DataBank.in6 = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (opendoc)
            {
                ShowRecords();
            }
            else MessageBox.Show("File has not been loaded");
        }
        private void ShowRecords()
        {
            foreach (XElement item in doc.Root.Elements())
            {
                DataBank.Output = DataBank.Output + item.Name.ToString() + " ";
                //textBox.Text = textBox.Text + '\r' + '\n';
                //Выводим все аттрибуты
                foreach (XAttribute attr in item.Attributes())
                {
                    DataBank.Output = DataBank.Output + attr + " ";
                    DataBank.Output = DataBank.Output + '\r' + '\n';
                }

                //Названия всех дочерних элементов
                foreach (XElement el in item.Elements())
                {
                    DataBank.Output = DataBank.Output + el.Name + " " + el.Value + " ";
                    DataBank.Output = DataBank.Output + '\r' + '\n';
                }
                DataBank.Output = DataBank.Output + '\r' + '\n';
            }
            frm2 = new Form2();
            frm2.Show();
            DataBank.Output = "";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            filename = openFileDialog.FileName;
            try
            {
                doc= XDocument.Load(filename);
                opendoc = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
