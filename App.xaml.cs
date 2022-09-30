using EmployeesListApp.Services.Interfaces;
using EmployeesListApp.Views;

namespace EmployeesListApp;

public partial class App : Application
{
    private readonly INavigationService _navigationService;
	public App(INavigationService navigationService)
    {
        _navigationService = navigationService;
		InitializeComponent();

		MainPage = new AppShell(_navigationService);
	}
}
