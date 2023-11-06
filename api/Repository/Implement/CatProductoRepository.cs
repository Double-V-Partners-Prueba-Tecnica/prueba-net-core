using Api.Models;
using Api.Repository.Contract;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api.Repository.Implement
{
    public class CatProductoRepository : ICatProductoRepository
    {
        private readonly string _strConn;
        public CatProductoRepository(IConfiguration configuration)
        {
            _strConn = configuration?.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<IEnumerable<CatProducto>> GetAllAsync()
        {
            using (var conn = new SqlConnection(_strConn))
            {
                using (var cmd = new SqlCommand("spGetAllCatProducto", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        var list = new List<CatProducto>();
                        while (await reader.ReadAsync())
                        {
                            list.Add(MapToValue(reader));
                        }
                        return list;
                    }
                }
            }
        }

        public Task<CatProducto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }


        // Map to Value
        private CatProducto MapToValue(SqlDataReader reader)
        {
            return new CatProducto()
            {
                Id = (int)reader["Id"],
                NombreProducto = (string)reader["NombreProducto"],
                ImagenProducto = (string)reader["ImagenProducto"],
                Precio = (decimal)reader["Precio"],
                Descripcion = (string)reader["Descripcion"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = (DateTime)reader["UpdatedAt"],
                DeletedAt = (DateTime?)reader["DeletedAt"]
            };
        }
    }
}