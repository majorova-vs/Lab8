using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsByLera
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string q1 = "14";
            string q2 = "Name";
            string q3 = "10.01.2020";
            string q4 = "100";
            string q5 = "900";
            string q6 = "365";

            bool excpected = true;

            Lab8.Check check = new Lab8.Check();
            bool actual = Lab8.Check.CheckFullData(q3, q4, q5, q6);
            Assert.AreEqual(excpected, actual);

        }


        [TestMethod]
        public void TestMethod2()
        {
            string q1 = "15";
            string q2 = "Name";
            string q3 = "10.01.2020";
            //string q4 = "100";
            //string q5 = "900";
            //string q6 = "365";
            bool excpected = true;
            Lab8.Check check = new Lab8.Check();
            bool actual = Lab8.Check.CheckData(q1, q2, q3);
            Assert.AreEqual(excpected, actual);
        }
        //введём неправильный дату 
        [TestMethod]
        public void TestMethod3()
        {
            string q1 = "qwertyu";
            string q2 = "Name";
            string q3 = "вталдывьсф";
            string q4 = "100";
            string q5 = "900";
            string q6 = "365";
            bool excpected = false;
            Lab8.Check check = new Lab8.Check();
            bool actual = Lab8.Check.CheckFullData(q3, q4, q5, q6);
            Assert.AreEqual(excpected, actual);
        }
        //Введём пустую строку вместо количества
        [TestMethod]
        public void TestMethod4()
        {
            string q1 = "10";
            string q2 = "";
            string q3 = "10.01.2020";
            string q4 = "";
            string q5 = "900";
            string q6 = "365";
            bool excpected = false;
            Lab8.Check check = new Lab8.Check();
            bool actual = Lab8.Check.CheckFullData(q3, q4, q5, q6);
            Assert.AreEqual(excpected, actual);
        }

        //Введём пустую строку вместо даты
        [TestMethod]
        public void TestMethod5()
        {
            string q1 = "10";
            string q2 = "Name";
            string q3 = "";
            string q4 = "100";
            string q5 = "900";
            string q6 = "365";
            bool excpected = false;
            Lab8.Check check = new Lab8.Check();
            bool actual = Lab8.Check.CheckFullData(q3, q4, q5, q6);
            Assert.AreEqual(excpected, actual);
        }

        //Введём числа вместо имени
        [TestMethod]
        public void TestMethod6()
        {
            string q1 = "10";
            string q2 = "12345";
            string q3 = "15.05.2019";
            string q4 = "100";
            string q5 = "900";
            string q6 = "400";
            bool excpected = false;
            Lab8.Check check = new Lab8.Check();
            bool actual = Lab8.Check.CheckData(q1, q2, q3);
            Assert.AreEqual(excpected, actual);
        }

        //Введём дату больше текущей
        [TestMethod]
        public void TestMethod7()
        {
            string q1 = "10";
            string q2 = "Name";
            string q3 = "15.05.2021";
            string q4 = "100";
            string q5 = "900";
            string q6 = "400";
            bool excpected = true;
            Lab8.Check check = new Lab8.Check();
            bool actual = Lab8.Check.CheckFullData(q3, q4, q5, q6);
            Assert.AreEqual(excpected, actual);
        }
        //Введём некорректную дату 
        [TestMethod]
        public void TestMethod8()
        {
            string q1 = "10";
            string q2 = "Name";
            string q3 = "00.00.00";
            string q4 = "100";
            string q5 = "900";
            string q6 = "400";
            bool excpected = false;
            Lab8.Check check = new Lab8.Check();
            bool actual = Lab8.Check.CheckFullData(q3, q4, q5, q6);
            Assert.AreEqual(excpected, actual);
        }

        //Проверим, как определятся Expirated
        [TestMethod]
        public void TestMethod9()
        {
            string q1 = "10";
            string q2 = "Name";
            string q3 = "15.05.2021";
            string q4 = "100";
            string q5 = "900";
            string q6 = "400";
            bool excpected = true;
            Lab8.Check check = new Lab8.Check();
            bool actual = Lab8.Check.Expirated(q2, q4);
            Assert.AreEqual(excpected, actual);
        }

        //Expirated (если продукт с истекшим сроком годности)
        [TestMethod]
        public void TestMethod10()
        {
            string q3 = "15.05.08";
           
            string q5 = "200";
           
            bool excpected = false;
            
            bool actual = Lab8.Check.Expirated(q3, q5);
            Assert.AreEqual(excpected, actual);
        }
    }
}
