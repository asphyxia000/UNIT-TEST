using UNIT_TEST;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace UNIT_TEST
{
    public class Work
    {
        private double salary;
        private double k = 1.1;

        public void Init(double salary1, double k1)
        {
            salary = salary1;
            k = k1;

        }

        public void Read()
        {
            Console.WriteLine("Введите заработную плату: ");
            salary = Convert.ToDouble(Console.ReadLine());
        }
        public double GetSalary()
        {
            return salary;

        }
        public double Getk()
        {
            return k;

        }
        public void Display()
        {
            Console.WriteLine($"Заработная плата: {salary}, Коэффициент квалификации: {k}");
            Console.WriteLine("Зарплата после вычета налога: " + Paysnalog());
            Console.WriteLine("Доплата за квалификацию: " + doplata());
        }

        public double CalculatePayment()
        {
            return salary * k;
        }
        public double Paysnalog()
        {
            double nalog = 13;
            double s = salary * k;
            double n = s * (1 - (nalog / 100));
            return n;
        }
        public double doplata()
        {
            double doplata = 0;
            double doplata2 = salary * k;
            doplata = doplata2 - salary;
            return doplata;
        }

    }

    public class Employer
    {
        private string name;
        public string Name { get { return name; } }
        private Work work1 = new Work();
        private Work work2 = new Work();
        private Work work3 = new Work();

        public void Init(string name1, Work work12, Work work23, Work work34)
        {
            name = name1;
            work1 = work12;
            work2 = work23;
            work3 = work34;

        }

        public void Read()
        {
            Console.WriteLine("Введите имя работодателя: ");
            name = Console.ReadLine();
            work1.Read();
            work2.Read();
            work3.Read();
        }

        public void Display()
        {
            Console.WriteLine($"Работодатель: {name}");
            Console.WriteLine("Работа 1: ");
            work1.Display();
            Console.WriteLine("Работа 2: ");
            work2.Display();
            Console.WriteLine("Работа 3: ");
            work3.Display();
        }


        public double CalculateTotalPayments()
        {
            return work1.CalculatePayment() + work2.CalculatePayment() + work3.CalculatePayment();
        }

        public double SredniyZP()
        {
            return CalculateTotalPayments() / 3;
        }
        public double srdop()
        {
            return (work1.doplata() + work2.doplata() + work3.doplata()) / 3;
        }


        public Work MostExpensiveWork()
        {
            Work mostExpensive = work1;
            double payment1 = work1.CalculatePayment();
            double payment2 = work2.CalculatePayment();
            double payment3 = work3.CalculatePayment();

            if (payment2 > payment1 && payment2 > payment3)
            {
                mostExpensive = work2;
            }
            else if (payment3 > payment1 && payment3 > payment2)
            {
                mostExpensive = work3;
            }

            return mostExpensive;
        }
        public Work MinExpWork()
        {
            Work minExp = work1;
            double exp = work1.CalculatePayment();
            double exp2 = work2.CalculatePayment();
            double exp3 = work3.CalculatePayment();
            if (exp2 < exp && exp2 < exp3)
            {
                minExp = work2;
            }
            else if (exp3 < exp2 && exp3 < exp)
            {
                minExp = work3;
            }

            return minExp;

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Employer employer = new Employer();
            Work work1 = new Work();
            Work work2 = new Work();
            Work work3 = new Work();

            Console.WriteLine("Введите детали для Работы 1:");
            work1.Read();

            Console.WriteLine("Введите детали для Работы 2:");
            work2.Read();

            Console.WriteLine("Введите детали для Работы 3:");
            work3.Read();

            Console.WriteLine("Введите имя работодателя: ");
            string employerName = Console.ReadLine();

            employer.Init(employerName, work1, work2, work3);

            employer.Display();

            double totalPayments = employer.CalculateTotalPayments();
            Console.WriteLine($"Общие выплаты для всех сотрудников: {totalPayments}");

            Work mostExpensiveWork = employer.MostExpensiveWork();
            Console.WriteLine("Самая дорогая работа: ");
            mostExpensiveWork.Display();

            Work minexp = employer.MinExpWork();
            Console.WriteLine("Самая дешёвая работа: ");
            minexp.Display();

            double SR = employer.SredniyZP();
            Console.WriteLine("Средняя ЗП по 3 работам: " + Math.Round(SR, 2));

            double SRDOP = employer.srdop();
            Console.WriteLine("Средняя доплата за 3 работы: " + Math.Round(SRDOP, 2));
        }
    }
}
