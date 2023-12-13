using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2Console;

public class NotificationData
{
    private int _overFlowNumber;
    private List<Employee> _employees = new();
    private List<Department> _departments = new();

    public int OverFlowNumber { get => _overFlowNumber; }
    public List<Employee> Employees { get => _employees; }
    public List<Department> Departments { get => _departments; }

    public NotificationData(int overFlowNumber, Department department = null, Employee employee = null)
    {
        _overFlowNumber = overFlowNumber;
        if (employee != null) _employees.Add(employee);
        if (department != null) _departments.Add(department);
    }

    public NotificationData(int overFlowNumber, List<Department> departments = null, List<Employee> employees = null)
    {
        _overFlowNumber = overFlowNumber;
        if (employees != null)_employees.AddRange(employees);
        if (departments != null) _departments.AddRange(departments);
    }
}
