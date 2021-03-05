using System;
using System.Collections.Generic;

namespace CompositePattern
{
    class Employee
    {
        private string name;
        private string dept;
        private int salary;
        private List<Employee> _subordinates;

        public Employee(string name, string dept, int salary)
        {
            this.name = name;
            this.dept = dept;
            this.salary = salary;
            _subordinates = new List<Employee>();
        }

        public void Add(Employee employee)
        {
            _subordinates.Add(employee);
        }
        public void Remove(Employee employee)
        {
            _subordinates.Remove(employee);
        }

        public List<Employee> GetSubordinates()
        {
            return _subordinates;
        }

        public void Display()
        {
            Console.WriteLine("Employee :[ Name : {0}, dept : {1}, salary : {2} ].", this.name, this.dept, this.salary);
        }
    }
	
    class Program
    {
        static void Main(string[] args)
        {
            Employee CEO = new Employee("John", "CEO", 30000);

            Employee headSales = new Employee("Robert", "Head Sales", 20000);

            Employee headMarketing = new Employee("Michel", "Head Marketing", 20000);

            Employee clerk1 = new Employee("Laura", "Marketing", 10000);
            Employee clerk2 = new Employee("Bob", "Marketing", 10000);

            Employee salesExecutive1 = new Employee("Richard", "Sales", 10000);
            Employee salesExecutive2 = new Employee("Rob", "Sales", 10000);

            CEO.Add(headSales);
            CEO.Add(headMarketing);

            headSales.Add(salesExecutive1);
            headSales.Add(salesExecutive2);

            headMarketing.Add(clerk1);
            headMarketing.Add(clerk2);

            CEO.Display();

            foreach(Employee headEmployee in CEO.GetSubordinates())
            {
                headEmployee.Display();
                foreach(Employee employee in headEmployee.GetSubordinates())
                {
                    employee.Display();
                }
            }
        }
    }
}

/*
Output:
Employee :[ Name : John, dept : CEO, salary : 30000 ].
Employee :[ Name : Robert, dept : Head Sales, salary : 20000 ].
Employee :[ Name : Richard, dept : Sales, salary : 10000 ].
Employee :[ Name : Rob, dept : Sales, salary : 10000 ].
Employee :[ Name : Michel, dept : Head Marketing, salary : 20000 ].
Employee :[ Name : Laura, dept : Marketing, salary : 10000 ].
Employee :[ Name : Bob, dept : Marketing, salary : 10000 ].
*/