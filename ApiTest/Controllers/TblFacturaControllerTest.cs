using Api.Controllers;
using Api.Models;
using Api.Repository.Implement.TblFacturaRepository;
using Api.Services.TblFacturaService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace ApiTest.Controllers
{
    public class TblFacturaControllerTest
    {
        private readonly TblFacturaController _controller;
        private readonly ITblFacturaService _service;
        private readonly ITblFacturaRepository _repository;

        public TblFacturaControllerTest()
        {
            _repository = new TblFacturaRepositoryImpl(
                new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
            );
            _service = new TblFacturaServiceImpl(_repository);
            _controller = new TblFacturaController(_service);
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
            var items = Assert.IsType<List<TblFactura>>(okResult.Value);
            Assert.True(items.Count > 0);
        }

        [Fact]
        public void Get_DeletedAt()
        {
            var result = _controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var items = Assert.IsType<List<TblFactura>>(okResult.Value);
            foreach (var item in items)
            {
                Assert.Null(item.DeletedAt);
            }
        }

        [Fact]
        public void Get_ById_Ok()
        {
            int id = 1; // Asume que existe una factura con ID 1
            var result = _controller.Get(id);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_ById_NotFound()
        {
            int id = 0; // Asume que no existe una factura con ID 0
            var result = _controller.Get(id);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_Ok()
        {
            var factura = new TblFactura
            {
                FechaEmisionFactura = DateTime.Now,
                IdCliente = 1, // Asigna un ID de cliente válido
                NumeroDeFactura = 1,
                NumeroDeProductos = 5,
            };
            var result = _controller.Create(factura);
            Assert.IsType<OkObjectResult>(result);
            // Guarda el ID del registro creado
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<TblFactura>(okResult.Value);
        }
        [Fact]
        public void Get_TotalAmountMatchesSubtotalAndTotalImpuestos()
        {
            var result = _controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var items = Assert.IsType<List<TblFactura>>(okResult.Value);
            foreach (var factura in items)
            {
                // Verifica que el TotalFactura coincide con la suma de SubTotalFactura y TotalImpuestos
                Assert.Equal(factura.SubTotalFactura + factura.TotalImpuestos, factura.TotalFactura);
            }
        }

        [Fact]
        public void Get_FacturaWithHighestTotalAmount()
        {
            var result = _controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var items = Assert.IsType<List<TblFactura>>(okResult.Value);

            // Encuentra la factura con el TotalFactura más alto
            var facturaConMayorTotal = items.OrderByDescending(f => f.TotalFactura).FirstOrDefault();

            if (facturaConMayorTotal != null)
            {
                // Verifica que la factura con el TotalFactura más alto sea positiva
                Assert.True(facturaConMayorTotal.TotalFactura >= 0);

            }
            else
            {
                Assert.Null(facturaConMayorTotal);
            }
        }
        [Fact]
        public void Get_FacturaWithLowestTotalAmount()
        {
            var result = _controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var items = Assert.IsType<List<TblFactura>>(okResult.Value);

            // Encuentra la factura con el TotalFactura más bajo
            var facturaConMenorTotal = items.OrderBy(f => f.TotalFactura).FirstOrDefault();

            if (facturaConMenorTotal != null)
            {
                // Verifica que el TotalFactura sea como mínimo 0
                Assert.True(facturaConMenorTotal.TotalFactura >= 0);

                // Verifica que si el TotalFactura es 0, la cantidad de productos también sea 0
                if (facturaConMenorTotal.TotalFactura == 0)
                {
                    Assert.Equal(0, facturaConMenorTotal.NumeroDeProductos);
                }

            }
            else
            {
                Assert.Null(facturaConMenorTotal);
            }
        }

        [Fact]
        public void GetFacturasByCliente_Found()
        {
            // Arrange
            int idCliente = 1; // ID de cliente válido

            // Act
            var result = _controller.GetFacturasByCliente(idCliente);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var facturas = Assert.IsType<List<TblFactura>>(okResult.Value);
            Assert.NotEmpty(facturas); // Verificar que se encontraron facturas
        }

        [Fact]
        public void GetFacturasByCliente_NotFound()
        {
            // Arrange
            int idCliente = 99; // ID de cliente inexistente

            // Act
            var result = _controller.GetFacturasByCliente(idCliente);

            // Assert
            Assert.IsType<OkObjectResult>(result);

            // Verificar que el resultado es una lista vacía
            var okResult = Assert.IsType<OkObjectResult>(result);
            var facturas = Assert.IsType<List<TblFactura>>(okResult.Value);
            Assert.Empty(facturas);
        }

        [Fact]
        public void GetFacturasByNumeroFactura_Exists_ReturnsOkResult()
        {
            // Arrange
            int numeroFactura = 1; // Define el número de factura que esperas que exista.

            // Act
            var result = _controller.GetFacturasByNumeroFactura(numeroFactura);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetFacturasByNumeroFactura_NotFound_ReturnsNotFoundResult()
        {
            // Arrange
            int numeroFactura = 9999; // Define un número de factura que no existe.

            // Act
            var result = _controller.GetFacturasByNumeroFactura(numeroFactura);

            // Assert
            Assert.IsType<OkObjectResult>(result);

            // Verificar que el resultado es una lista vacía
            var okResult = Assert.IsType<OkObjectResult>(result);
            var facturas = Assert.IsType<List<TblFactura>>(okResult.Value);
            Assert.Empty(facturas);
        }

    }
}
