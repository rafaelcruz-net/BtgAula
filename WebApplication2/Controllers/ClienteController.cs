using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication2.Dominio;
using WebApplication2.Dominio.Repositorio;

namespace WebApplication2.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        private IClienteRepository Repository { get; set; }

        public ClienteController(IClienteRepository clienteRepository)
        {
            this.Repository = clienteRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await this.Repository.GetAllAsync());
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var cliente = await this.Repository.GetAsync(id);

            if (cliente == null)
                return await Task.Factory.StartNew<IHttpActionResult>(() => NotFound());

            return await Task.Factory.StartNew<IHttpActionResult>(() => Ok(cliente));

        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post(Cliente model)
        {
            await this.Repository.SaveAsync(model);

            return await Task.Factory.StartNew<IHttpActionResult>(() => Created<Cliente>(String.Empty ,model));

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> Put(int id, Cliente model)
        {
            var updatedCliente = await this.Repository.GetAsync(id);

            if (updatedCliente == null)
                return await Task.Factory.StartNew<IHttpActionResult>(() => NotFound());

            updatedCliente.Agencia = model.Agencia;
            updatedCliente.Conta = model.Conta;
            updatedCliente.CPF = model.CPF;
            updatedCliente.Estado = model.Estado;
            updatedCliente.Nome = model.Nome;

            await this.Repository.UpdateAsync(id, updatedCliente);

            return await Task.Factory.StartNew<IHttpActionResult>(() => Ok(updatedCliente));

        }

        // GET api/<controller>/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var cliente = await this.Repository.GetAsync(id);

            if (cliente == null)
                return await Task.Factory.StartNew<IHttpActionResult>(() => NotFound());

            await this.Repository.DeleteAsync(cliente);

            return await Task.Factory.StartNew<IHttpActionResult>(
                () => this.ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent)));

        }

    }
}