using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2Console
{
    public class AddEmployeeMenu : MenuItem
    {
        public AddEmployeeMenu(Company company) : base(company)
        {
            Name = "Add Employee";
        }

        public override Company ExecuteCommand()
        {
            Console.WriteLine("How many employees do you want to add?");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Department: ");
            Department dp = _company.MainDepartment.FindDepartment(Console.ReadLine());
            while (dp == null)
            {
                Console.WriteLine("Invalid department, try again!");
                Thread.Sleep(500);
                dp = _company.MainDepartment.FindDepartment(Console.ReadLine());
            }

            List<Employee> employees = new List<Employee>();
            Enumerable.Repeat(0, number).ToList().ForEach(_ => employees.Add(AddEmployeeMenu.CreateEmployee(_company, dp)));

            _company.MainDepartment.AddEntity(employees);
            return _company;
        }
        public static Employee CreateEmployee(Company _company, Department department = null)
        {
            Employee employee = new Employee();

            Console.Write("Name: ");
            employee.Name = Console.ReadLine();

            if (department != null) { employee.Department = department; }
            else
            {
                Console.Write("Department: ");
                Department dp = _company.MainDepartment.FindDepartment(Console.ReadLine());
                while (dp == null)
                {
                    Console.WriteLine("Invalid department, try again!");
                    Thread.Sleep(500);
                    dp = _company.MainDepartment.FindDepartment(Console.ReadLine());
                }
                employee.Department = dp;
            }
            Console.Write("Start of work: ");
            bool isDateOkay = DateTime.TryParse(Console.ReadLine(), out DateTime dt);
            while (!isDateOkay)
            {
                Console.WriteLine("Invalid dateformat, try again!");
                Thread.Sleep(500);
                isDateOkay = DateTime.TryParse(Console.ReadLine(), out dt);
            }
            employee.StartOfWork = dt;

            return employee;
        }
    }
}
