using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesListApp.Infrastructure.Models;
using SQLite;

namespace EmployeesListApp.Infrastructure
{
    internal class EmployeeAppDatabaseRepository : IDatabaseRepository<EmployeeInfrastructure>
    {
        private SQLiteAsyncConnection _database;


        private async Task Init()
        {
            if (_database is not null)
                return;

            _database = new SQLiteAsyncConnection(InfrastructureConstants.DatabasePath);
            /*if (!Directory.Exists(InfrastructureConstants.DirectoryPath))
                Directory.CreateDirectory(InfrastructureConstants.DirectoryPath);

            if (!File.Exists(InfrastructureConstants.DatabasePath))
                File.Create(InfrastructureConstants.DatabasePath);*/

            await _database.CreateTableAsync<EmployeeInfrastructure>();

        }

        public async Task<IEnumerable<EmployeeInfrastructure>> GetEntitiesAsync()
        {
            await Init();

            return await _database.Table<EmployeeInfrastructure>().ToArrayAsync();
        }

        public async Task<EmployeeInfrastructure> GetEntityByIdAsync(int id)
        {
            await Init();

            return await _database.Table<EmployeeInfrastructure>()
                .FirstAsync(employee => employee.Id.Equals(id));
        }

        public async Task<int> CreateEntityAsync(EmployeeInfrastructure entity)
        {
            await Init();

            return await _database.InsertAsync(entity);
        }

        public async Task<int> UpdateEntityAsync(EmployeeInfrastructure entity)
        {
            await Init();

            return await _database.UpdateAsync(entity);
        }

        public async Task<int> DeleteEntityAsync(EmployeeInfrastructure entity)
        {
            await Init();

            return await _database.DeleteAsync(entity);
        }
    }
}
