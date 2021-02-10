using System;
using System.Globalization;

namespace Exercise04.Entities
{
    class Employee: IComparable
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string csvEmployee)
        {
            string[] employeeData = csvEmployee.Split(',');
            Name = employeeData[0];
            Salary = double.Parse(employeeData[1], CultureInfo.InvariantCulture);
        }

        public override string ToString()
        {
            return Name + " , $" + Salary.ToString("f2", CultureInfo.InvariantCulture);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Employee))
                throw new ArgumentException("Comparing error: argumento is not an employee");

            Employee other = obj as Employee;

            return Name.CompareTo(other.Name);

        }
    }
}
