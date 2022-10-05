using EmployeesListApp.ViewModels;

namespace EmployeesListApp.Views;

public partial class EmployeeDetailPage : ContentPage
{
	public EmployeeDetailPage(EmployeePageViewModel viewModel)
    {
		InitializeComponent();
        BindingContext = viewModel;
	}
}