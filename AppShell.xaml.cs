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
        Routing.RegisterRoute("employees_page", typeof(EmployeesPage));
        Routing.RegisterRoute("employee", typeof(EmployeePage));
        Routing.RegisterRoute("employee/edit_employee", typeof(EditEmployeePage));
    }
}
