using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(ClienteViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", ModelState);
            
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


        }

      
    }
}