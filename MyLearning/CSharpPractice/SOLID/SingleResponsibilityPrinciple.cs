using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.SOLID
{
    internal class SingleResponsibilityPrinciple
    {
        // A class should have only one reason to change, meaning it should have one responsibility.

        // Problem
        public class Employee
        {
            public string Name { get; set; }

            public void SaveToDatabase() => Console.WriteLine("Employee data saved  to database.");
        }

        // Fix
        public class Employee2
        {
            public string Name { get; set; }
        }

        public class EmployeeRepository
        {
            public void Save(Employee employee)
            {
                Console.WriteLine($"Employee {employee.Name} saved to database.");
            }
        }
    }
}
