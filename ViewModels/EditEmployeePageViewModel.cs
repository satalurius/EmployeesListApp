using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EmployeesListApp.Models;
using EmployeesListApp.Services.Interfaces;
using EmployeesListApp.Views;

namespace EmployeesListApp.ViewModels
{
    [QueryProperty("Employee", "Employee")]
    public class EditEmployeePageViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;

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

        public EditEmployeePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            SaveEmployeeCommand = new Command(SaveEmployee);
            GoBackCommand = new Command(GoBack);
        }

        private async void SaveEmployee()
        {
            // TODO: Загружать в БД.

            await _navigationService.NavigateToAsync($"//{nameof(EmployeesPage)}");
        }

        private async void GoBack()
        {
            var routeParameters = new Dictionary<string, object>()
            {
                { nameof(Employee), Employee }
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
    }
}
