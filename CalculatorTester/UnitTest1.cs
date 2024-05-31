using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTester
{
    [TestClass]
    public class UnitTest1
    {
        private Calculation c;

        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                      @".\Data\TestData2.csv", "TestData2#csv", DataAccessMethod.Sequential)]
        [TestInitialize]
        public void SetUp()
        {
            c = new Calculation(10, 5);
        }
        //Trường hợp Test Đúng: Expected và Actual ra cùng một kết quả
        [TestMethod]               //TestCase số 1
        public void Test_Cong() {
            int expected, actual;
            //Calcution c = new Calculation(a, b)
            expected = 15;
            actual = c.Execute("+");
            Assert.AreEqual(expected, actual);
        }
        //Trường hợp Test Sai: Expected và Actual ra khác kết quả
        [TestMethod]           //TestCase số 2
        public void Test_Tru()
        {
            int expected, actual;
            //Calcution c = new Calculation(a, b)
            expected = 5;
            actual = c.Execute("-");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]         //TestCase số 3
        public void Test_Nhan()
        {
            int expected, actual;
            //Calcution c = new Calculation(a, b)
            expected = 50;
            actual = c.Execute("*");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]        //TestCase số 4
        public void Test_Chia()
        {
            int expected, actual;
            //Calcution c = new Calculation(a, b)
            expected = 2;
            actual = c.Execute("/");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]                //TestCase số 5
        //Trường hợp ngoại lệ chia cho DivideByZeroException
        [ExpectedException(typeof(DivideByZeroException))]
        public void Test_ChiaZero()
        {
            c = new Calculation(10, 0);
            c.Execute("/");
        }



       /* [TestMethod] */           //TestCase số 6
        public void TestWithDataSource()
        {
            int a = int.Parse(TestContext.DataRow[0].ToString());
            int b = int.Parse(TestContext.DataRow[1].ToString());
            int expected = int.Parse(TestContext.DataRow[2].ToString());

            Calculation c = new Calculation(a, b);
            int actual = c.Execute("+");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]            //TestCase số 7
        public void TestWithDataSource2()
        {
                int a = int.Parse(TestContext.DataRow[0].ToString());
                int b = int.Parse(TestContext.DataRow[1].ToString());
                string operation = TestContext.DataRow[2].ToString().Remove(0,1);
                int expected = int.Parse(TestContext.DataRow[3].ToString());

                Calculation c = new Calculation(a, b);
                int actual = c.Execute(operation);
                Assert.AreEqual(expected, actual);
        }


    } 
}
