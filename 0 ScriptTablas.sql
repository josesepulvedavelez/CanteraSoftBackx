CREATE DATABASE CanteraSoft20x;
USE CanteraSoft20x;

CREATE TABLE Cliente
(
    ClienteId INT IDENTITY(1, 1) PRIMARY KEY,
    Nombre VARCHAR(200) NOT NULL,
    NitCc VARCHAR(50) NOT NULL,
    Contacto VARCHAR(200) NOT NULL,
    Telefono VARCHAR(50) NULL,
    Celular VARCHAR(50) NOT NULL,
    Correo VARCHAR(500) NULL,

    Estado INT NOT NULL,
    Observaciones VARCHAR(MAX) NULL,
    FechaLog DATETIME DEFAULT GETDATE(),
    UsuarioLog VARCHAR(50) NULL
);

CREATE TABLE Vehiculo
(
    VehiculoId INT IDENTITY(1, 1) PRIMARY KEY,
    Placa VARCHAR(10),
    Mt3 FLOAT,
    ClienteId INT FOREIGN KEY REFERENCES Cliente(ClienteId) ON DELETE CASCADE ON UPDATE CASCADE,

    Estado INT,
    Observaciones VARCHAR(MAX),
    FechaLog DATETIME DEFAULT GETDATE(),
    UsuarioLog VARCHAR(50)
);

CREATE TABLE Contrato
(
    ContratoId INT IDENTITY(1, 1) PRIMARY KEY,
    FechaCelebracion DATETIME,
    FechaFinal DATETIME,
    Descripcion VARCHAR(MAX),
    SubTotal FLOAT,
    Iva FLOAT,
    TotalPagar FLOAT,
    TotalPagos FLOAT,
    Saldo FLOAT,
    ClienteId INT FOREIGN KEY REFERENCES Cliente(ClienteId) ON DELETE CASCADE ON UPDATE CASCADE,

    Estado INT,
    Observaciones VARCHAR(MAX),
    FechaLog DATETIME DEFAULT GETDATE(),
    UsuarioLog VARCHAR(50)
);

CREATE TABLE Material
(
    MaterialId INT IDENTITY(1, 1) PRIMARY KEY,
    Codigo VARCHAR(10),
    Descripcion VARCHAR(50),
    Medida VARCHAR(10),

    Estado INT,
    Observaciones VARCHAR(MAX),
    FechaLog DATETIME DEFAULT GETDATE(),
    UsuarioLog VARCHAR(50)
);

CREATE TABLE Venta
(
    VentaId INT IDENTITY(1, 1) PRIMARY KEY,
    Cantidad FLOAT,
    Precio FLOAT,
    Subtotal FLOAT,
    ContratoId INT FOREIGN KEY REFERENCES Contrato(ContratoId) ON DELETE CASCADE ON UPDATE CASCADE,
    MaterialId INT FOREIGN KEY REFERENCES Material(MaterialId) ON DELETE CASCADE ON UPDATE CASCADE,

    Estado INT,
    Observaciones VARCHAR(MAX),
    FechaLog DATETIME DEFAULT GETDATE(),
    UsuarioLog VARCHAR(50)
);

CREATE TABLE Empleado
(
    EmpleadoId INT IDENTITY(1, 1) PRIMARY KEY,
    Nombres VARCHAR(200),
    Cedula VARCHAR(50),
    Cargo VARCHAR(200),

    Estado INT,
    Observaciones VARCHAR(MAX),
    FechaLog DATETIME DEFAULT GETDATE(),
    UsuarioLog VARCHAR(50)
);

CREATE TABLE Maquina
(
    MaquinaId INT IDENTITY(1, 1) PRIMARY KEY,
    Marca VARCHAR(100),
    Modelo VARCHAR(100),
    Serie VARCHAR(100),
    Combustible VARCHAR(20),
    Placa VARCHAR(10),

    Estado INT,
    Observaciones VARCHAR(MAX),
    FechaLog DATETIME DEFAULT GETDATE(),
    UsuarioLog VARCHAR(50)
);

CREATE TABLE Operacion
(
    OperacionId INT IDENTITY(1, 1) PRIMARY KEY,
    Numero VARCHAR(10),
    Fecha DATETIME,
    Hora TIME,
    Mt3Digitado FLOAT,
    Mt3Capturado FLOAT,
    Morro FLOAT,
    ClienteId int /*FOREIGN KEY REFERENCES Cliente(ClienteId) ON DELETE CASCADE ON UPDATE CASCADE*/,
    ContratoId INT FOREIGN KEY REFERENCES Contrato(ContratoId) ON DELETE CASCADE ON UPDATE CASCADE,
    MaterialId INT FOREIGN KEY REFERENCES Material(MaterialId) ON DELETE CASCADE ON UPDATE CASCADE,
    VehiculoId INT /*FOREIGN KEY REFERENCES Vehiculo(VehiculoId) ON DELETE CASCADE ON UPDATE CASCADE*/,
    MaquinaId INT FOREIGN KEY REFERENCES Maquina(MaquinaId) ON DELETE CASCADE ON UPDATE CASCADE,
    EmpleadoId INT FOREIGN KEY REFERENCES Empleado(EmpleadoId) ON DELETE CASCADE ON UPDATE CASCADE,

    Estado INT,
    Observaciones VARCHAR(MAX),
    FechaLog DATETIME DEFAULT GETDATE(),
    UsuarioLog VARCHAR(50)
);