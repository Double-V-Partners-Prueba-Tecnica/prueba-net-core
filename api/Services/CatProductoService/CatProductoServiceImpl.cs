using Api.Models;
using Api.Repository.Contract;
using Api.Repository.Implement;

namespace Api.Services.CatProductoService
{
    public class CatProductoServiceImpl : ICatProductoService
    {
        private readonly ICatProductoRepository _repository;

        public CatProductoServiceImpl(ICatProductoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatProducto> Get()
        {
            return _repository.GetAllAsync().Result;
        }

        public CatProducto? Get(int id)
        {
            return _repository.GetByIdAsync(id).Result;
        }
    }
}