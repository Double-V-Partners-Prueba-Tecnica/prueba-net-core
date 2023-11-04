# Proyecto de Base de Datos SQL Server - LabDev

## Introducción

Este proyecto de base de datos SQL Server está diseñado para el desarrollo de la aplicación para la prueba tecnica fullstack usando netcore. A continuación, se proporciona una documentación general sobre la base de datos, sus objetos y la configuración inicial.

## Descripción general 

### Servidor

* Nombre: localhost:1433

#### Usuario Owner

* User: sa
* Password: abc123ABC

### Database: LabDev

#### Usuario para desarrollo

* User: developer
* Password: abc123ABC

#### Usuario para cliente backend

* User: client
* Password: abc123ABC

## Objetos de base de datos

### Tablas

El usuario owner puede acceder a las tablas directamente.
El usuario developer puede acceder a las tablas directamente.
El usuario cliente no puede acceder a las tablas directamente.

#### CatTipoCliente
|    | Columna     | Tipo de dato | Nullable |
|----|-------------|--------------|----------|
| 🔑 | Id          | int          | ❌        |
|    | TipoCliente | varchar(50)  | ❌        |

#### TblCliente
|    | Columna         | Tipo de dato | Nullable |
|----|-----------------|--------------|----------|
| 🔑 | Id              | int          | ❌        |
|    | RazonSocial     | varchar(50)  | ❌        |
| 🔐 | IdTipoCliente   | int          | ❌        |
|    | FechaDeCreacion | datetime     | ❌        |
|    | RFC             | varchar(50)  | ❌        |

#### CatProducto
|    | Columna        | Tipo de dato  | Nullable |
|----|----------------|---------------|----------|
| 🔑 | Id             | int           | ❌        |
|    | NombreProducto | varchar(50)   | ❌        |
|    | ImagenProducto | varchar(50)   | ✅        |
|    | Precio         | decimal(18,2) | ❌        |
|    | Descripcion    | varchar(50)   | ✅        |

#### TblDetalleFactura

|    | Columna            | Tipo de dato  | Nullable |
|----|--------------------|---------------|----------|
| 🔑 | Id                 | int           | ❌        |
| 🔐 | IdFactura          | int           | ❌        |
| 🔐 | IdProducto         | int           | ❌        |
|    | CantidadDeProducto | int           | ❌        |
|    | PrecioUnitario     | decimal(18,2) | ❌        |
|    | SubTotal           | decimal(18,2) | ❌        |
|    | Notas              | varchar(50)   | ✅        |

#### TblFactura

|    | Columna             | Tipo de dato  | Nullable |
|----|---------------------|---------------|----------|
| 🔑 | Id                  | int           | ❌        |
|    | FechaEmisionFactura | datetime      | ❌        |
| 🔐 | IdCliente           | int           | ❌        |
|    | NumeroDeFactura     | int           | ❌        |
|    | NumeroDeProductos   | int           | ❌        |
|    | SubTotalFactura     | decimal(18,2) | ❌        |
|    | TotalImpuestos      | decimal(18,2) | ❌        |
|    | TotalFactura        | decimal(18,2) | ❌        |

### Stored Procedures

El usuario owner puede ejecutar todos los stored procedures.
El usuario developer puede ejecutar todos los stored procedures.
El usuario cliente solo puede ejecutar los siguientes stored procedures: