using EmployeesListApp.Services.Interfaces;
using EmployeesListApp.Views;

namespace EmployeesListApp;

public partial class AppShell : Shell
{
    private readonly INavigationService _navigationService;
	public AppShell(INavigationService navigationService)
    {
        _navigationService = navigationService;
		InitializeComponent();
        RegisterRoutes();
        BindingContext = this;
    }

    protected override async void OnHandlerChanged()
    {
        base.OnHandlerChanged();

        if (Handler is not null)
        {
            await _navigationService.InitializeAsync();
        }
    }

    static void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(EmployeesPage), typeof(EmployeesPage));
       /* Routing.RegisterRoute($"{nameof(EmployeesPage)}/{nameof(EmployeeDetailPage)}", typeof(EmployeeDetailPage));
        Routing.RegisterRoute($"{nameof(EmployeeDetailPage)}/{nameof(EditEmployeePage)}", typeof(EditEmployeePage));*/

        Routing.RegisterRoute(nameof(EmployeeDetailPage), typeof(EmployeeDetailPage));
        Routing.RegisterRoute(nameof(EditEmployeePage), typeof(EditEmployeePage));
    }
}
