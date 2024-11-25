use DB_Medicos

-- procedimientos almacenados CRUD 

--tabla Cita

--INDEX
go
alter Procedure SP_Cita_Index
as
begin
  Select * from Cita
  Select Scope_identity()
end
---alter
go
alter Procedure SP_Cita_Create
(@Doc_Paciente varchar(50), @Doc_Profesional varchar(50),
@Fecha_Cita DATE, @Hora_Cita TIME, @Estado VARCHAR(50) )
as
begin
	insert into Cita(Doc_Paciente,Doc_Profesional,Fecha_Cita,Hora_Cita,Estado) values (@Doc_Paciente, @Doc_Profesional,
	@Fecha_Cita, @Hora_Cita, @Estado )
	Select Scope_identity()
end

	---READ
go
alter Procedure SP_Cita_Read (@Cod_Cita int)
as
begin
  Select * from Cita where Cod_Cita=@Cod_Cita
  Select Scope_identity()
end
---UPDATE
go
alter Procedure SP_Cita_Update
(@Cod_Cita int, @Doc_Paciente varchar(50), @Doc_Profesional varchar(50),
@Fecha_Cita DATE, @Hora_Cita TIME, @Estado VARCHAR(50) )
as
begin
	update Cita set  Doc_Paciente=@Doc_Paciente, Doc_Profesional=@Doc_Profesional,
	Fecha_Cita=@Fecha_Cita, Hora_Cita=@Hora_Cita, Estado=@Estado  where	Cod_Cita=@Cod_Cita
	Select Scope_identity()
end

---DELETE
go
alter Procedure SP_Cita_Delete (@Cod_Cita int)
as
begin
	Delete from Cita where Cod_Cita=@Cod_Cita
	Select Scope_identity()
end

--tabla Orden

--INDEX
go
alter Procedure SP_Orden_Index
as
begin
  Select * from Orden
end
Select Scope_identity()
---alter
go
alter Procedure SP_Orden_Create
(@Cod_Orden int, @Cod_Cita int, @Diagnostico VARCHAR(255),
@Medicamento VARCHAR(255), @Recomendacion VARCHAR(255), @Remision VARCHAR(255) )
as
begin
	insert into Orden values (@Cod_Orden, @Cod_Cita, @Diagnostico,
	@Medicamento, @Recomendacion, @Remision )
	Select Scope_identity()
end

---READ
go
alter Procedure SP_Orden_Read (@Cod_Orden int)
as
begin
  Select * from Orden where Cod_Cita=@Cod_Orden
  Select Scope_identity()
end

---UPDATE
go
alter Procedure SP_Orden_Update
(@Cod_Orden int, @Cod_Cita int, @Diagnostico VARCHAR(255),
@Medicamento VARCHAR(255), @Recomendacion VARCHAR(255), @Remision VARCHAR(255) )
as
begin
	update Orden set  Cod_Cita=@Cod_Cita, Diagnostico=@Diagnostico,
	Medicamento=@Medicamento, Recomendacion=@Recomendacion, Remision=@Remision
	where Cod_Orden=@Cod_Orden
	
	Select Scope_identity()
end

---DELETE
go
alter Procedure SP_Orden_Delete (@Cod_Orden int)
as
begin
	Delete from Orden where Cod_Orden=@Cod_Orden
	Select Scope_identity()
end

--tabla Paciente

--INDEX
go
alter Procedure SP_Paciente_Index
as
begin
  Select * from Paciente
  Select Scope_identity()
end

---alter
go
alter Procedure SP_Paciente_Create
(@Doc_Paciente varchar(50), @Tipo_documento varchar(30))
as
begin
	insert into Paciente values (@Doc_Paciente, @Tipo_documento)
	Select Scope_identity()
end


---READ
go
alter Procedure SP_Paciente_Read (@Doc_Paciente varchar(50))
as
begin
  Select * from Paciente where Doc_Paciente=@Doc_Paciente
  Select Scope_identity()
end


---UPDATE
go
alter Procedure SP_Paciente_Update
(@Doc_Paciente varchar(50), @Tipo_documento varchar(30))
as
begin
	update Paciente set  Tipo_documento=@Tipo_documento
	where Doc_Paciente=@Doc_Paciente
	Select Scope_identity()
end

---DELETE
go
alter Procedure SP_Paciente_Delete (@Doc_Paciente varchar(50))
as
begin
	Delete from Paciente where Doc_Paciente=@Doc_Paciente
	Select Scope_identity()
end

--tabla Historial clinico

--INDEX
go
alter Procedure SP_Historial_Clinico_Index
as
begin
  Select * from Historial_Clinico
  Select Scope_identity()
end
---alter
go
alter Procedure SP_Historial_Clinico_Create
(@Doc_Paciente varchar(50), @Orden int)
as
begin
	insert into Historial_Clinico values (@Doc_Paciente, @Orden)
	Select Scope_identity()
end

---READ
go
alter Procedure SP_Historial_Clinico_Read (@Doc_Paciente varchar(50))
as
begin
  Select * from Historial_Clinico where Doc_Paciente=@Doc_Paciente
end
Select Scope_identity()

---UPDATE
go
alter Procedure SP_Historial_Clinico_Update
(@Doc_Paciente varchar(50), @Orden int)
as
begin
	update Historial_Clinico set  Orden=@Orden
	where Doc_Paciente=@Doc_Paciente
	Select Scope_identity()
end

---DELETE
go
alter Procedure SP_Historial_Clinico_Delete_p(@Doc_Paciente varchar(50))
as
begin
	Delete from Historial_Clinico where Doc_Paciente=@Doc_Paciente
	Select Scope_identity()
end

go
alter Procedure SP_Historial_Clinico_Delete_o (@Orden int)
as
begin
	Delete from Historial_Clinico where Orden=@Orden
	Select Scope_identity()
end

-- PROCEDIMIENTOS ALMACENADOS DE PERSONA.
-- INDEX
go
create procedure SP_Persona_Index
as
begin
select * from Persona
Select Scope_identity()
end

--- alter 

create PROCEDURE SP_Persona_Create
(
    @ID_Persona varchar(50), 
	@Documento varchar(20),
    @Nombre VARCHAR(50),
	@Fecha_Nacimiento DATE,
	@Telefono VARCHAR(15),
	@Correo VARCHAR(50), 
    @Contraseña VARCHAR(20), 
    @Foto VARCHAR(255),
	@Tipo_Sangre VARCHAR(10)
)
as
begin
insert into Persona values (@ID_Persona, @Documento, @Nombre, @Fecha_Nacimiento, @Telefono,
@Correo, @Contraseña, @Foto, @Tipo_Sangre)
Select Scope_identity()
end

--- READ 

create PROCEDURE Sp_Persona_Read
(@ID_Persona varchar(50))
As 
begin
Select * From Persona where ID_Persona=@ID_Persona
Select Scope_identity()
end

--- UPDATE

create procedure SP_Persona_Update
(   @ID_Persona varchar(50), 
	@Documento varchar, 
	@Nombre VARCHAR(50), 
	@Fecha_Nacimiento DATE,
	@Telefono VARCHAR(15),
	@Correo VARCHAR(50), 
	@Contraseña VARCHAR(20), 
	@Foto VARCHAR(255),
	@Tipo_Sangre VARCHAR(10)
)
as 
begin
update Persona set Documento=@Documento, Nombre=@Nombre, Fecha_Nacimiento=@Fecha_Nacimiento,
Telefono=@Telefono, Correo=@Correo, Contraseña=@Contraseña, Foto=@Foto where ID_Persona=@ID_Persona
Select Scope_identity()
end

--- DELETE

create procedure SP_Persona_Delete
(@ID_Persona varchar(50))
as 
begin 
delete from Persona where ID_Persona=@ID_Persona
Select Scope_identity()
end 

-- PROCEDIMIENTOS ALMACENADOS DE ADMINISTRADOR

go
alter procedure SP_Administrador_Index
as
begin
select * from Administrador
Select Scope_identity()
end
--- alter 
	
alter Procedure SP_Administrador_Create
(
	@ID_Persona varchar(50),
    @Clave VARCHAR(50)
)
as
begin
insert into Administrador values (@ID_Persona, @Clave)
Select Scope_identity()
end

--- READ

alter Procedure Sp_Administrador_Read
(
@ID_Persona varchar(50)
)
as
begin
select * from Administrador where ID_Persona=@ID_Persona
Select Scope_identity()
end
--- UPDATE
alter PROCEDURE SP_Administrador_Update
(  	
	@ID_Persona varchar(50),
	@Clave VARCHAR(50)
)
as
begin
    update Administrador set Clave=@Clave where ID_Persona=@ID_Persona;
	Select Scope_identity()
end
--- DELETE	

alter procedure SP_Administrador_Delete
(  	
	@ID_Persona varchar(50)
)
as 
begin
delete from Administrador where ID_Persona=@ID_Persona;
Select Scope_identity()
end
-- PROCEDIMIENTOS ALMACENADOS DE PROFESIONAL.

go
go
create procedure SP_Profesional_Index
as
begin
select * from Profesional
Select Scope_identity()
end
--- alter 
	
create Procedure SP_Profesional_Create
(
	@Doc_Pro varchar(50),
    @Horario VARCHAR(50)
)
as
begin
insert into Profesional values (@Doc_Pro, @Horario)

Select Scope_identity()
end

--- READ

create Procedure Sp_Profesional_Read
(
@Doc_Pro varchar(50)
)
as
begin
select * from Profesional where Doc_Pro=@Doc_Pro
Select Scope_identity()
end

--- UPDATE
create PROCEDURE SP_Profesional_Update
(  	
	@Doc_Pro varchar(50),
	@Horario VARCHAR(50)
)
as
begin
    update Profesional set Horario=@Horario where Doc_Pro=@Doc_Pro;
	Select Scope_identity()
end

--- DELETE	

create procedure SP_Profesional_Delete
(  	
	@Doc_Pro varchar(50)
)
as 
begin
delete from Profesional where Doc_Pro=@Doc_Pro;
Select Scope_identity()
end

--tabla Procedimiento

--INDEX
go
alter Procedure SP_Procedimiento_Index
as
begin
  Select * from Procedimiento
  Select Scope_identity()
end
---alter
go
alter Procedure SP_Procedimiento_Create
( @Tipo_P VARCHAR(50), @Fecha_P date,
@Hora_P time, @Estado_P VARCHAR(50), @Pro_Asignado Varchar(50) )
as
begin
	insert into Procedimiento values ( @Tipo_P, @Fecha_P,
	@Hora_P, @Estado_P, @Pro_Asignado )
	Select Scope_identity()
end

---READ
go
alter Procedure SP_Procedimiento_Read (@Cod_Procedimiento int)
as
begin
  Select * from Procedimiento where Cod_Procedimiento=@Cod_Procedimiento
  Select Scope_identity()
end

---UPDATE
go
alter Procedure SP_Procedimiento_Update
(@Cod_Procedimiento int, @Tipo_P VARCHAR(50), @Fecha_P date,
@Hora_P time, @Estado_P VARCHAR(50), @Pro_Asignado Varchar(50) )
as
begin
	update Procedimiento set  Tipo_P=@Tipo_P, Fecha_P=@Fecha_P,
	Hora_P=@Hora_P, Estado_P=@Estado_P, Pro_Asignado=@Pro_Asignado
	where Cod_Procedimiento=@Cod_Procedimiento
	Select Scope_identity()
end

---DELETE
go
alter Procedure SP_Procedimiento_Delete (@Cod_Procedimiento varchar(50))
as
begin
	Delete from Procedimiento where Cod_Procedimiento=@Cod_Procedimiento
	Select Scope_identity()
end

--tabla Nomina

--INDEX
go
alter Procedure SP_Nomina_Index
as
begin
  Select * from Nomina
  Select Scope_identity()
end
---alter
go
alter Procedure SP_Nomina_Create
(@ID_Nomina VARCHAR(50), @Doc_Pro VARCHAR(50), @Salario DECIMAL(10, 2),
@Fecha_Pago DATE, @Estado varchar(40))
as
begin
	insert into Nomina values (@ID_Nomina, @Doc_Pro, @Salario,
	@Fecha_Pago, @Estado)
	Select Scope_identity()
end

---READ
go
alter Procedure SP_Nomina_Read (@ID_Nomina VARCHAR(50))
as
begin
  Select * from Nomina where ID_Nomina=@ID_Nomina
  Select Scope_identity()
end

---UPDATE
go
alter Procedure SP_Nomina_Update
(@ID_Nomina VARCHAR(50), @Doc_Pro VARCHAR(50), @Salario DECIMAL(10, 2),
@Fecha_Pago DATE, @Estado varchar(40))
as
begin
	update Nomina set  Doc_Pro=@Doc_Pro, Salario=@Salario,
	Fecha_Pago=@Fecha_Pago, Estado=@Estado
	where ID_Nomina=@ID_Nomina
end
---Retorna el identificador de la tabla
Select Scope_identity()

---DELETE
go
alter Procedure SP_Nomina_Delete (@ID_Nomina VARCHAR(50))
as
begin
	Delete from Nomina where ID_Nomina=@ID_Nomina
	Select Scope_identity()
end

-- PROCEDIMIENTOS ALMACENADOS DE HORARIO.

go
alter procedure SP_Horario_Index
as
begin
select * from Horario
Select Scope_identity()
end

--- alter 
	
alter PROCEDURE SP_Horario_Create
(
	@ID_Horario varchar(50),
	@Hora_Entrada time,
	@Hora_Salida time,
	@Especialidad varchar(80)
)
AS
BEGIN
    INSERT INTO Horario VALUES (@ID_Horario, @Hora_Entrada, @Hora_Salida, @Especialidad);
	Select Scope_identity()
END


--- READ

alter Procedure Sp_Horario_Read
(
	@ID_Horario VARCHAR(50)
)
as
begin
select * from Horario where ID_Horario=@ID_Horario
Select Scope_identity()
end

--- UPDATE

alter PROCEDURE SP_Horario_Update
(  	
	@ID_Horario varchar(50),
	@Hora_Entrada time,
	@Hora_Salida time,
	@Especialidad varchar(80)
)
as
begin
    update Horario set Hora_Entrada=@Hora_Entrada, Hora_Salida=@Hora_Entrada, Especialidad=@Especialidad where ID_Horario=@ID_Horario
	Select Scope_identity()
end

--- DELETE	

alter PROCEDURE SP_Horario_Delete
(  	
	@ID_Horario varchar(50)
)
AS 
BEGIN
    DELETE FROM Horario WHERE ID_Horario=@ID_Horario
	Select Scope_identity()
END
------------consultas especificas---------------------
create PROCEDURE SP_Buscar_Profesional (@Especialidad varchar(80))
AS
BEGIN
    SELECT p.Nombre,h.Especialidad from Persona p inner join Profesional pr on p.ID_Persona=pr.Doc_Pro inner join 
	Horario h on pr.Horario=h.ID_Horario where h.Especialidad=@Especialidad
	select SCOPE_IDENTITY()
END 

create PROCEDURE SP_Buscar_DocPro (@Nombre varchar(80))
AS
BEGIN
    SELECT pr.* from Persona p inner join Profesional pr on p.ID_Persona=pr.Doc_Pro 
	where p.Nombre=@Nombre
	select SCOPE_IDENTITY()
END

create PROCEDURE SP_Buscar_CitaPa (@Doc_Paciente varchar(50))
AS
BEGIN
    SELECT Persona.Nombre as profesional,c.* from Cita c inner join Paciente p on p.Doc_Paciente=c.Doc_Paciente
	inner join profesional pro on  pro.Doc_Pro=c.Doc_Profesional inner join Persona
	on Persona.ID_Persona=pro.Doc_Pro where p.Doc_Paciente=@Doc_Paciente 
	select SCOPE_IDENTITY()
END

go
create Procedure SP_Cita_Reprogramar
(@Cod_Cita int,
@Fecha_Cita DATE, @Hora_Cita TIME)
as
begin	
	update Cita set  Fecha_Cita=@Fecha_Cita, Hora_Cita=@Hora_Cita
	where	Cod_Cita=@Cod_Cita
	Select Scope_identity()
end

go
create PROCEDURE SP_Buscar_CitaEsp (@Cod_Cita varchar(50))
AS
BEGIN
    SELECT h.* from Cita c inner join profesional p on p.Doc_Pro=c.Doc_Profesional
	inner join Horario h on p.Horario=h.ID_Horario where c.Cod_Cita=@Cod_Cita
	select SCOPE_IDENTITY()
END
