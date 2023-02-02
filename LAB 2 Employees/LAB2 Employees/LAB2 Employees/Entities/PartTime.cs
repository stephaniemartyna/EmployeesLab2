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
    internal class PartTime : Employee
    {
        // TODO: Add remaining fields, properties, and constructor parameters for part-time employee.
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
                double rate = this.Rate;
                double hours = this.Hours;

                double pay = rate * hours;

                return pay;
            }
        }

        /// <summary>
        /// User-defined constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="rate"></param>
        public PartTime(string id, string name, double rate, double hours) : base(id, name)
        {
            this.rate = rate;
            this.hours = hours;
        }
    }
}
