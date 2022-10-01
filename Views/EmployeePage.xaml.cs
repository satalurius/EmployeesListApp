using EmployeesListApp.ViewModels;

namespace EmployeesListApp.Views;

public partial class EmployeePage : ContentPage
{
	public EmployeePage(EmployeePageViewModel viewModel)
    {
        BindingContext = viewModel;
		InitializeComponent();
	}
}