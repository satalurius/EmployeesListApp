using EmployeesListApp.Services.Interfaces;
using EmployeesListApp.ViewModels;

namespace EmployeesListApp.Views;

public partial class EmployeesPage : ContentPage
{
    private readonly INavigationService _navigationService;
	public EmployeesPage(INavigationService navigationService)
    {
        _navigationService = navigationService;

		InitializeComponent();
        BindingContext = new EmployeesPageViewModel(_navigationService);
    }
   
}