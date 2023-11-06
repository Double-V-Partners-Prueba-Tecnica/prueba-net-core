using Api.Models;

namespace Api.Services.CatProductoService
{
    public interface ICatProductoService
    {
        // Get All
        public IEnumerable<CatProducto> Get();
        // Get By Id
        public CatProducto? Get(int id);
    }
}