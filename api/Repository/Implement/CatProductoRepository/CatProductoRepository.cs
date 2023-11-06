using Api.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api.Repository.Implement.CatProductoRepository
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

        public async Task<CatProducto?> GetByIdAsync(int id)
        {
            using (var conn = new SqlConnection(_strConn))
            {
                using (var cmd = new SqlCommand("spGetByIdCatProducto", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapToValue(reader);
                        }
                        return null;
                    }
                }
            }
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
                Ext = (string)reader["Ext"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = (DateTime)reader["UpdatedAt"],
                DeletedAt = (reader["DeletedAt"] == DBNull.Value) ? null : (DateTime?)reader["DeletedAt"]
            };
        }
    }
}