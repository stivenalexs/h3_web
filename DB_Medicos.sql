CREATE DATABASE DB_Medicos;
USE DB_Medicos;
drop database DB_Medicos
-- Tabla Persona
CREATE TABLE Persona (
    ID_Persona varchar(50) PRIMARY KEY not null,
	Documento varchar(20) not null,
    Nombre VARCHAR(50) not null,
	Fecha_Nacimiento DATE not null,
	Telefono VARCHAR(15),
	Correo VARCHAR(50) not null,
    Contraseña VARCHAR(20) not null,
    Foto VARCHAR(255),
	Tipo_Sangre VARCHAR(10),
);

-- Tabla Administrador
CREATE TABLE Administrador (
    ID_Persona varchar(50) PRIMARY KEY not null,
    Clave VARCHAR(50) not null,
    FOREIGN KEY (ID_Persona) REFERENCES Persona(ID_Persona)
);

-- Tabla Paciente
CREATE TABLE Paciente (
    Doc_Paciente varchar(50) PRIMARY KEY not null,
	Tipo_documento varchar(30) not null,
    FOREIGN KEY (Doc_Paciente) REFERENCES Persona(ID_Persona)
);
-- tabla Horario
CREATE TABLE Horario (
ID_Horario varchar(50) PRIMARY KEY not null,
Hora_Entrada time not null,
Hora_Salida time not null,
Especialidad varchar(80) not null
)

-- Tabla Profesional
CREATE TABLE Profesional(
    Doc_Pro varchar(50) primary key not null,
    Horario VARCHAR(50) not null,
    FOREIGN KEY (Doc_Pro) REFERENCES Persona(ID_Persona),
	FOREIGN KEY (Horario) REFERENCES Horario(ID_Horario)
);

-- Tabla Consulta
CREATE TABLE Cita (
    Cod_Cita int PRIMARY KEY identity(1,1) not null,
    Doc_Paciente varchar(50) not null,
    Doc_Profesional varchar(50) not null,
	Fecha_Cita DATE not null,
    Hora_Cita TIME not null,
    Estado VARCHAR(255) not null,
    FOREIGN KEY (Doc_Paciente) REFERENCES Paciente(Doc_Paciente),
	FOREIGN KEY (Doc_Profesional) REFERENCES Profesional(Doc_Pro)
);

-- Tabla Orden
CREATE TABLE Orden (
    Cod_Orden int PRIMARY KEY identity(1,1) not null,
    Cod_Cita int not null,
    Diagnostico VARCHAR(255) not null,
    Medicamento VARCHAR(255) ,
	Recomendacion VARCHAR(255),
	Remision VARCHAR(255), 
    FOREIGN KEY (Cod_Cita) REFERENCES Cita(Cod_Cita)
);

-- Tabla Historial_Clinico
CREATE TABLE Historial_Clinico (
    Doc_Paciente varchar(50) not null,
    Orden int not null,
    FOREIGN KEY (Doc_Paciente) REFERENCES Paciente(Doc_Paciente),
	FOREIGN KEY (Orden) REFERENCES Orden(Cod_Orden)
);

-- Tabla Procedimiento
CREATE TABLE Procedimiento (
    Cod_Procedimiento int PRIMARY KEY identity(1,1) not null,
    Tipo_P VARCHAR(50) not null,
	Fecha_P date ,
	Hora_P time ,
    Estado_P VARCHAR(50) not null,
	Pro_Asignado Varchar(50) not null,
    FOREIGN KEY (Cod_Procedimiento) REFERENCES Orden(Cod_Orden),
	FOREIGN KEY (Pro_Asignado) REFERENCES Profesional(Doc_Pro)
);
-- Tabla Nomina
CREATE TABLE Nomina (
    ID_Nomina int PRIMARY KEY identity(1,1) not null,
    Doc_Pro VARCHAR(50) not null,
    Salario DECIMAL(10, 2) not null,
    Fecha_Pago DATE not null,
	Estado varchar(40) not null,
    FOREIGN KEY (Doc_Pro) REFERENCES Profesional(Doc_Pro)
);


