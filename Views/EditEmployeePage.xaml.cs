using EmployeesListApp.ViewModels;

namespace EmployeesListApp.Views;

public partial class EditEmployeePage : ContentPage
{
	public EditEmployeePage(EditEmployeePageViewModel viewModel)
    {
        BindingContext = viewModel;
		InitializeComponent();
	}
}