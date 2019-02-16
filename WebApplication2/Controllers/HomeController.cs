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

        private ClienteRepository Repository { get; set; } = new ClienteRepository(); 

        public Task<ActionResult> Index()
        {
            return Task.Factory.StartNew<ActionResult>(() => View());
        }

        [HttpGet]
        public Task<ActionResult> List()
        {
            return Task.Factory.StartNew<ActionResult>(() =>
            {
                var clientes = this.Repository.GetAll();

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
        public Task<ActionResult> Salvar(ClienteViewModel model)
        {
            if (!ModelState.IsValid)
                return 
                    Task.Factory.StartNew<ActionResult>(() => View("Index", ModelState));

            return Task.Factory.StartNew<ActionResult>(() =>
            {


                Cliente cliente = new Cliente()
                {
                    Agencia = model.Agencia,
                    Conta = model.Conta,
                    CPF = model.CPF,
                    Estado = model.Estado,
                    Nome = model.Nome,
                    Id = this.Repository.GetAll().Count + 1
                };

                this.Repository.Save(cliente);

                ViewBag.Sucesso = 1;

                return View("Index");
            });
        }

      
    }
}