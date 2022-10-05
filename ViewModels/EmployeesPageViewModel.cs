﻿using System;
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
using EmployeesListApp.Models;
using EmployeesListApp.Services.Interfaces;
using EmployeesListApp.Views;
using ReactiveUI;

namespace EmployeesListApp.ViewModels
{
    public class EmployeesPageViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;

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

        public EmployeesPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Employees = new ObservableCollectionExtended<Employee>(Data.Employees);
            
            GoToInformationPageCommand = new Command<Employee>(GoToInformationPage);
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
