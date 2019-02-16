using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Dominio;
using WebApplication2.Dominio.Repositorio;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {

        private IClienteRepository Repository { get; set; }

        public HomeController(IClienteRepository repository)
        {
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ActionResult> Index()
        {
            return await Task.Factory.StartNew<ActionResult>(() => View());
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            return await Task.Factory.StartNew<ActionResult>(() => 
            {
                var clientes = this.Repository.GetAllAsync().Result;

                List<ClienteViewModel> result = new List<ClienteViewModel>();

                foreach (var item in clientes)
                {
                    result.Add(new ClienteViewModel()
                    {
                        Id = item.Id,
                        Agencia = item.Agencia,
                        Conta = item.Conta,
                        CPF = item.CPF,
                        Estado = item.Estado,
                        Nome = item.Nome
                    });
                }

                return View(result);

            });
        }
        [HttpPost]
        public async Task<ActionResult> Salvar(ClienteViewModel model)
        {
            if (!ModelState.IsValid)
                return await
                    Task.Factory.StartNew<ActionResult>(() => View("Index", ModelState));

            return await Task.Factory.StartNew<ActionResult>(() =>
            {
                Cliente cliente = new Cliente()
                {
                    Agencia = model.Agencia,
                    Conta = model.Conta,
                    CPF = model.CPF,
                    Estado = model.Estado,
                    Nome = model.Nome
                };

                Task.Factory.StartNew(() => this.Repository.SaveAsync(cliente));

                ViewBag.Sucesso = 1;

                return View("Index");
            });
        }

      
    }
}