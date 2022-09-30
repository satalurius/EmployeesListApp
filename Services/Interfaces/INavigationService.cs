using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesListApp.Services.Interfaces
{
    public interface INavigationService
    {
        Task InitializeAsync();
        Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null);
        Task PopAsync();
        Task GoBackAsync();
    }
}
