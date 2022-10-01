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

namespace EmployeesListApp.ViewModels
{
    public class EmployeePageViewModel : IQueryAttributable, INotifyPropertyChanged
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

        public ICommand EditEmployeeCommand { get; set; }

        public EmployeePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            EditEmployeeCommand = new Command(EditEmployee);
        }


        private async void EditEmployee()
        {
            var navigationParameters = new Dictionary<string, object>
            {
                { nameof(Employee), Employee }
            };

             await _navigationService
                .NavigateToAsync("employee/edit_employee", navigationParameters);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Employee = query[nameof(Employee)] as Employee;
            OnPropertyChanged(nameof(Employee));
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
