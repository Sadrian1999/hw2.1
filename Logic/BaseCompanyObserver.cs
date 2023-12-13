using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2Console;

public abstract class BaseCompanyObserver : IObserver
{
    protected int _overFlowNumber;
    protected List<Employee> _employees;
    protected List<Department> _departments;
    public void Update(int overFlowNumber, List<Department> departments = null, List<Employee> employees = null)
    {
        _overFlowNumber = overFlowNumber;
        _employees = employees;
        _departments = departments;
    }

}
