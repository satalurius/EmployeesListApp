using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesListApp.Infrastructure
{
    public interface IDatabaseRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetEntitiesAsync();
        Task<T> GetEntityByIdAsync(int id);
        Task<int> CreateEntityAsync(T entity);
        Task<int> UpdateEntityAsync(T entity);
        Task<int> DeleteEntityAsync(T entity);
    }
}
