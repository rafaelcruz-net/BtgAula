using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Dominio.Repositorio
{
    public class ClienteRepository
    {
        private static ArrayList Cliente { get; set; } = new ArrayList(); 

        public void Save(Cliente obj)
        {
            Cliente.Add(obj);
        }

        public void Delete(Cliente obj)
        {
            Cliente.Remove(obj);
        }

        public ArrayList GetAll()
        {
            return Cliente;
        }

        public Cliente Get(int id)
        {
            foreach (var item in Cliente)
            {
                if ((item as Cliente).Id == id)
                    return item as Cliente;
            }

            return null;
        }

        public void Update(int id, Cliente objUpdated)
        {
            var obj = Get(id);

            this.Delete(obj);

            this.Save(objUpdated);
        }
    }
}