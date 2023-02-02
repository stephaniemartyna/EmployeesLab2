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
    internal class Employee
    {
        protected string id;
        protected string name;

        public string Id
        {
            get { return id; }
        }

        public string Name
        {
            get => name;
        }

        public virtual double Pay
        {
            get
            {
                return 0;
            }
        }

        public Employee(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
