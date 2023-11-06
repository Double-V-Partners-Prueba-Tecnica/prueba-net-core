namespace Api.Models
{
    public class TblDetalleFactura
    {
        // Primary Key
        public int Id { get; set; }
        // Properties
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int CantidadDeProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
        public required string Notas { get; set; }
        // Timestamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        // Foreign Keys
        public required TblFactura Factura { get; set; }
        public required CatProducto Producto { get; set; }
    }

}