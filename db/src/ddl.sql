PRINT 'Creando las tablas de la base de datos LabDev...';

-- Uso de la base de datos
USE LabDev;

-- Crear las tablas si no existen
-- Tabla CatTipoCliente
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CatTipoCliente' and xtype='U')
BEGIN
    CREATE TABLE CatTipoCliente (
        Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
        TipoCliente varchar(50) NOT NULL,
        CreatedAt datetime DEFAULT GETDATE(),
        UpdatedAt datetime DEFAULT GETDATE(),
        DeletedAt datetime
    );
END

-- Tabla TblCliente
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TblCliente' and xtype='U')
BEGIN
    CREATE TABLE TblCliente (
        Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
        RazonSocial varchar(50) NOT NULL,
        IdTipoCliente int NOT NULL,
        FechaDeCreacion datetime NOT NULL,
        RFC varchar(50) NOT NULL,
        CreatedAt datetime DEFAULT GETDATE(),
        UpdatedAt datetime DEFAULT GETDATE(),
        DeletedAt datetime,
        FOREIGN KEY (IdTipoCliente) REFERENCES CatTipoCliente(Id)
    );
END

-- Tabla CatProducto
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CatProducto' and xtype='U')
BEGIN
    CREATE TABLE CatProducto (
        Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
        NombreProducto varchar(50) NOT NULL,
        ImagenProducto varchar(100) NULL,
        Precio decimal(18,2) NOT NULL,
        Descripcion varchar(50) NULL,
        CreatedAt datetime DEFAULT GETDATE(),
        UpdatedAt datetime DEFAULT GETDATE(),
        DeletedAt datetime
    );
END

-- Tabla TblFactura
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TblFactura' and xtype='U')
BEGIN
    CREATE TABLE TblFactura (
        Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
        FechaEmisionFactura datetime NOT NULL,
        IdCliente int NOT NULL,
        NumeroDeFactura int NOT NULL,
        NumeroDeProductos int NOT NULL,
        SubTotalFactura decimal(18,2) NOT NULL,
        TotalImpuestos decimal(18,2) NOT NULL,
        TotalFactura decimal(18,2) NOT NULL,
        CreatedAt datetime DEFAULT GETDATE(),
        UpdatedAt datetime DEFAULT GETDATE(),
        DeletedAt datetime,
        FOREIGN KEY (IdCliente) REFERENCES TblCliente(Id)
    );
END

-- Tabla TblDetalleFactura
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TblDetalleFactura' and xtype='U')
BEGIN
    CREATE TABLE TblDetalleFactura (
        Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
        IdFactura int NOT NULL,
        IdProducto int NOT NULL,
        CantidadDeProducto int NOT NULL,
        PrecioUnitario decimal(18,2) NOT NULL,
        SubTotal decimal(18,2) NOT NULL,
        Notas varchar(50) NULL,
        CreatedAt datetime DEFAULT GETDATE(),
        UpdatedAt datetime DEFAULT GETDATE(),
        DeletedAt datetime,
        FOREIGN KEY (IdFactura) REFERENCES TblFactura(Id),
        FOREIGN KEY (IdProducto) REFERENCES CatProducto(Id)
    );
END

PRINT 'Tablas de la base de datos LabDev creadas satisfactoriamente.';