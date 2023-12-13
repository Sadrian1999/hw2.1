using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HW2Console
{
    public class Menu
    {
        private List<MenuItem> menuItems = new();
        private Company _company = new();
        private PrintObserver _printObserver = new();
        private NumberObserver _numberObserver = new();

        public void Run()
        {
            _company.Subscribe(_printObserver);
            _company.Subscribe(_numberObserver);
            menuItems.Add(new AddEmployeeMenu(_company));
            menuItems.Add(new AddDepartmentMenu(_company));
            menuItems.Add(new ListAll(_company));

            while(true)
            {
                ShowMenu();
                Console.Write("Type 'exit' to close the program\nCommand: ");
                string input = Console.ReadLine();
                string errorMsg = ErrorHandling(input);
                if (input == "exit") break;
                if (errorMsg != null)
                {
                    Console.WriteLine(errorMsg);
                    Thread.Sleep(500);
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Execute(int.Parse(input));
                    Console.WriteLine("\nPress a button to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        private void ShowMenu()
        {
            int i = 1;
            menuItems.ForEach(x => Console.WriteLine(i++ + " " +x.Name));
        }
        private void Execute(int number)
        {
            _company = menuItems[number - 1].ExecuteCommand();
            if (menuItems[number - 1].GetType() != typeof(ListAll)) Update();
        }
        private void Update()
        {
            if (_company.MainDepartment.NotificationData != null)
            {
                _company.Notify();
                Console.WriteLine($"{_printObserver.PrintData()}\n\nThe limit was exceeded by {_numberObserver.PrintOverFlowNumber()}");
            }
        }
        private string ErrorHandling(string input)
        {
            if (!int.TryParse(input, out int result))
            {
                return "It's not a number! Try again!";
            }
            if (result < 0 || result > menuItems.Count) 
            {
                return "Invalid number: out of range!";
            }
            return null;
        }
    }
}
