using Api.Models;

namespace Api.Services.TblClienteService
{
    public interface ITblClienteService
    {
        // Get All
        public IEnumerable<TblCliente> Get();
        // Get By Id
        public TblCliente? Get(int id);
    }
}