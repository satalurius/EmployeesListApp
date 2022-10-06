using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesListApp.Service
{
    public static class EventObserver
    {
        public delegate Task EmployeesViewModelNeedChangeEventHandler();

        public static event EmployeesViewModelNeedChangeEventHandler employeesViewModelNeedChangeEvent;

        public static void OnEmployeesViewModelNeedChangeEvent()
        {
            employeesViewModelNeedChangeEvent?.Invoke();
        }
    }
}
