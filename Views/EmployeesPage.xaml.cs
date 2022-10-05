using EmployeesListApp.Services.Interfaces;
using EmployeesListApp.ViewModels;

namespace EmployeesListApp.Views;

public partial class EmployeesPage : ContentPage
{
	public EmployeesPage(EmployeesPageViewModel viewModel)
    {

		InitializeComponent();
        BindingContext = viewModel;
    }
   
}