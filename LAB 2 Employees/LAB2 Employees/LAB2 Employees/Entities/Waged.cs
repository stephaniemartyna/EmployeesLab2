using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2_Employees.Entities
{
    /// CPRG211 Lab 2: Inheritance
    /// <remarks>Author: Stephanie Martyna
    /// <remarks>Date: February 2, 2023
    internal class Waged : Employee
    {
        private double rate;
        private double hours;

        public double Rate
        {
            get { return rate; }
        }

        public double Hours
        {
            get { return hours; }
        }

        public override double Pay
        {
            get
            {
                double pay;
                double rate = this.Rate;
                double hours = this.Hours;

                if (hours > 40)
                {
                    double overtimeHours = hours - 40;
                    double overtimePay = overtimeHours * (rate * 1.5);

                    pay = rate * 40;
                    pay += overtimePay;
                }
                else
                {
                    pay = rate * hours;
                }

                return pay;
            }
        }

        public Waged(string id, string name, double rate, double hours) : base(id, name)
        {
            this.rate = rate;
            this.hours = hours;
        }

    }
}
