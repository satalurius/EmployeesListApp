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

        public EmployeesPageViewModel(INavigationService navigationService, IDatabaseRepository<EmployeeInfrastructure> databaseRepository)
        {
            _databaseRepository = databaseRepository;
            _navigationService = navigationService;

            /*Employees = new ObservableCollectionExtended<Employee>(Data.Employees);*/


            Task.Run(InitView);
            
            GoToInformationPageCommand = new Command<Employee>(GoToInformationPage);

            EventObserver.employeesViewModelNeedChangeEvent += InitEmployeesAsync;
        }

        private async Task InitView()
        {
            await _databaseRepository.CreateEntityAsync(new EmployeeInfrastructure()
            {
                Surname = "Черенков",
                Name = "Максим",
                Patronymic = "Алексеевич",
                Description =
                    "Хороший пацан. Суетолог, мастер своего дела.",
                PhotoUrl =
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9c/Tonkin_snub-nosed_monkeys_%28Rhinopithecus_avunculus%29.jpg/320px-Tonkin_snub-nosed_monkeys_%28Rhinopithecus_avunculus%29.jpg"
            });

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
