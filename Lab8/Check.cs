using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab8
{
    class Check
    {
       static DateTime  currentdate = DateTime.Now;
        public static bool CheckData(string q1, string q2, string q3)
        {
            bool flag = true;


            if (q1.Length != 0)
            {
                foreach (char c in q1)
                {
                    if (c < '0' || c > '9')
                        flag = false;

                }
                if (flag == false)
                    MessageBox.Show("DrugStore ID is invalid");
            }
            else flag = false;

            if (q2.Length != 0 && Char.IsLetter(q2, 0))
            {
                flag = true;
            }
            else
            {
                MessageBox.Show("Medicine name is invalid");
                flag = false;
            }
            try
            {
                
                if (DateTime.Parse(q3) <= currentdate)
                    flag = true;
                else
                {
                    MessageBox.Show("Date is invalid");
                    flag = false;
                }
            }
            catch
            {
                MessageBox.Show("Date is invalid");
                flag = false;
            }
            return flag;

        }

        public static bool CheckFullData(string q1, string q2, string q3, string q4, string q5, string q6)
        {
            bool flag = true;


            if (q1.Length != 0)
            {
                foreach (char c in q1)
                {
                    if (c < '0' || c > '9')
                        flag = false;

                }
                if (flag == false)
                    MessageBox.Show("DrugStore ID is invalid");
            }
            else flag = false;

            if (q2.Length != 0 && (q2.Any(c => char.IsLetter(c))))
            {
                flag = true;
            }
            else
            {
                MessageBox.Show("Medicine name is invalid");
                flag = false;
            }
            try
            {
                
                if (DateTime.Parse(q3)<= currentdate)
                    flag = true;
                else
                {
                    MessageBox.Show("Date is invalid");
                    flag = false;
                }
            }
            catch
            {
                MessageBox.Show("Date is invalid");
                flag = false;
            }
            if (q4.Length != 0)
            {
                foreach (char c in q1)
                {
                    if (c < '0' || c > '9')
                        flag = false;

                }
                if (flag == false)
                    MessageBox.Show("Amount of product is invalid");
            }
            else
            { flag = false; MessageBox.Show("Amount of product is invalid"); }

            if (q5.Length != 0)
            {
                foreach (char c in q1)
                {
                    if (c < '0' || c > '9')
                        flag = false;

                }
                if (flag == false)
                    MessageBox.Show("Price is invalid");
            }
            else
            { flag = false; MessageBox.Show("Price is invalid"); }

            if (q6.Length != 0)
            {
                foreach (char c in q1)
                {
                    if (c < '0' || c > '9')
                        flag = false;
                    else if (Expirated(q3, q6))
                    { 
                        flag = false; 
                       // MessageBox.Show("The medicine has expired");
                    }

                }
                if (flag == false)
                    MessageBox.Show("Storage period is invalid");
            }
            else { flag = false; MessageBox.Show("Storage period is invalid"); }


            return flag;

        }

        public static bool FindMatch(string q1, string q2, string q3,  XDocument doc)
        {
            string info = "";
            IEnumerable<XElement> Medicine =
                 from el in doc.Root.Elements("Medicine")
                 where (string)el.Attribute("DrugStoreId") == q1 &&
                 (string)el.Attribute("MedicineName") == q2 &&
                (string)el.Attribute("DateArrival") == q3
                 select el;
            foreach (XElement el in Medicine)
                info += el;
            if (info == "")
                return true;
            else
                return false;
        }

        public static bool Expirated(string ardate,string store)
        {
            try
            {
                if (DateTime.Parse(ardate).AddDays(Double.Parse(store)) > currentdate)
                    return false;
                else return true;
            }
            catch { return true; }
            
        }
    }
}
