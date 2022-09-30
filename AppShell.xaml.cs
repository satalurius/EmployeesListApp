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
        /*Routes.Add("employees_page", typeof(EmployeesPage));
        Routes.Add("default_page", typeof(MainPage));*/

        Routing.RegisterRoute("employees_page", typeof(EmployeesPage));
        Routing.RegisterRoute("default_page", typeof(MainPage));
/*
        foreach (var route in Routes)
            Routing.RegisterRoute(route.Key, route.Value);*/
    }
}
