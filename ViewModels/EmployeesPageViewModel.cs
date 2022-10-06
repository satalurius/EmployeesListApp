using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DynamicData.Binding;
using EmployeesListApp.Infrastructure;
using EmployeesListApp.Infrastructure.Models;
using EmployeesListApp.Models;
using EmployeesListApp.Service;
using EmployeesListApp.Services.Interfaces;
using EmployeesListApp.Views;
using ReactiveUI;

namespace EmployeesListApp.ViewModels
{
    public class EmployeesPageViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        private readonly IDatabaseRepository<EmployeeInfrastructure> _databaseRepository;

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Employees)));
            }
        }

        private Employee _selectedEmployee;

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedEmployee)));
            }
        }

        public ICommand GoToInformationPageCommand { get; set; }
        public ICommand GoToCreateEmployeePageCommand { get; set; }

        public EmployeesPageViewModel(INavigationService navigationService, IDatabaseRepository<EmployeeInfrastructure> databaseRepository)
        {
            _databaseRepository = databaseRepository;
            _navigationService = navigationService;


            Task.Run(InitView);
            
            GoToInformationPageCommand = new Command<Employee>(GoToInformationPage);
            GoToCreateEmployeePageCommand = new Command(GoToCreateEmployeePage);

            EventObserver.employeesViewModelNeedChangeEvent += InitEmployeesAsync;
        }

        private async Task InitView()
        {
            await Data.SeedDatabaseIfEmpty();
            await InitEmployeesAsync();
        }

        private async Task InitEmployeesAsync()
        {
            var infrastructureEmployees = await _databaseRepository.GetEntitiesAsync();

            Employees = new ObservableCollection<Employee>(infrastructureEmployees.Select(Employee.ConvertInfrastructureModelToInterfaceModel));
        }

        private async void GoToInformationPage(Employee employee)

        {
            var navigationParameters = new Dictionary<string, object>
            {
                { "Employee", employee }
            };

            await _navigationService.NavigateToAsync(nameof(EmployeeDetailPage), navigationParameters);
        }

        private async void GoToCreateEmployeePage()
            => await _navigationService.NavigateToAsync(nameof(EditEmployeePage), new Dictionary<string, object> { { "Employee", null } });

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
