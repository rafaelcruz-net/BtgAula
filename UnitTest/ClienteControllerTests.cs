using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication2.Controllers;
using WebApplication2.Dominio;
using WebApplication2.Dominio.Repositorio;

namespace UnitTest
{
    [TestClass]
    public class ClienteControllerTests
    {

        private Mock<IClienteRepository> mock;
        private ClienteController controller;  

        [TestInitialize]
        public void TearUp()
        {
            this.mock = new Mock<IClienteRepository>();
            this.controller = new ClienteController(mock.Object); 

        }

        [TestMethod]
        public void DeveRetornarNotFoundCasoNaoAcheOCliente()
        {
            this.mock.Setup(x => x.GetAsync(It.IsIn<Int32>()))
                .Returns(Task.FromResult<WebApplication2.Dominio.Cliente>(null));

            var result = this.controller.Get(10).Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void DeveRetornarOkCasoAcheOCliente()
        {
            this.mock.Setup(x => x.GetAsync(10))
                .Returns(Task.FromResult<WebApplication2.Dominio.Cliente>(new Cliente()
                {
                    Id = 10,
                    Agencia = "99999",
                    Conta = "99999",
                    CPF = "99999",
                    Estado = "Rio de Janeiro",
                    Nome = "Joao da Silva"
                }));

            var result = this.controller.Get(10).Result;

            var clienteReturn = (result as OkNegotiatedContentResult<Cliente>).Content;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Cliente>));
            Assert.IsNotNull(clienteReturn);
            Assert.IsTrue(clienteReturn.Id == 10);
            Assert.IsTrue(clienteReturn.Nome == "Joao da Silva");

        }

        [TestMethod]
        public void DeveRetornarOkParaTodosOsClientes()
        {
            var lista = new List<Cliente>()
            {
                new Cliente()
                {
                    Id = 10,
                    Agencia = "99999",
                    Conta = "99999",
                    CPF = "99999",
                    Estado = "Rio de Janeiro",
                    Nome = "Joao da Silva"
                },
                 new Cliente()
                {
                    Id = 11,
                    Agencia = "99999",
                    Conta = "99999",
                    CPF = "99999",
                    Estado = "Rio de Janeiro",
                    Nome = "Joao da Silva"
                },
            };

            this.mock.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult<List<WebApplication2.Dominio.Cliente>>(lista));

            var result = this.controller.Get().Result;

            var clienteReturn = (result as OkNegotiatedContentResult<List<Cliente>>).Content;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<List<Cliente>>));
            Assert.IsNotNull(clienteReturn);
            CollectionAssert.AllItemsAreInstancesOfType(clienteReturn, typeof(Cliente));
            Assert.IsTrue(clienteReturn.Count == 2);




        }
    }
}

