using Api.Models;

namespace Api.Services.TblFacturaService
{
    public class TblFacturaServiceImpl : ITblFacturaService
    {
        private readonly List<TblFactura> _tblFacturas = new List<TblFactura>()
        {
            new TblFactura(){
                Id = 1,
                FechaEmisionFactura = DateTime.Now,
                IdCliente = 1,
                NumeroDeFactura = 1,
                NumeroDeProductos = 1,
                SubTotalFactura = 1,
                TotalImpuestos = 1,
                TotalFactura = 1,
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
            new TblFactura(){
                Id = 2,
                FechaEmisionFactura = DateTime.Now,
                IdCliente = 2,
                NumeroDeFactura = 2,
                NumeroDeProductos = 2,
                SubTotalFactura = 2,
                TotalImpuestos = 2,
                TotalFactura = 2,
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
        };

        public IEnumerable<TblFactura> Get()
        {
            return _tblFacturas;
        }

        public TblFactura? Get(int id)
        {
            return _tblFacturas.Find(x => x.Id == id);
        }

    }
}
