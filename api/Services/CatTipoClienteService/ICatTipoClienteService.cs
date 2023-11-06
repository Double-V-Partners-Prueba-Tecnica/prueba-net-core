using Api.Models;

namespace Api.Services.CatTipoClienteService
{
    public interface ICatTipoClienteService
    {
        // Get All
        public IEnumerable<CatTipoCliente> Get();
        // Get By Id
        public CatTipoCliente? Get(int id);
    }
}