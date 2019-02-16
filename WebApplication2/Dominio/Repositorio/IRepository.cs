using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Dominio.Repositorio
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task SaveAsync(T obj);
        Task DeleteAsync(T obj);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task UpdateAsync(int id, T objUpdated);

    }
}
