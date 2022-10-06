using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesListApp.Models;
using SQLite;

namespace EmployeesListApp.Infrastructure.Models
{
    public class EmployeeInfrastructure
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; init; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }

        public static EmployeeInfrastructure ConvertInterfaceModelToInfrastructureModel(Employee interfaceEmployee)
            => new()
            {
                Id = interfaceEmployee.Id,
                Name = interfaceEmployee.Name,
                Surname = interfaceEmployee.Surname,
                Patronymic = interfaceEmployee.Patronymic,
                Description = interfaceEmployee.Description,
                PhotoUrl = interfaceEmployee.PhotoUrl
            };
    }
}
