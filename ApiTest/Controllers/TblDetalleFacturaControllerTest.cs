using Api.Controllers;
using Api.Models;
using Api.Repository.Implement.TblDetalleFacturaRepository;
using Api.Services.TblDetalleFacturaService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiTest.Controllers
{
    public class TblDetalleFacturaControllerTest
    {
        private readonly TblDetalleFacturaController _controller;
        private readonly ITblDetalleFacturaService _service;
        private readonly ITblDetalleFacturaRepository _repository;

        public TblDetalleFacturaControllerTest()
        {
            _repository = new TblDetalleFacturaRepositoryImpl(
                new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
            );
            _service = new TblDetalleFacturaServiceImpl(_repository);
            _controller = new TblDetalleFacturaController(_service);
        }



        [Fact]
        public void Create_Ok()
        {
            var detalleFactura = new TblDetalleFactura
            {
                IdFactura = 1, // Asigna un ID de factura válido
                IdProducto = 1, // Asigna un ID de producto válido
                CantidadDeProducto = 5,
                PrecioUnitario = 10.0M,
                SubTotal = 50.0M,
                Notas = "Detalles de prueba"
            };
            var result = _controller.Create(detalleFactura);
            Assert.IsType<OkObjectResult>(result);
            // Guarda el ID del registro creado
            var okResult = Assert.IsType<OkObjectResult>(result);
            var item = Assert.IsType<TblDetalleFactura>(okResult.Value);
        }

        [Fact]
        public void Get_Ok()
        {
            var result = _controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_Quantity()
        {
            var result = _controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var items = Assert.IsType<List<TblDetalleFactura>>(okResult.Value);
            Assert.True(items.Count > 0);
        }

        [Fact]
        public void Get_DeletedAt()
        {
            var result = _controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var items = Assert.IsType<List<TblDetalleFactura>>(okResult.Value);
            foreach (var item in items)
            {
                Assert.Null(item.DeletedAt);
            }
        }

        [Fact]
        public void Get_ById_Ok()
        {
            int id = 1; // Asume que existe un detalle de factura con ID 1
            var result = _controller.Get(id);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_ById_NotFound()
        {
            int id = 0; // Asume que no existe un detalle de factura con ID 0
            var result = _controller.Get(id);
            Assert.IsType<NotFoundResult>(result);
        }


    }
}
