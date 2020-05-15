using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab8
{
    public class Check
    {
       static DateTime  currentdate = DateTime.Now;
        public static bool CheckData(string q1, string q2, string q3)
        {
            bool flag = false;

            if (q1.Length != 0)
            {
                foreach (char c in q1)
                {
                    if (c < '0' || c > '9')
                    {
                        MessageBox.Show("DrugStore ID is invalid");
                        return false;
                    }
                    //flag = false;

                }
                // (flag == false)
                // MessageBox.Show("DrugStore ID is invalid");
            }
            else
            { MessageBox.Show("DrugStore ID is invalid"); return false; }

            if (q2.Length != 0 && Char.IsLetter(q2, 0))
            {
                flag = true;
            }
            else
            {
                MessageBox.Show("Medicine name is invalid");
                return false;
            }
            try
            {
                
                if (DateTime.Parse(q3) <= currentdate)
                    flag = true;
                else
                {
                    MessageBox.Show("Date is invalid");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Date is invalid");
                return false;
            }
            return true;

        }

        public static bool CheckFullData(string q3, string q4, string q5, string q6)
        {
            bool flag = false;

            if (q4.Length != 0)
            {
                foreach (char c in q4)
                {
                    if (c < '0' || c > '9')
                    {
                        MessageBox.Show("Amount of product is invalid");
                        return false;
                    }

                }
                //if (flag == false)
                  //  MessageBox.Show("Amount of product is invalid");
            }
            else
            { MessageBox.Show("Amount of product is invalid"); return false; }

            if (q5.Length != 0)
            {
                foreach (char c in q5)
                {
                    if (c < '0' || c > '9')
                    {
                        MessageBox.Show("Price is invalid");
                        return false;
                    }

                }
               // if (flag == false)
                   // MessageBox.Show("Price is invalid");
            }
            else
            {  MessageBox.Show("Price is invalid"); return false; }

            if (q6.Length != 0)
            {
                foreach (char c in q6)
                {
                    if (c < '0' || c > '9')
                    {
                        MessageBox.Show("Price is invalid");
                        return false;
                    }
                    else if (Expirated(q3, q6))
                    {
                        return false;
                        // MessageBox.Show("The medicine has expired");
                    }

                }
                //if (flag == false)
                   // MessageBox.Show("Storage period is invalid");
            }
            else { MessageBox.Show("Storage period is invalid"); return false; }


            return true;

        }
        public static bool IDCheck(string q1, XDocument doc)
        {
            string info = "";
            IEnumerable<XElement> Medicine =
                 from el in doc.Root.Elements("Medicine")
                 where (string)el.Attribute("DrugStoreId") == q1
                 select el;
            foreach (XElement el in Medicine)
                info += el;
            if (info == "")
                return true;
            else
                return false;

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
