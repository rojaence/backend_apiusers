CREATE DATABASE db_users;
GO

USE db_users;
GO

CREATE TABLE Profiles (
    profileId INT IDENTITY(1, 1) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    description VARCHAR(200) NOT NULL
);
GO

CREATE TABLE Positions (
    positionId INT IDENTITY(1, 1) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    description VARCHAR(200) NOT NULL
);
GO

CREATE TABLE Users (
    userId INT IDENTITY(1, 1) PRIMARY KEY,
    firstName NVARCHAR(50) NOT NULL,
    lastName NVARCHAR(50) NOT NULL,
    age INT NOT NULL,
    birthDate DATE NOT NULL,
    address VARCHAR(200) NOT NULL,
    status BIT,
    profileId INT FOREIGN KEY REFERENCES Profiles(profileId),
    positionId INT FOREIGN KEY REFERENCES Positions(positionId)
);
GO

INSERT INTO Profiles
VALUES
('Administrador', 'Rango mas alto del sistema'),
('Supervisor', 'Usuario administrativo del sistema'),
('Operador', 'Usuario básico del sistema');

INSERT INTO Positions
VALUES
('Lider de proyectos', 'Direccion y gestion de proyectos'),
('Gerente de proyectos', 'Director ejecutivo de la empresa'),
('Desarrollador', 'Direccion y gestion de proyectos');

-- Inserción de usuarios en la tabla Users

-- Inserción de un Administrador (Líder de proyectos)
INSERT INTO Users (firstName, lastName, age, birthDate, address, status, profileId, positionId)
VALUES 
('Carlos', 'González', 35, '1989-04-12', 'Calle Ficticia 123', 1, 1, 1);  -- profileId = 1 (Administrador), positionId = 1 (Líder de proyectos)

-- Inserción de un Supervisor (Gerente de proyectos)
INSERT INTO Users (firstName, lastName, age, birthDate, address, status, profileId, positionId)
VALUES 
('Ana', 'Martínez', 42, '1982-11-23', 'Avenida Ejemplo 456', 1, 2, 2);  -- profileId = 2 (Supervisor), positionId = 2 (Gerente de proyectos)

-- Inserción de un Operador (Desarrollador)
INSERT INTO Users (firstName, lastName, age, birthDate, address, status, profileId, positionId)
VALUES 
('Pedro', 'López', 28, '1996-02-10', 'Calle Modelo 789', 1, 3, 3);  -- profileId = 3 (Operador), positionId = 3 (Desarrollador)
