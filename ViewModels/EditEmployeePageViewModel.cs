using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EmployeesListApp.Models;

namespace EmployeesListApp.ViewModels
{
    public class EditEmployeePageViewModel : IQueryAttributable, INotifyPropertyChanged
    {
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

        public EditEmployeePageViewModel()
        {
            SaveEmployeeCommand = new Command(SaveEmployee);
        }

        private async void SaveEmployee()
        {

        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            throw new NotImplementedException();
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
