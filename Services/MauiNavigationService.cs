using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesListApp.Services.Interfaces;
using EmployeesListApp.Views;

namespace EmployeesListApp.Services
{
    internal class MauiNavigationService : INavigationService
    {
        public Task InitializeAsync()
            => NavigateToAsync($"//{nameof(EmployeesPage)}");

        public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
        {
            var shellNavigation = new ShellNavigationState(route);

            return routeParameters is not null
                ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
                : Shell.Current.GoToAsync(shellNavigation);
        }

        public Task PopAsync()
            => Shell.Current.GoToAsync("..");

        public Task GoBackAsync()
            => Shell.Current.GoToAsync(nameof(EmployeesPage));
    }
}
