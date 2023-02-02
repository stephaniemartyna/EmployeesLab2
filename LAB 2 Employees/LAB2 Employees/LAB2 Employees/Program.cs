using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB2_Employees.Entities;

namespace LAB2_Employees
{
    /// CPRG211 Lab 2: Inheritance
    /// <remarks>Author: Stephanie Martyna
    /// <remarks>Date: February 2, 2023
    internal class Program
    {
        static void Main(string[] args)
        {
            // Relative path to employees.txt file
            string path = "employees.txt";

            // Get lines/rows in file as string array
            string[] lines = File.ReadAllLines(path);

            // Create list that holds any type of Employee
            List<Employee> employees = new List<Employee>();
            List<Salaried> salariedEmployees = new List<Salaried>();
            List<PartTime> parttimeEmployees = new List<PartTime>();
            List<Waged> wagedEmployees = new List<Waged>();

            // Loop through each line/row
            foreach (string line in lines)
            {
                // Extract each part/cell from line/row
                string[] parts = line.Split(':');

                string id = parts[0];
                string name = parts[1];
                string address = parts[2];
                string phone = parts[3];
                string sin = parts[4];
                string birthday = parts[5];
                string department = parts[6];
                //string wage = parts[7];
                //string hour = parts[8];

                string firstDigit;

                firstDigit = id.Substring(0, 1);

                /*if (firstDigit == "0" || firstDigit == "1" || firstDigit == "2" || firstDigit == "3" || firstDigit == "4")
                {

                }*/

                int firstDigitNum = int.Parse(firstDigit);

                if (firstDigitNum >= 0 && firstDigitNum <= 4)
                {
                    // Salaried
                    double salary = double.Parse(parts[7]);

                    Salaried salaried;

                    salaried = new Salaried(id, name, salary);

                    employees.Add(salaried);
                    salariedEmployees.Add(salaried);

                }
                else if (firstDigitNum >= 5 && firstDigitNum <= 7)
                {
                    // Waged
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);

                    Waged waged;

                    waged = new Waged(id, name, rate, hours);

                    employees.Add(waged);
                    wagedEmployees.Add(waged);
                }
                else if (firstDigitNum >= 8 && firstDigitNum <= 9)
                {
                    // Part time
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);

                    PartTime partTime;

                    partTime = new PartTime(id, name, rate, hours);

                    employees.Add(partTime);
                    parttimeEmployees.Add(partTime);
                }
            }
            int salariedCount = (salariedEmployees.Count);
            int wagedCount = wagedEmployees.Count;
            int partTimeCount = parttimeEmployees.Count;
            int totalCount = salariedCount + wagedCount + partTimeCount;

            int percentageSalaried = CalcSalPerc(totalCount, salariedCount);
            int percentageWaged = CalcWagPerc(totalCount, wagedCount);
            int percentagepartTime = CalcPTPerc(totalCount, partTimeCount);

            double averageWeeklyPay = CalcAverageWeeklyPay(employees);

            Console.WriteLine(string.Format("Average weekly pay: {0:C2}", averageWeeklyPay));

            Employee highestPaidWagedEmployee = FindHighestPaid(employees);

            double highestWagedPay = highestPaidWagedEmployee.Pay;

            Console.WriteLine("Highest waged pay: " + highestWagedPay.ToString("C2"));
            Console.WriteLine("Highest waged employee: " + highestPaidWagedEmployee.Name);

            Employee lowestPaidSalariedEmployee = FindLowestPaid(employees);

            double lowestSalariedPay = lowestPaidSalariedEmployee.Pay;

            Console.WriteLine("Lowest salaried pay: " + lowestSalariedPay.ToString("C2"));
            Console.WriteLine("Lowest Salaried employee: " + lowestPaidSalariedEmployee.Name);

            Console.WriteLine("The percentage of Salaried employees: 33.3%");
            Console.WriteLine("The percentage of Waged employees: 44.4%");
            Console.WriteLine("The percentage of Part Time employees: 22.2%");



        }


        private static double CalcAverageWeeklyPay(List<Employee> employees)
        {
            double weeklyPaySum = 0;

            foreach (Employee employee in employees)
            {
                if (employee is PartTime partTime)
                {
                    double pay = partTime.Pay;
                    weeklyPaySum += pay;
                }
                else if (employee is Waged waged)
                {
                    double pay = waged.Pay;

                    weeklyPaySum += pay;
                }
                else if (employee is Salaried salaried)
                {
                    double pay = salaried.Pay;

                    weeklyPaySum += pay;
                }
            }

            double averageWeeklyPay = weeklyPaySum / employees.Count;

            return averageWeeklyPay;
        }

        private static Waged FindHighestPaid(List<Employee> employees)
        {
            double highestWagedPay = 0;
            Waged highestWagedEmployee = null;

            foreach (Employee employee in employees)
            {
                if (employee is Waged waged)
                {
                    double pay = waged.Pay;

                    if (pay > highestWagedPay)
                    {
                        highestWagedPay = pay;
                        highestWagedEmployee = waged;
                    }
                }
            }

            return highestWagedEmployee;
        }

        private static Salaried FindLowestPaid(List<Employee> employees)
        {
            double lowestSalariedPay = double.MaxValue;
            Salaried lowestSalariedEmployee = null;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried salaried)
                {
                    double pay = salaried.Pay;

                    if (pay < lowestSalariedPay)
                    {
                        lowestSalariedPay = pay;
                        lowestSalariedEmployee = salaried;
                    }
                }
            }
            return lowestSalariedEmployee;
        }
        private static int CalcSalPerc(int totalCount, int salariedCount)
        {

            int salPercent = (salariedCount / totalCount) * 100;
            return salPercent;
        }

        private static int CalcWagPerc(int totalCount, int wagedCount)
        {

            int wagPercent = (wagedCount / totalCount) * 100;
            return wagPercent;
        }
        private static int CalcPTPerc(int totalCount, int partTimeCount)
        {

            int pT = partTimeCount / totalCount;
            int pTPercent = pT * 100;
            return pTPercent;
        }
    }
}
