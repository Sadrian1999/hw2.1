using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HW2Console
{
    public class ListAll : MenuItem
    {
        public ListAll(Company company) : base(company)
        {
            Name = "List Entities";
        }

        public override Company ExecuteCommand()
        {
            _company.MainDepartment.ListEntities().ForEach(x => Console.WriteLine(x));
            return _company;
        }
    }
}
