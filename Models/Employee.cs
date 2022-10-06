using EmployeesListApp.Infrastructure.Models;

namespace EmployeesListApp.Models
{
    public class Employee : ICloneable
    {
        public int Id { get; init; }
        public string Surname { get; init; }
        public string Name { get; init; }
        public string Patronymic { get; init; }
        public string FullName { get; init; }
        public string PhotoUrl { get; init; }
        public string Description { get; init; }

        public static Employee ConvertInfrastructureModelToInterfaceModel(EmployeeInfrastructure employeeInfrastructure)
            => new()
            {
                Id = employeeInfrastructure.Id,
                Name = employeeInfrastructure.Name,
                Surname = employeeInfrastructure.Surname,
                Patronymic = employeeInfrastructure.Patronymic,
                FullName =
                    $"{employeeInfrastructure.Name} {employeeInfrastructure.Surname} {employeeInfrastructure.Patronymic}",
                Description = employeeInfrastructure.Description,
                PhotoUrl = employeeInfrastructure.PhotoUrl
            };

        public object Clone()
            => new Employee
            {
                Id = this.Id,
                Description = this.Description,
                FullName = this.FullName,
                Name = this.Name,
                Patronymic = this.Patronymic,
                PhotoUrl = this.PhotoUrl,
                Surname = this.Surname
            };
    }
}
