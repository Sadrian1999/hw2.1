using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2Console
{
    abstract public class MenuItem
    {
        protected Company _company;

        public string Name;

        public MenuItem(Company company) { _company = company; }

        abstract public Company ExecuteCommand();
    }
}
