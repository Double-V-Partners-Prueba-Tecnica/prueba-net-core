namespace Api.Models
{
    public class TblFactura
    {
        // Primary Key
        public int Id { get; set; }
        // Properties
        public DateTime FechaEmisionFactura { get; set; }
        public required int IdCliente { get; set; }
        public int NumeroDeFactura { get; set; }
        public int NumeroDeProductos { get; set; }
        public decimal SubTotalFactura { get; set; }
        public decimal TotalImpuestos { get; set; }
        public decimal TotalFactura { get; set; }
        // Timestamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        // Foreign Keys
        public TblCliente? Cliente { get; set; }
        // Adicional Properties
        public List<TblDetalleFactura>? DetalleFactura { get; set; }
    }
}


// #### CatTipoCliente
// |    | Columna     | Tipo de dato | Nullable |
// |----|-------------|--------------|----------|
// | 🔑 | Id          | int          | ❌        |
// |    | TipoCliente | varchar(50)  | ❌        |

// #### TblCliente
// |    | Columna         | Tipo de dato | Nullable |
// |----|-----------------|--------------|----------|
// | 🔑 | Id              | int          | ❌        |
// |    | RazonSocial     | varchar(50)  | ❌        |
// | 🔐 | IdTipoCliente   | int          | ❌        |
// |    | FechaDeCreacion | datetime     | ❌        |
// |    | RFC             | varchar(50)  | ❌        |

// #### CatProducto
// |    | Columna        | Tipo de dato  | Nullable |
// |----|----------------|---------------|----------|
// | 🔑 | Id             | int           | ❌        |
// |    | NombreProducto | varchar(50)   | ❌        |
// |    | ImagenProducto | varchar(50)   | ✅        |
// |    | Precio         | decimal(18,2) | ❌        |
// |    | Ext            | varchar(5)    | ❌        |

// #### TblDetalleFactura

// |    | Columna            | Tipo de dato  | Nullable |
// |----|--------------------|---------------|----------|
// | 🔑 | Id                 | int           | ❌        |
// | 🔐 | IdFactura          | int           | ❌        |
// | 🔐 | IdProducto         | int           | ❌        |
// |    | CantidadDeProducto | int           | ❌        |
// |    | PrecioUnitario     | decimal(18,2) | ❌        |
// |    | SubTotal           | decimal(18,2) | ❌        |
// |    | Notas              | varchar(50)   | ✅        |

// #### TblFactura

// |    | Columna             | Tipo de dato  | Nullable |
// |----|---------------------|---------------|----------|
// | 🔑 | Id                  | int           | ❌        |
// |    | FechaEmisionFactura | datetime      | ❌        |
// | 🔐 | IdCliente           | int           | ❌        |
// |    | NumeroDeFactura     | int           | ❌        |
// |    | NumeroDeProductos   | int           | ❌        |
// |    | SubTotalFactura     | decimal(18,2) | ❌        |
// |    | TotalImpuestos      | decimal(18,2) | ❌        |
// |    | TotalFactura        | decimal(18,2) | ❌        |
