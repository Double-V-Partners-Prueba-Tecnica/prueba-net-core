using Api.Models;

namespace Api.Services.CatProductoService
{
    public class CatProductoServiceImpl : ICatProductoService
    {
        private readonly List<CatProducto> _catProductos = new List<CatProducto>()
        {
            new CatProducto(){
                Id = 1,
                NombreProducto = "Producto 1",
                ImagenProducto = "https://via.placeholder.com/150",
                Precio = 100,
                Descripcion = "Descripcion del producto 1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            },
            new CatProducto(){
                Id = 2,
                NombreProducto = "Producto 2",
                ImagenProducto = "https://via.placeholder.com/150",
                Precio = 200,
                Descripcion = "Descripcion del producto 2",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            },
        };

        public IEnumerable<CatProducto> Get()
        {
            return _catProductos;
        }

        public CatProducto? Get(int id)
        {
            return _catProductos.Find(x => x.Id == id);
        }
    }
}