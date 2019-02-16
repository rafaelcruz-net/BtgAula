using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Infra;

namespace WebApplication2.Dominio.Repositorio
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(WebContext context) : base(context)
        {

        }

    }
}