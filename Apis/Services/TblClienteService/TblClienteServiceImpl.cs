using Api.Models;

namespace Api.Services.TblClienteService
{
    public class TblClienteServiceImpl : ITblClienteService
    {
        private readonly List<TblCliente> _tblClientes = new List<TblCliente>()
        {
            new TblCliente(){
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
            new TblCliente(){
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
        };

        public IEnumerable<TblCliente> Get()
        {
            return _tblClientes;
        }

        public TblCliente? Get(int id)
        {
            return _tblClientes.Find(x => x.Id == id);
        }
    }
}