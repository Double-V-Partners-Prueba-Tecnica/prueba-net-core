using Api.Models;

namespace Api.Services.TblDetalleFacturaService
{
    public class TblDetalleFacturaServiceImpl : ITblDetalleFacturaService
    {
        private readonly List<TblDetalleFactura> _tblDetalleFacturas = new List<TblDetalleFactura>()
        {
            new TblDetalleFactura(){
                Id = 1,
                IdFactura = 1,
                IdProducto = 1,
                CantidadDeProducto = 1,
                PrecioUnitario = 1,
                SubTotal = 1,
                Notas = "Notas 1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
                Factura = new TblFactura(){
                    Id = 1,
                    IdCliente = 1,
                    FechaEmisionFactura = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    DeletedAt = null,
                    Cliente = new TblCliente(){
                        Id = 1,
                        RazonSocial = "Nombre 1",
                        IdTipoCliente = 1,
                        FechaDeCreacion = DateTime.Now,
                        RFC = "RFC 1",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        DeletedAt = null,
                        TipoCliente = new CatTipoCliente(){
                            Id = 1,
                            TipoCliente = "Tipo Cliente 1",
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            DeletedAt = null,
                        },
                    },
                },
                Producto = new CatProducto(){
                    Id = 1,
                    NombreProducto = "Nombre Producto 1",
                    ImagenProducto = "Imagen Producto 1",
                    Precio = 1,
                    Ext = "Descripcion 1",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    DeletedAt = null,
                },
            },
            new TblDetalleFactura(){
                Id = 2,
                IdFactura = 2,
                IdProducto = 2,
                CantidadDeProducto = 2,
                PrecioUnitario = 2,
                SubTotal = 2,
                Notas = "Notas 2",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
                Factura = new TblFactura(){
                    Id = 2,
                    IdCliente = 2,
                    FechaEmisionFactura = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    DeletedAt = null,
                    Cliente = new TblCliente(){
                        Id = 2,
                        RazonSocial = "Nombre 2",
                        IdTipoCliente = 2,
                        FechaDeCreacion = DateTime.Now,
                        RFC = "RFC 2",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        DeletedAt = null,
                        TipoCliente = new CatTipoCliente(){
                            Id = 2,
                            TipoCliente = "Tipo Cliente 2",
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            DeletedAt = null,
                        },
                    },
                },
                Producto = new CatProducto(){
                    Id = 2,
                    NombreProducto = "Nombre Producto 2",
                    ImagenProducto = "Imagen Producto 2",
                    Precio = 2,
                    Ext = "Descripcion 2",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    DeletedAt = null,
                },
            },
        };

        public IEnumerable<TblDetalleFactura> Get()
        {
            return _tblDetalleFacturas;
        }

        public TblDetalleFactura? Get(int id)
        {
            return _tblDetalleFacturas.Find(x => x.Id == id);
        }
    }
}