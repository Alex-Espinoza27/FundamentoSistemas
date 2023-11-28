

CREATE DATABASE dbRRHH

CREATE TABLE Empleado(
Codigo_empleado INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
DNI VARCHAR(10) NOT NULL,
Nombre varchar(20) NOT NULL,
Apellido VARCHAR(20) NOT NULL,
FechaNacimiento DATE NOT NULL, 
FechaContratacion DATE NOT NULL,
Salario MONEY NOT NULL
)

CREATE TABLE Empleos(
Codigo_empleo INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
NombreEmpleo varchar(50) NOT NULL,  
SalarioMinimo MONEY NOT NULL,
SalarioMaximo MONEY NOT NULL,
)

CREATE TABLE HistorialEmpleos(
Codigo_empleo INT FOREIGN KEY REFERENCES Empleos(Codigo_empleo) NOT NULL,
Codigo_empleado INT FOREIGN KEY REFERENCES Empleado(Codigo_empleado) NOT NULL,  
FechaInicio DATE NOT NULL,
FechaFIN DATE NOT NULL,
CONSTRAINT PK_Hitrial Primary Key (Codigo_empleo,Codigo_empleado)
)

