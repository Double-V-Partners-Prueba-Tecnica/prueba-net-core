using Api.Models;

namespace Api.Services.TblFacturaService
{
    public interface ITblFacturaService
    {
        // Get All
        public IEnumerable<TblFactura> Get();
        // Get By Id
        public TblFactura? Get(int id);
    }
}