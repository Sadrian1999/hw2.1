using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2Console;

public class NumberObserver : BaseCompanyObserver
{
    public int PrintOverFlowNumber()
    {
        if (_employees != null)
        {
            return _overFlowNumber  - _employees[0].Department.MaxNumberOfEmployees;
        }
        return _overFlowNumber - _departments[0].MaxNumberOfEmployees;
    }
}
