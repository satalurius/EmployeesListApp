using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesListApp.Infrastructure;
using EmployeesListApp.Infrastructure.Models;
using EmployeesListApp.Models;

namespace EmployeesListApp
{
    public static class Data
    {
        public static ObservableCollection<Employee> Employees { get; set; }

        static Data()
        {
            Employees = new ObservableCollection<Employee>
            {
                new()
                {
                    Surname = "Черенков",
                    Name = "Максим",
                    Patronymic = "Алексеевич",
                    Description = "Хороший пацан. Стучит по кнопочкам, работодатель думает, что он знает что делает. Латентный фронендер",
                    FullName = $"Черенков Максим Алексеевич",
                    PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9c/Tonkin_snub-nosed_monkeys_%28Rhinopithecus_avunculus%29.jpg/320px-Tonkin_snub-nosed_monkeys_%28Rhinopithecus_avunculus%29.jpg"
                },

                new()
                {
                    Surname = "Бочарников",
                    Name = "Николай",
                    Patronymic = "Валерьевич",
                    Description = "Он в отличие от Черенкова Максима настоящий мобильщик. А я позер, который шарпы решил пощупать",
                    PhotoUrl = "url"
                },
            };
        }

        public static async Task SeedDatabaseIfEmpty()
        {
            var database = new EmployeeAppDatabaseRepository();

            var databaseEntities = await database.GetEntitiesAsync();


            if (databaseEntities.ToList().Count == 0)
            {
                foreach (var employee in Employees)
                    await database.CreateEntityAsync(EmployeeInfrastructure.ConvertInterfaceModelToInfrastructureModel(employee));
            }
        }
    }
}
