using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2Console;
public class Department : IComponent, IPass
{
    private int _maxNumberOfEmployees;
    private string _name;
    private List<Employee> _employees = new List<Employee>();
    private List<Department> _departments = new List<Department>();
    private NotificationData _notificationData = null;
    private Department _parentDepartment;

    public int MaxNumberOfEmployees { get => _maxNumberOfEmployees; set => _maxNumberOfEmployees = value; }
    public string Name { get => _name; set => _name = value; }
    public List<Department> Departments { get => _departments; set => _departments = value; }
    public Department ParentDepartment => _parentDepartment;
    public List<Employee> Employees { get => _employees; set => _employees = value; }
    public NotificationData NotificationData { get => _notificationData; set => _notificationData = value; }

    public Department(Department parent)
    {
        _parentDepartment = parent;
    }

    public bool IsDepartmentExsists(string givenName)
    {
        if (givenName == _name) return true;
        else if (_departments.Count > 0)
        {
            return _departments.Any(x => x.IsDepartmentExsists(givenName));
        }
        else return false;
    }
    public Department FindDepartment(string name) 
    {
        if (_name == name) return this;
        else if (_departments.Count > 0)
        {
            foreach (var department in _departments) 
            {
                return department.FindDepartment(name);
            }
        }
        return null;
    }
    public void AddEntity(Employee employee)
    {
        int overFlowNumber = CalculateSum() + employee.CalculateSum();
        if (employee != null && overFlowNumber <= MaxNumberOfEmployees)
        {
            FindDepartment(employee.Department.Name).Employees.Add(employee);
        }
        else
        {
            NotifyParent(new NotificationData(overFlowNumber, null, employee));
        }
        
    }        
    public void AddEntity(Department department)
    {
        int overFlowNumber = CalculateSum() + department.CalculateSum();
        if (department != null && overFlowNumber <= MaxNumberOfEmployees)
        {
            FindDepartment(department.ParentDepartment.Name).Departments.Add(department);    
        }
        else
        {
            NotifyParent(new NotificationData(overFlowNumber, department));
        }
    }

    public void AddEntity(List<Department> departments)
    {
        int overFlowNumber = CalculateSum() + departments.Sum(x => x.CalculateSum());
        if (departments != null && overFlowNumber <= MaxNumberOfEmployees)
        {
            FindDepartment(departments[0].ParentDepartment.Name).Departments.AddRange(departments);    
        }
        else
        {
            NotifyParent(new NotificationData(overFlowNumber, departments));
        }
    }
    public void AddEntity(List<Employee> employees)
    {
        int overFlowNumber = CalculateSum() + employees.Count;
        if (employees != null && overFlowNumber <= MaxNumberOfEmployees)
        {
            FindDepartment(employees[0].Department.Name).Employees.AddRange(employees);    
        }
        else
        {
            NotifyParent(new NotificationData(overFlowNumber, null, employees));
        }
    }

    
    public void RemoveEntity(Department department = null, Employee employee = null)
    {
        if (employee != null)
        {
            if (employee != null && _employees.Contains(employee))
            {
                _employees.Remove(employee);
            }
        }
        else if (department != null) 
        {
            if (department != null && _departments.Contains(department))
            {
                _departments.Remove(department);
            }
        }
    }
    public List<string> ListEntities()
    {
        List<string> entities = new() {$"Dep {Name} | Max: {MaxNumberOfEmployees} | Current: {CalculateSum()} | PossibleMax: {CalculatePossibleMax()}" };
        _employees.ForEach(x => entities.Add($"Emp {x.Name}"));
        _departments?.ForEach(x => entities.AddRange(x.ListEntities()));
        return entities;
    }
    public int CalculateSum()
    {
        return _employees.Count + _departments.Sum(x =>x.CalculateSum());
    }
    public void NotifyParent(NotificationData notificationData)
    {
        if (_parentDepartment == null) _notificationData = notificationData;
        else
        {
            _parentDepartment.NotifyParent(notificationData);
        }
    }
    public int CalculatePossibleMax()
    {
        if (_parentDepartment == null) return MaxNumberOfEmployees;
        return _parentDepartment.CalculatePossibleMax() - MaxNumberOfEmployees;
    }
}

