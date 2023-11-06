using Api.Controllers;
using Api.Models;
using Api.Repository.Contract;
using Api.Repository.Implement;
using Api.Services.CatProductoService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiTest.Controllers
{
    public class CatProductoControllerTest
    {
        private readonly CatProductoController _controller;
        private readonly ICatProductoService _service;
        private readonly ICatProductoRepository _repository;
        public CatProductoControllerTest()
        {
            _repository = new CatProductoRepository(
                new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
            );
            _service = new CatProductoServiceImpl(_repository);
            _controller = new CatProductoController(_service);
        }

        // Metodo Get

        // Esta prueba es para verificar que el metodo Get() regrese un 200, ya que es el codigo de respuesta correcto
        [Fact]
        public void Get_Ok()
        {
            var result = _controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }

        // Prueba que evalua la cantidad de registros que se obtienen del metodo Get()
        [Fact]
        public void Get_Quantity()
        {
            var result = _controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var items = Assert.IsType<List<CatProducto>>(okResult.Value);
            Assert.True(items.Count > 0);
        }

        // Metodo Get(int id)

        // Esta prueba es para verificar que el metodo Get(0) regrese un 404, ya que no existe un registro con id = 0
        [Fact]
        public void Get_NotFound()
        {
            var result = _controller.Get(0);
            Assert.IsType<NotFoundResult>(result);
        }

        // Esta prueba es para verificar que el metodo Get(1) regrese un 200, ya que existe un registro con id = 1
        [Fact]
        public void Get_OkId()
        {
            int id = 1;
            var result = _controller.Get(id);
            Assert.IsType<OkObjectResult>(result);
        }

        // Esta prueba es para verificar que el metodo Get(1) regrese un registro con id = 1
        [Fact]
        public void Get_Id()
        {
            int id = 1;
            var result = _controller.Get(id);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var item = Assert.IsType<CatProducto>(okResult.Value);
            Assert.Equal(id, item.Id);
        }
    }

}