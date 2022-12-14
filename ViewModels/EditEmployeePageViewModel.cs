using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EmployeesListApp.Infrastructure;
using EmployeesListApp.Infrastructure.Models;
using EmployeesListApp.Models;
using EmployeesListApp.Service;
using EmployeesListApp.Services.Interfaces;
using EmployeesListApp.Views;

namespace EmployeesListApp.ViewModels
{
    public class EditEmployeePageViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        private readonly INavigationService _navigationService;
        private readonly IDatabaseRepository<EmployeeInfrastructure> _databaseRepository;

        private Employee _oldEmployee;
        private bool isNewUser = false;

        private Employee _employee;
        public Employee Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Employee)));
            }
        }

        public ICommand SaveEmployeeCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        public EditEmployeePageViewModel(INavigationService navigationService, IDatabaseRepository<EmployeeInfrastructure> databaseRepository)
        {
            _databaseRepository = databaseRepository;
            _navigationService = navigationService;

            SaveEmployeeCommand = new Command(SaveEmployee);
            GoBackCommand = new Command(GoBack);

        }

        private async void SaveEmployee()
        {
            if (isNewUser)
                await _databaseRepository.CreateEntityAsync(EmployeeInfrastructure.ConvertInterfaceModelToInfrastructureModel(Employee));
            else 
                await _databaseRepository.UpdateEntityAsync(EmployeeInfrastructure.ConvertInterfaceModelToInfrastructureModel(Employee));

            EventObserver.OnEmployeesViewModelNeedChangeEvent();

            await _navigationService.NavigateToAsync($"//{nameof(EmployeesPage)}");
        }

        private async void GoBack()
        {
            var routeParameters = new Dictionary<string, object>()
            {
                { nameof(Employee), _oldEmployee }
            };
            await _navigationService.NavigateToAsync(nameof(EmployeeDetailPage), routeParameters);
        }


        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var queryEmployee = query["Employee"] as Employee;
            if (queryEmployee is null)
            {
                isNewUser = true;
                Employee = new Employee();
            }
            else
            {
                Employee = queryEmployee;
            }

            OnPropertyChanged("Employee");
            _oldEmployee = Employee.Clone() as Employee;

        }
    }
}
