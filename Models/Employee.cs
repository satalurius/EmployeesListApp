namespace EmployeesListApp.Models
{
    public class Employee
    {
        public string Surname { get; init; }
        public string Name { get; init; }
        public string Patronymic { get; init; }
        public string FullName { get; init; }
        public string PhotoUrl { get; init; }
        public string Description { get; set; }
    }
}
