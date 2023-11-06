namespace Api.Models
{
    public class TblCliente
    {
        // Primary Key
        public int Id { get; set; }
        // Properties
        public required string RazonSocial { get; set; }
        public int IdTipoCliente { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public required string RFC { get; set; }
        // Timestamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        // Foreign Keys
        public required CatTipoCliente TipoCliente { get; set; }
    }

}