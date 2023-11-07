PRINT 'Creando datos de prueba...';

USE LabDev;

-- Crear datos de prueba
-- Tabla CatTipoCliente
IF NOT EXISTS (SELECT * FROM CatTipoCliente)
BEGIN
    INSERT INTO CatTipoCliente (TipoCliente) VALUES ('Persona Física');
    INSERT INTO CatTipoCliente (TipoCliente) VALUES ('Persona Moral');
END

-- Tabla TblCliente
IF NOT EXISTS (SELECT * FROM TblCliente)
BEGIN
    INSERT INTO TblCliente (RazonSocial, IdTipoCliente, FechaDeCreacion, RFC) VALUES ('Juan Perez', 1, GETDATE(), 'PEPJ123456789');
    INSERT INTO TblCliente (RazonSocial, IdTipoCliente, FechaDeCreacion, RFC) VALUES ('Pedro Sanchez', 1, GETDATE(), 'SAPJ123456789');
    INSERT INTO TblCliente (RazonSocial, IdTipoCliente, FechaDeCreacion, RFC) VALUES ('Sociedad Anónima de Capital Variable', 2, GETDATE(), 'SACV123456789');
END

-- Tabla CatProducto
IF NOT EXISTS (SELECT * FROM CatProducto)
BEGIN
    INSERT INTO CatProducto (NombreProducto, ImagenProducto, Precio, Ext) VALUES ('Donna Gueterman', 'https://rickandmortyapi.com/api/character/avatar/102.jpeg', 100.00, 'p1l2k');
    INSERT INTO CatProducto (NombreProducto, ImagenProducto, Precio, Ext) VALUES ('Crow Horse', 'https://rickandmortyapi.com/api/character/avatar/813.jpeg', 200.00, 'a1s2d');
    INSERT INTO CatProducto (NombreProducto, ImagenProducto, Precio, Ext) VALUES ('Japheths Eldest Son', 'https://rickandmortyapi.com/api/character/avatar/677.jpeg', 300.00, 'w2e3r');
    INSERT INTO CatProducto (NombreProducto, ImagenProducto, Precio, Ext) VALUES ('Prince Nebulon', 'https://rickandmortyapi.com/api/character/avatar/270.jpeg', 400.00, '2e3r4');
    INSERT INTO CatProducto (NombreProducto, ImagenProducto, Precio, Ext, DeletedAt) VALUES ('Prince Nebulon', 'https://rickandmortyapi.com/api/character/avatar/270.jpeg', 400.00, '2e3r4', GETDATE());

END

PRINT 'Datos de prueba creados con éxito.';