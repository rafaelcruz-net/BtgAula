using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Dominio.Repositorio
{
    public class RepositoryBase<T> where T : class, IEntity
    {
        private static List<T> Base { get; set; } = new List<T>();

        public void Save(T obj) => Base.Add(obj);

        public void Delete(T obj) => Base.Remove(obj);

        public List<T> GetAll() => Base;

        public T Get(int id)
        {
            return Base.FirstOrDefault(x => x.Id == id);
        }

        public void Update(int id, T objUpdated)
        {
            var obj = Get(id);

            this.Delete(obj);

            this.Save(objUpdated);
        }


    }
}