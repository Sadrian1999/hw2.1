using HW2Console.Commands;
using System.Diagnostics;

namespace HW2Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Run();
        }
    }
}