using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2Console;

public interface IObserver
{
    void Update(int overFlowNumber, List<Department> departments = null, List<Employee> employees = null);
}
