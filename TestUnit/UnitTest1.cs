using UNIT_TEST;
namespace TestUnit
{
    [TestClass]
    public class WorkTest
    {
        [TestMethod]
        public void Test1_CalculatePayment()
        {
            //arrange
            double salary = 1000;
            double k = 1.1;
            double exp = 1100;

            //act
            Work c = new Work();
            c.Init(salary, k);
            double actual = c.CalculatePayment();

            //assert
            Assert.AreEqual(exp, actual);
        }
        [TestMethod]
        public void Test2_Read()
        {
            Work work = new Work();
            Console.SetIn(new StringReader("1200\n1.1"));
            work.Read();
            Assert.AreEqual(1200, work.GetSalary());
            Assert.AreEqual(1.1, work.Getk());
        }

        [TestMethod]
        public void Test3_Init()
        {
            Work work = new Work();
            work.Init(1200, 1.1);
            Assert.AreEqual(1200, work.GetSalary());
            Assert.AreEqual(1.1, work.Getk());

        }
        [TestMethod]
        public void Test4_CalculateTotalPayments()
        {
            Work work1 = new Work();
            work1.Init(1000, 1.2);
            Work work2 = new Work();
            work2.Init(2000, 1.1);
            Work work3 = new Work();
            work3.Init(3000, 1.3);
            Employer emp = new Employer();
            emp.Init("Test2", work1, work2, work3);

            double total = emp.CalculateTotalPayments();
            Assert.AreEqual(7300, total);
        }
        [TestMethod]
        public void Test5_MostExpWork()
        {
            Work work1 = new Work();
            work1.Init(1000, 1.2);
            Work work2 = new Work();
            work2.Init(2000, 1.1);
            Work work3 = new Work();
            work3.Init(3000, 1.3);
            Employer emp = new Employer();
            emp.Init("Test2", work1, work2, work3);

            Work mew = emp.MostExpensiveWork();
            Assert.AreEqual(work3, mew);

        }

        [TestMethod]
        public void Test6_nalogy()
        {
            double salary = 1000;
            double k = 1.1;
            double exp = 957;

            Work c = new Work();
            c.Init(salary, k);
            double actual = c.Paysnalog();
            Assert.AreEqual(exp, actual);
        }
        [TestMethod]
        public void Test7_minexp()
        {
            Work work1 = new Work();
            work1.Init(1000, 1.2);
            Work work2 = new Work();
            work2.Init(2000, 1.1);
            Work work3 = new Work();
            work3.Init(3000, 1.3);
            Employer emp = new Employer();
            emp.Init("Test2", work1, work2, work3);

            Work mew = emp.MinExpWork();
            Assert.AreEqual(work1, mew);
        }
        [TestMethod]
        public void Test8_doplata()
        {
            double salary = 1000;
            double k = 1.1;
            double exp = 100;

            Work c = new Work();
            c.Init(salary, k);
            double actual = c.doplata();

            Assert.AreEqual(exp, actual);

        }
        [TestMethod]
        public void Test9_SR()
        {
            Work work1 = new Work();
            work1.Init(35000, 1.1);
            Work work2 = new Work();
            work2.Init(50000, 1.1);
            Work work3 = new Work();
            work3.Init(33000, 1.1);
            Employer emp = new Employer();
            emp.Init("Test2", work1, work2, work3);

            double sr = emp.SredniyZP();
            Assert.AreEqual(43266.67, Math.Round(sr, 2));
        }
        [TestMethod]
        public void Test10_SRDOP()
        {

            Work work1 = new Work();
            work1.Init(35000, 1.1);
            Work work2 = new Work();
            work2.Init(50000, 1.2);
            Work work3 = new Work();
            work3.Init(33000, 1.3);
            Employer emp = new Employer();
            emp.Init("Test2", work1, work2, work3);

            double sr = emp.srdop();
            Assert.AreEqual(7800, Math.Round(sr, 2));
        }
    }

}