using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2Console;
public class Company : ISubject
{
    private Department _mainDepartment = new(null) { MaxNumberOfEmployees = 20, Name = "Main"};
    private List<IObserver> _observers = new();

    public Department MainDepartment { get => _mainDepartment; set => _mainDepartment = value; }

    public void Subscribe(IObserver observer)
    {
        _observers.Add(observer);
    }
    public void UnSubscribe(IObserver observer)
    {
        if (_observers.Contains(observer)) _observers.Remove(observer);
    }
    public void Notify()
    {
        _observers.
            ForEach(x => x.Update(
                _mainDepartment.NotificationData.OverFlowNumber,
                _mainDepartment.NotificationData.Departments,
                _mainDepartment.NotificationData.Employees));
    }
}
