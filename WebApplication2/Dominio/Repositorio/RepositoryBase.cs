using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication2.Infra;

namespace WebApplication2.Dominio.Repositorio
{
    public class RepositoryBase<T> where T : class, IEntity
    {
        private DbSet<T> Set { get; set; }
        private WebContext Context { get; set; }

        public RepositoryBase()
        {
            this.Context = new WebContext();
            this.Set = this.Context.Set<T>();
        }

        public async Task SaveAsync(T obj)
        {
            this.Set.Add(obj);
            await this.Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T obj)
        {
            this.Set.Remove(obj);
            await this.Context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.Set.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await this.Set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(int id, T objUpdated)
        {
            this.Set.Add(objUpdated);
            await this.Context.SaveChangesAsync();
        }


    }
}