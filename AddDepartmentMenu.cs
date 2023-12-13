using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2Console
{
    public class AddDepartmentMenu : MenuItem
    {
        public AddDepartmentMenu(Company company) : base(company)
        {
            Name = "Add Department";
        }

        public override Company ExecuteCommand()
        {
            _company.MainDepartment.AddEntity(CreateDepartment(_company));
            return _company;
        }

        public static Department CreateDepartment(Company _company)
        {
            Department department;
            Console.Write("Name: ");
            string dpName = Console.ReadLine();

            Console.Write("Parent department: ");
            Department dp = _company.MainDepartment.FindDepartment(Console.ReadLine());
            while (dp == null)
            {
                Console.WriteLine("Invalid department, try again!");
                Thread.Sleep(500);
                dp = _company.MainDepartment.FindDepartment(Console.ReadLine());
            }
            department = new(dp) { Name = dpName };
            Console.Write("Max number of employees: ");
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("It's not a number! Try again!");
            }
            department.MaxNumberOfEmployees = result;

            Console.WriteLine("Shall we add employees right now? y/n");
            string input = Console.ReadLine();
            if (input == "y"){
                Console.WriteLine("How many?");
                int number = int.Parse(Console.ReadLine());
                List<Employee> employees = new List<Employee>();
                Enumerable.Repeat(0, number).ToList().ForEach(_ => employees.Add(AddEmployeeMenu.CreateEmployee(_company, department)));
                department.AddEntity(employees);
            }
            
            return department;
        }

    }
}
