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

-- spGetAllCatTipoCliente
-- spGetByIdCatTipoCliente
-- spCreateCatTipoCliente
-- spDeleteCatTipoCliente
-- spUpdateCatTipoCliente

-- spGetAllCatTipoCliente
IF EXISTS (SELECT * FROM sysobjects WHERE name='spGetAllCatTipoCliente' and xtype='P')
BEGIN
    DROP PROCEDURE spGetAllCatTipoCliente;
END
GO
CREATE PROCEDURE spGetAllCatTipoCliente
AS
BEGIN
    SELECT * FROM CatTipoCliente WHERE DeletedAt IS NULL;
END
GO
-- EXEC spGetAllCatTipoCliente;
-- spGetByIdCatTipoCliente
IF EXISTS (SELECT * FROM sysobjects WHERE name='spGetByIdCatTipoCliente' and xtype='P')
BEGIN
    DROP PROCEDURE spGetByIdCatTipoCliente;
END
GO
CREATE PROCEDURE spGetByIdCatTipoCliente
    @Id int
AS
BEGIN
    SELECT * FROM CatTipoCliente WHERE Id = @Id AND DeletedAt IS NULL;
END
GO
-- EXEC spGetByIdCatTipoCliente @Id = 1;
-- spCreateCatTipoCliente
IF EXISTS (SELECT * FROM sysobjects WHERE name='spCreateCatTipoCliente' and xtype='P')
BEGIN
    DROP PROCEDURE spCreateCatTipoCliente;
END
GO
CREATE PROCEDURE spCreateCatTipoCliente
    @TipoCliente varchar(50)
AS
BEGIN
    -- Crear el tipo de cliente
    INSERT INTO CatTipoCliente (TipoCliente) VALUES (@TipoCliente);
    -- Retornar el Row Insertado
    SELECT * FROM CatTipoCliente WHERE Id = (SELECT MAX(Id) FROM CatTipoCliente);
END
GO
-- EXEC spCreateCatTipoCliente @TipoCliente = 'Tipo 1';
-- spDeleteCatTipoCliente
IF EXISTS (SELECT * FROM sysobjects WHERE name='spDeleteCatTipoCliente' and xtype='P')
BEGIN
    DROP PROCEDURE spDeleteCatTipoCliente;
END
GO
CREATE PROCEDURE spDeleteCatTipoCliente
    @Id int
AS
BEGIN
    -- Validar que el tipo de cliente exista
    IF NOT EXISTS (SELECT * FROM CatTipoCliente WHERE Id = @Id)
    BEGIN
        PRINT 'El tipo de cliente no existe.';
        RETURN;
    END
    -- Validar que el tipo de cliente no este Deleteado
    IF EXISTS (SELECT * FROM CatTipoCliente WHERE Id = @Id AND DeletedAt IS NOT NULL)
    BEGIN
        PRINT 'El tipo de cliente esta cancelado.';
        RETURN;
    END
    -- Eliminar el tipo de cliente    
    UPDATE CatTipoCliente SET DeletedAt = GETDATE() WHERE Id = @Id;
    -- Retornar el tipo de cliente eliminado
    SELECT * FROM CatTipoCliente WHERE Id = @Id;
END
GO
-- EXEC spDeleteCatTipoCliente @Id = 1;
-- spUpdateCatTipoCliente
IF EXISTS (SELECT * FROM sysobjects WHERE name='spUpdateCatTipoCliente' and xtype='P')
BEGIN
    DROP PROCEDURE spUpdateCatTipoCliente;
END
GO
CREATE PROCEDURE spUpdateCatTipoCliente
    @Id int,
    @TipoCliente varchar(50)
AS
BEGIN
    -- Validar que el tipo de cliente exista
    IF NOT EXISTS (SELECT * FROM CatTipoCliente WHERE Id = @Id)
    BEGIN
        PRINT 'El tipo de cliente no existe.';
        RETURN;
    END
    -- Validar que el tipo de cliente no este Deleteado
    IF EXISTS (SELECT * FROM CatTipoCliente WHERE Id = @Id AND DeletedAt IS NOT NULL)
    BEGIN
        PRINT 'El tipo de cliente esta cancelado.';
        RETURN;
    END
    -- Actualizar el tipo de cliente
    UPDATE CatTipoCliente SET TipoCliente = @TipoCliente WHERE Id = @Id;
    -- Retornar el tipo de cliente actualizado
    SELECT * FROM CatTipoCliente WHERE Id = @Id;
END
GO
-- EXEC spUpdateCatTipoCliente @Id = 1, @TipoCliente = 'Tipo 1';


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

-- spGetAllTblCliente
-- spGetByIdTblCliente
-- spCreateTblCliente
-- spDeleteTblCliente
-- spUpdateTblCliente

-- spGetAllTblCliente
IF EXISTS (SELECT * FROM sysobjects WHERE name='spGetAllTblCliente' and xtype='P')
BEGIN
    DROP PROCEDURE spGetAllTblCliente;
END
GO
CREATE PROCEDURE spGetAllTblCliente
AS
BEGIN
    SELECT * FROM TblCliente WHERE DeletedAt IS NULL;
END
GO
-- EXEC spGetAllTblCliente;
-- spGetByIdTblCliente
IF EXISTS (SELECT * FROM sysobjects WHERE name='spGetByIdTblCliente' and xtype='P')
BEGIN
    DROP PROCEDURE spGetByIdTblCliente;
END
GO
CREATE PROCEDURE spGetByIdTblCliente
    @Id int
AS
BEGIN
    SELECT * FROM TblCliente WHERE Id = @Id AND DeletedAt IS NULL;
END
GO
-- EXEC spGetByIdTblCliente @Id = 1;
-- spCreateTblCliente
IF EXISTS (SELECT * FROM sysobjects WHERE name='spCreateTblCliente' and xtype='P')
BEGIN
    DROP PROCEDURE spCreateTblCliente;
END
GO
CREATE PROCEDURE spCreateTblCliente
    @RazonSocial varchar(50),
    @IdTipoCliente int,
    @FechaDeCreacion datetime,
    @RFC varchar(50)
AS
BEGIN
    -- Validar que el tipo de cliente exista
    IF NOT EXISTS (SELECT * FROM CatTipoCliente WHERE Id = @IdTipoCliente)
    BEGIN
        PRINT 'El tipo de cliente no existe.';
        RETURN;
    END
    -- Validar que el tipo de cliente no este Deleteado
    IF EXISTS (SELECT * FROM CatTipoCliente WHERE Id = @IdTipoCliente AND DeletedAt IS NOT NULL)
    BEGIN
        PRINT 'El tipo de cliente esta cancelado.';
        RETURN;
    END
    -- Crear el cliente
    INSERT INTO TblCliente (RazonSocial, IdTipoCliente, FechaDeCreacion, RFC) VALUES (@RazonSocial, @IdTipoCliente, @FechaDeCreacion, @RFC);
    -- Retornar el Row Insertado
    SELECT * FROM TblCliente WHERE Id = (SELECT MAX(Id) FROM TblCliente);
END
GO
-- EXEC spCreateTblCliente @RazonSocial = 'Cliente 1', @IdTipoCliente = 1, @FechaDeCreacion = GETDATE(), @RFC = 'RFC 1';
-- spDeleteTblCliente
IF EXISTS (SELECT * FROM sysobjects WHERE name='spDeleteTblCliente' and xtype='P')
BEGIN
    DROP PROCEDURE spDeleteTblCliente;
END
GO
CREATE PROCEDURE spDeleteTblCliente
    @Id int
AS
BEGIN
    -- Validar que el cliente exista
    IF NOT EXISTS (SELECT * FROM TblCliente WHERE Id = @Id)
    BEGIN
        PRINT 'El cliente no existe.';
        RETURN;
    END
    -- Validar que el cliente no este Deleteado
    IF EXISTS (SELECT * FROM TblCliente WHERE Id = @Id AND DeletedAt IS NOT NULL)
    BEGIN
        PRINT 'El cliente esta cancelado.';
        RETURN;
    END
    -- Eliminar el cliente
    UPDATE TblCliente SET DeletedAt = GETDATE() WHERE Id = @Id;
    -- Retornar el cliente eliminado
    SELECT * FROM TblCliente WHERE Id = @Id;
END
GO
-- EXEC spDeleteTblCliente @Id = 1;
-- spUpdateTblCliente
IF EXISTS (SELECT * FROM sysobjects WHERE name='spUpdateTblCliente' and xtype='P')
BEGIN
    DROP PROCEDURE spUpdateTblCliente;
END
GO
CREATE PROCEDURE spUpdateTblCliente
    @Id int,
    @RazonSocial varchar(50),
    @IdTipoCliente int,
    @FechaDeCreacion datetime,
    @RFC varchar(50)
AS
BEGIN
    -- Validar que el cliente exista
    IF NOT EXISTS (SELECT * FROM TblCliente WHERE Id = @Id)
    BEGIN
        PRINT 'El cliente no existe.';
        RETURN;
    END
    -- Validar que el cliente no este Deleteado
    IF EXISTS (SELECT * FROM TblCliente WHERE Id = @Id AND DeletedAt IS NOT NULL)
    BEGIN
        PRINT 'El cliente esta cancelado.';
        RETURN;
    END
    -- Validar que el tipo de cliente exista
    IF NOT EXISTS (SELECT * FROM CatTipoCliente WHERE Id = @IdTipoCliente)
    BEGIN
        PRINT 'El tipo de cliente no existe.';
        RETURN;
    END
    -- Validar que el tipo de cliente no este Deleteado
    IF EXISTS (SELECT * FROM CatTipoCliente WHERE Id = @IdTipoCliente AND DeletedAt IS NOT NULL)
    BEGIN
        PRINT 'El tipo de cliente esta cancelado.';
        RETURN;
    END
    -- Actualizar el cliente
    UPDATE TblCliente SET RazonSocial = @RazonSocial, IdTipoCliente = @IdTipoCliente, FechaDeCreacion = @FechaDeCreacion, RFC = @RFC WHERE Id = @Id;
    -- Retornar el cliente actualizado
    SELECT * FROM TblCliente WHERE Id = @Id;
END
GO
-- EXEC spUpdateTblCliente @Id = 1, @RazonSocial = 'Cliente 1', @IdTipoCliente = 1, @FechaDeCreacion = GETDATE(), @RFC = 'RFC 1';


-- Tabla CatProducto
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CatProducto' and xtype='U')
BEGIN
    CREATE TABLE CatProducto (
        Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
        NombreProducto varchar(50) NOT NULL,
        ImagenProducto varchar(100) NULL,
        Precio decimal(18,2) NOT NULL,
        Ext varchar(5) NOT NULL,
        CreatedAt datetime DEFAULT GETDATE(),
        UpdatedAt datetime DEFAULT GETDATE(),
        DeletedAt datetime
    );
END

-- spGetAllCatProducto
-- spGetByIdCatProducto
-- spCreateCatProducto
-- spDeleteCatProducto
-- spUpdateCatProducto

-- spGetAllCatProducto
IF EXISTS (SELECT * FROM sysobjects WHERE name='spGetAllCatProducto' and xtype='P')
BEGIN
    DROP PROCEDURE spGetAllCatProducto;
END
GO
CREATE PROCEDURE spGetAllCatProducto
AS
BEGIN
    SELECT * FROM CatProducto WHERE DeletedAt IS NULL;
END
GO
-- EXEC spGetAllCatProducto;
-- spGetByIdCatProducto
IF EXISTS (SELECT * FROM sysobjects WHERE name='spGetByIdCatProducto' and xtype='P')
BEGIN
    DROP PROCEDURE spGetByIdCatProducto;
END
GO
CREATE PROCEDURE spGetByIdCatProducto
    @Id int
AS
BEGIN
    SELECT * FROM CatProducto WHERE Id = @Id AND DeletedAt IS NULL;
END
GO
-- EXEC spGetByIdCatProducto @Id = 1;
-- spCreateCatProducto
IF EXISTS (SELECT * FROM sysobjects WHERE name='spCreateCatProducto' and xtype='P')
BEGIN
    DROP PROCEDURE spCreateCatProducto;
END
GO
CREATE PROCEDURE spCreateCatProducto
    @NombreProducto varchar(50),
    @ImagenProducto varchar(100),
    @Precio decimal(18,2),
    @Ext varchar(5)
AS
BEGIN
    -- Crear el producto
    INSERT INTO CatProducto (NombreProducto, ImagenProducto, Precio, Ext) VALUES (@NombreProducto, @ImagenProducto, @Precio, @Ext);
    -- Retornar el Row Insertado
    SELECT * FROM CatProducto WHERE Id = (SELECT MAX(Id) FROM CatProducto);
END
GO
-- EXEC spCreateCatProducto @NombreProducto = 'Producto 1', @ImagenProducto = 'Imagen 1', @Precio = 100.00, @Ext = 'jpg';
-- spDeleteCatProducto
IF EXISTS (SELECT * FROM sysobjects WHERE name='spDeleteCatProducto' and xtype='P')
BEGIN
    DROP PROCEDURE spDeleteCatProducto;
END
GO
CREATE PROCEDURE spDeleteCatProducto
    @Id int
AS
BEGIN
    -- Validar que el producto exista
    IF NOT EXISTS (SELECT * FROM CatProducto WHERE Id = @Id)
    BEGIN
        PRINT 'El producto no existe.';
        RETURN;
    END
    -- Validar que el producto no este Deleteado
    IF EXISTS (SELECT * FROM CatProducto WHERE Id = @Id AND DeletedAt IS NOT NULL)
    BEGIN
        PRINT 'El producto esta cancelado.';
        RETURN;
    END
    -- Eliminar el producto
    UPDATE CatProducto SET DeletedAt = GETDATE() WHERE Id = @Id;
    -- Retornar el producto eliminado
    SELECT * FROM CatProducto WHERE Id = @Id;
END
GO
-- EXEC spDeleteCatProducto @Id = 1;
-- spUpdateCatProducto
IF EXISTS (SELECT * FROM sysobjects WHERE name='spUpdateCatProducto' and xtype='P')
BEGIN
    DROP PROCEDURE spUpdateCatProducto;
END
GO
CREATE PROCEDURE spUpdateCatProducto
    @Id int,
    @NombreProducto varchar(50),
    @ImagenProducto varchar(100),
    @Precio decimal(18,2),
    @Ext varchar(5)
AS
BEGIN
    -- Validar que el producto exista
    IF NOT EXISTS (SELECT * FROM CatProducto WHERE Id = @Id)
    BEGIN
        PRINT 'El producto no existe.';
        RETURN;
    END
    -- Validar que el producto no este Deleteado
    IF EXISTS (SELECT * FROM CatProducto WHERE Id = @Id AND DeletedAt IS NOT NULL)
    BEGIN
        PRINT 'El producto esta cancelado.';
        RETURN;
    END
    -- Actualizar el producto
    UPDATE CatProducto SET NombreProducto = @NombreProducto, ImagenProducto = @ImagenProducto, Precio = @Precio, Ext = @Ext WHERE Id = @Id;
    -- Retornar el producto actualizado
    SELECT * FROM CatProducto WHERE Id = @Id;
END
GO
-- EXEC spUpdateCatProducto @Id = 1, @NombreProducto = 'Producto 1', @ImagenProducto = 'Imagen 1', @Precio = 100.00, @Ext = 'jpg';


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

-- spGetAllTblFactura
-- spGetByIdTblFactura
-- spCreateTblFactura ESTA CONTIENE TODA LA LOGICA PARA CREAR LA FACTURA, se deben pasar los datos minimos para crear la factura lo demas debe calcularse en el SP o se genera automaticamente en el SP
-- spUpdateTblFactura Esta solo recuenta el # de productos y recalcula los totales

-- spGetAllTblFactura
IF EXISTS (SELECT * FROM sysobjects WHERE name='spGetAllTblFactura' and xtype='P')
BEGIN
    DROP PROCEDURE spGetAllTblFactura;
END
GO
CREATE PROCEDURE spGetAllTblFactura
AS
BEGIN
    SELECT * FROM TblFactura WHERE DeletedAt IS NULL;
END
GO
-- EXEC spGetAllTblFactura;
-- spGetByIdTblFactura
IF EXISTS (SELECT * FROM sysobjects WHERE name='spGetByIdTblFactura' and xtype='P')
BEGIN
    DROP PROCEDURE spGetByIdTblFactura;
END
GO
CREATE PROCEDURE spGetByIdTblFactura
    @Id int
AS
BEGIN
    SELECT * FROM TblFactura WHERE Id = @Id AND DeletedAt IS NULL;
END
GO
-- EXEC spGetByIdTblFactura @Id = 1;
-- spCreateTblFactura
IF EXISTS (SELECT * FROM sysobjects WHERE name='spCreateTblFactura' and xtype='P')
BEGIN
    DROP PROCEDURE spCreateTblFactura;
END
GO
CREATE PROCEDURE spCreateTblFactura
    @IdCliente int
AS
BEGIN
    -- Validar que el cliente exista
    IF NOT EXISTS (SELECT * FROM TblCliente WHERE Id = @IdCliente)
    BEGIN
        PRINT 'El cliente no existe.';
        RETURN;
    END
    -- Validar que el cliente no este Deleteado
    IF EXISTS (SELECT * FROM TblCliente WHERE Id = @IdCliente AND DeletedAt IS NOT NULL)
    BEGIN
        PRINT 'El cliente esta cancelado.';
        RETURN;
    END
    -- Crear la factura
    -- DECLARE @IdCliente int = 1;
    DECLARE @FechaEmisionFactura datetime = GETDATE();
    DECLARE @NumeroDeFactura int = (SELECT COUNT(*) FROM TblFactura) + 1;
    DECLARE @SubTotalFactura decimal(18,2) = (SELECT SUM(SubTotal) FROM TblDetalleFactura WHERE IdFactura = (SELECT MAX(Id) FROM TblFactura));
    DECLARE @TotalImpuestos decimal(18,2) = (@SubTotalFactura * 0.19);
    DECLARE @TotalFactura decimal(18,2) = (@SubTotalFactura + @TotalImpuestos);
    DECLARE @NumeroDeProductos int = (SELECT COUNT(*) FROM TblDetalleFactura WHERE IdFactura = (SELECT MAX(Id) FROM TblFactura)) + 0;
    -- Validar que en los valores calculados no existan NULL
    IF @SubTotalFactura IS NULL
    BEGIN
        SET @SubTotalFactura = 0;
    END
    IF @TotalImpuestos IS NULL
    BEGIN
        SET @TotalImpuestos = 0;
    END
    IF @TotalFactura IS NULL
    BEGIN
        SET @TotalFactura = 0;
    END
    IF @NumeroDeProductos IS NULL
    BEGIN
        SET @NumeroDeProductos = 0;
    END
    INSERT INTO TblFactura (FechaEmisionFactura, IdCliente, NumeroDeFactura, NumeroDeProductos, SubTotalFactura, TotalImpuestos, TotalFactura) VALUES (@FechaEmisionFactura, @IdCliente, @NumeroDeFactura, @NumeroDeProductos, @SubTotalFactura, @TotalImpuestos, @TotalFactura);
    -- Retornar el Row Insertado
    SELECT * FROM TblFactura WHERE Id = (SELECT MAX(Id) FROM TblFactura);
END    
GO
-- EXEC spCreateTblFactura @IdCliente = 1;
-- spUpdateTblFactura
IF EXISTS (SELECT * FROM sysobjects WHERE name='spUpdateTblFactura' and xtype='P')
BEGIN
    DROP PROCEDURE spUpdateTblFactura;
END
GO
CREATE PROCEDURE spUpdateTblFactura
    @Id int,
    @Return int = 1 OUTPUT -- 0 = No retornar la factura actualizada, 1 = Retornar la factura actualizada, Por defecto se retorna la factura actualizada
AS
BEGIN
    -- Validar que la factura exista
    IF NOT EXISTS (SELECT * FROM TblFactura WHERE Id = @Id)
    BEGIN
        PRINT 'La factura no existe.';
        RETURN;
    END
    -- Validar que la factura no este Deleteada
    IF EXISTS (SELECT * FROM TblFactura WHERE Id = @Id AND DeletedAt IS NOT NULL)
    BEGIN
        PRINT 'La factura esta cancelada.';
        RETURN;
    END
    -- Actualizar la factura
    DECLARE @NumeroDeProductos int = (SELECT COUNT(*) FROM TblDetalleFactura WHERE IdFactura = @Id);
    DECLARE @SubTotalFactura decimal(18,2) = (SELECT SUM(SubTotal) FROM TblDetalleFactura WHERE IdFactura = @Id);
    DECLARE @TotalImpuestos decimal(18,2) = (@SubTotalFactura * 0.19);
    DECLARE @TotalFactura decimal(18,2) = (@SubTotalFactura + @TotalImpuestos);
    -- Validar que en los valores calculados no existan NULL
    IF @SubTotalFactura IS NULL
    BEGIN
        SET @SubTotalFactura = 0;
    END
    IF @TotalImpuestos IS NULL
    BEGIN
        SET @TotalImpuestos = 0;
    END
    IF @TotalFactura IS NULL
    BEGIN
        SET @TotalFactura = 0;
    END
    IF @NumeroDeProductos IS NULL
    BEGIN
        SET @NumeroDeProductos = 0;
    END
    UPDATE TblFactura SET NumeroDeProductos = @NumeroDeProductos, SubTotalFactura = @SubTotalFactura, TotalImpuestos = @TotalImpuestos, TotalFactura = @TotalFactura WHERE Id = @Id;
    -- Retornar la factura actualizada si @Return = 1
    IF @Return = 1
    BEGIN
        SELECT * FROM TblFactura WHERE Id = @Id;
    END
END
GO
-- EXEC spUpdateTblFactura @Id = 1;


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

-- spGetAllTblDetalleFactura
-- spGetByIdTblDetalleFactura
-- spCreateTblDetalleFactura ESTA CONTIENE TODA LA LOGICA PARA CREAR EL DETALLE DE LA FACTURA, se deben pasar los datos minimos para crear el detalle de la factura lo demas debe calcularse en el SP o se genera automaticamente en el SP Tambien se debe actualizar la factura con el SP spUpdateTblFactura

-- spGetAllTblDetalleFactura
IF EXISTS (SELECT * FROM sysobjects WHERE name='spGetAllTblDetalleFactura' and xtype='P')
BEGIN
    DROP PROCEDURE spGetAllTblDetalleFactura;
END
GO
CREATE PROCEDURE spGetAllTblDetalleFactura
AS
BEGIN
    SELECT * FROM TblDetalleFactura WHERE DeletedAt IS NULL;
END
GO
-- EXEC spGetAllTblDetalleFactura;
-- spGetByIdTblDetalleFactura
IF EXISTS (SELECT * FROM sysobjects WHERE name='spGetByIdTblDetalleFactura' and xtype='P')
BEGIN
    DROP PROCEDURE spGetByIdTblDetalleFactura;
END
GO
CREATE PROCEDURE spGetByIdTblDetalleFactura
    @Id int
AS
BEGIN
    SELECT * FROM TblDetalleFactura WHERE Id = @Id AND DeletedAt IS NULL;
END
GO
-- EXEC spGetByIdTblDetalleFactura @Id = 1;
-- spCreateTblDetalleFactura
IF EXISTS (SELECT * FROM sysobjects WHERE name='spCreateTblDetalleFactura' and xtype='P')
BEGIN
    DROP PROCEDURE spCreateTblDetalleFactura;
END
GO
CREATE PROCEDURE spCreateTblDetalleFactura
    @IdFactura int,
    @IdProducto int,
    @CantidadDeProducto int,
    @Notas varchar(50)
AS
BEGIN
    -- Validar que el producto exista
    IF NOT EXISTS (SELECT * FROM CatProducto WHERE Id = @IdProducto)
    BEGIN
        PRINT 'El producto no existe.';
        RETURN;
    END
    -- Validar que la factura exista
    IF NOT EXISTS (SELECT * FROM TblFactura WHERE Id = @IdFactura)
    BEGIN
        PRINT 'La factura no existe.';
        RETURN;
    END
    -- Validar que la factura no este Deleteada
    IF EXISTS (SELECT * FROM TblFactura WHERE Id = @IdFactura AND DeletedAt IS NOT NULL)
    BEGIN
        PRINT 'La factura esta cancelada.';
        RETURN;
    END
    -- Validar que el producto no este Deleteado
    IF EXISTS (SELECT * FROM CatProducto WHERE Id = @IdProducto AND DeletedAt IS NOT NULL)
    BEGIN
        PRINT 'El producto esta cancelado.';
        RETURN;
    END
    -- Crear el detalle de la factura
    DECLARE @PrecioUnitario decimal(18,2) = (SELECT Precio FROM CatProducto WHERE Id = @IdProducto);
    DECLARE @SubTotal decimal(18,2) = (@PrecioUnitario * @CantidadDeProducto);
    -- Validar que en los valores calculados no existan NULL
    IF @PrecioUnitario IS NULL
    BEGIN
        SET @PrecioUnitario = 0;
    END
    IF @SubTotal IS NULL
    BEGIN
        SET @SubTotal = 0;
    END
    -- Crear el detalle de la factura
    INSERT INTO TblDetalleFactura (IdFactura, IdProducto, CantidadDeProducto, PrecioUnitario, SubTotal, Notas) VALUES (@IdFactura, @IdProducto, @CantidadDeProducto, @PrecioUnitario, @SubTotal, @Notas);
    EXEC spUpdateTblFactura @Id = @IdFactura, @Return = 0;
    -- Retornar el Row Insertado
    SELECT * FROM TblDetalleFactura WHERE Id = (SELECT MAX(Id) FROM TblDetalleFactura);
END
GO
-- EXEC spCreateTblDetalleFactura @IdFactura = 1, @IdProducto = 1, @CantidadDeProducto = 1, @Notas = 'Notas 1';

PRINT 'Tablas de la base de datos LabDev creadas satisfactoriamente.';