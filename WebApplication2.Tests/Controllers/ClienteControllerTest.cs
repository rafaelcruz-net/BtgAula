using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication2.Controllers;
using WebApplication2.Dominio.Repositorio;

namespace WebApplication2.Tests.Controllers
{
    [TestClass]
    public class ClienteControllerTest
    {
        Mock<IClienteRepository> mockRepository;
        ClienteController clienteAPI;

        [TestInitialize]
        public void TearUp()
        {
            mockRepository = new Mock<IClienteRepository>();
            clienteAPI = new ClienteController(mockRepository.Object); 
        }

        [TestMethod]
        public async void DeveRetornarNotFoundEmCasoDeNaoAcharCliente()
        {
            //Arrange
            mockRepository.Setup(x => x.GetAsync(It.IsAny<Int32>()));

            //Act
            var result = await clienteAPI.Get(10);


            //Assert
            Assert.IsTrue(result != null);

        }
    }
}
