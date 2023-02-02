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
    internal class Salaried : Employee
    {
        // TODO: Add remaining fields, properties, and constructor parameters for salaried employee.
        private double salary;

        public double Salary
        {
            get
            {
                return salary;
            }
        }

        public override double Pay
        {
            get
            {
                return salary;
            }
        }

        /// <summary>
        /// User-defined constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="salary"></param>
        public Salaried(string id, string name, double salary) : base(id, name)
        {
            this.salary = salary;
        }
    }
}
