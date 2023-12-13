using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2Console; 

public class PrintObserver : BaseCompanyObserver
{
    public string PrintData()
    {
        string str = "";
        if (_departments != null)
        {
            _departments.ForEach(x => str += $"{x.Name}; ");         
        }
        else 
        {
            _employees.ForEach(x => str += $"{x.Name}; ");
        }
        return str;
    }
}
