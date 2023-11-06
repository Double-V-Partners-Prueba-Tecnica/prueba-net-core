using Api.Models;

namespace Api.Services.CatTipoClienteService
{
    public class CatTipoClienteServiceImpl : ICatTipoClienteService
    {
        private readonly List<CatTipoCliente> _catTipoClientes = new List<CatTipoCliente>()
        {
            new CatTipoCliente(){
                Id = 1,
                TipoCliente = "Tipo Cliente 1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            },
            new CatTipoCliente(){
                Id = 2,
                TipoCliente = "Tipo Cliente 2",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            },
        };

        public IEnumerable<CatTipoCliente> Get()
        {
            return _catTipoClientes;
        }

        public CatTipoCliente? Get(int id)
        {
            return _catTipoClientes.Find(x => x.Id == id);
        }
    }
}