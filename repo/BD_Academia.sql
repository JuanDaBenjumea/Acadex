--CREAR BASE DE DATOS
Create Database BD_Academia
use BD_Academia


---TABLAS
--Tabla de Facultades
create table Facultades(
IdFacultad nvarchar(50) primary key,
NombreFacultad nvarchar(50)
);

--Tabla de Programas
create table Programas(
IdPrograma nvarchar(50) primary key,
NombrePrograma nvarchar(50),
Facultad nvarchar(50)
constraint FK_Facultad_Programas foreign key (Facultad)
references Facultades(IdFacultad)
);

---Tabla de Estudiantes
create table Estudiantes(
IdEstudiante nvarchar(50) primary key,
NombreEstudiante nvarchar(50),
ApellidoEstudiante nvarchar(50),
Programa nvarchar(50),
Telefono nvarchar(50),
Beca nvarchar(10),
FechaRegistro date not null,
constraint FK_Estudiantes_Programas foreign key (Programa)
references Programas(IdPrograma));


---Tabla de Docentes
create table Docentes(
IdDocente nvarchar(50) primary key,
NombreDocente nvarchar(50),
ApellidoDocente nvarchar(50),
Telefono nvarchar(50),
Facultad nvarchar(50),
Salario int,
FechaRegistro date not null,
CONSTRAINT FK_Facultad_Docentes FOREIGN KEY(Facultad)
REFERENCES Facultades(IdFacultad));


---Tabla de Administradores
create table Administradores(
IdAdmin nvarchar(50) primary key,
NombreAdmin nvarchar(50),
ApellidoAdmin nvarchar(50),
Usuario nvarchar(50),
Contra nvarchar(50),
FechaRegistro date not null);


---Tabla de Nominas
create table Nominas(
IdNomina int identity(1,1) primary key,
Nombre nvarchar(50),
Apellido nvarchar(50),
Facultad nvarchar(50),
SalarioContrato int,
HoraExtra int,
PagoXhoraExtra int,
TotalHoraExtra int,
SalarioNeto int,
FechaRegistro date not null);



---Tabla de Cursos
CREATE TABLE Cursos(
    IdCurso int identity (1,1) PRIMARY KEY,
    NombreCurso NVARCHAR(50),
    CantCreditos INT,
    NumEstudiantes INT,
    IdDocente NVARCHAR(50), 
    Facultad NVARCHAR(50),
    FechaRegistro DATE NOT NULL,
    CONSTRAINT FK_Cursos_Docentes FOREIGN KEY (IdDocente) 
        REFERENCES Docentes(IdDocente),
	constraint FK_Cursos_Facultad foreign key (Facultad)
	references Facultades(IdFacultad)
);



---Tabla de Matricula de curso
create table Matriculas(
IdMatricula nvarchar(50) primary key,
IdCurso int,
IdEstudiante nvarchar(50),
constraint FK_Curso foreign key (IdCurso)
references Cursos(IdCurso),
constraint FK_Estudiantes foreign key (IdEstudiante)
references Estudiantes(IdEstudiante)
);



---Tabla de Notas
create table Notas(
IdReporte nvarchar(50) primary key,
IdCurso int,
IdEstudiante nvarchar(50),
Definitiva float, 
constraint FK_Curso_Notas foreign key (IdCurso)
references Cursos(IdCurso),
constraint FK_Estudiantes_Notas foreign key (IdEstudiante)
references Estudiantes(IdEstudiante)
);



---Tabla de Asistencia
create table Asistencia(
IdAsistencia int identity (1,1) primary key,
IdCurso int,
IdEstudiante nvarchar(50),
Asistencia int,
FechaRegistro Date not null,
constraint FK_Estudiantes_Asistencia foreign key (IdEstudiante)
references Estudiantes(IdEstudiante),
constraint FK_Asistencia_Curso foreign key(IdCurso)
references Cursos(IdCurso)
);


---Insertar Super Administrador para el logueo
insert into Administradores values('1','Juan','Benjumea', 'Admin', 'Admin', '09/25/2024');

---Insertar Facultades
insert into Facultades values('1', 'Ingenieria');
insert into Facultades values('2', 'Medicina');
insert into Facultades values('3', 'Letras');
insert into Facultades values('4', 'Artes');

---Insertar Programas
insert into Programas values('1','Ingenieria de software','1');
insert into Programas values('2','Medicina Pediatra','2');
insert into Programas values('3','Filosofia','3');
insert into Programas values('4','Teatro','4');

---Insertar Docente para pruebas de logueo
insert into Docentes values('12345678','Luis','Posada','123456','1','3500000','09/28/2024');
insert into Docentes values('98765432','Alberto','Rincon','123456','2','5000000','09/28/2024');

---Insertar Estudiante para pruebas de logueo
insert into Estudiantes values('12345678','Simon','Gallego','1','123456','Si','09/28/2024');
insert into Estudiantes values('09382193','Alejandra','Munera','2','123456','No','09/29/2024');

---Insertar Curso para pruebas
insert into Cursos values('Herramientas de programacion', '4', '30', '12345678', '1', '09/29/2024');



----------------------------------
---PROCEDIMIENTOS ADMINISTRADORES
----------------------------------

---Procedimiento Index Administrador
go
create procedure SP_Index_Admin
as
begin 
select * from Administradores
end

---Procedimiento Crear Admin
go
CREATE PROCEDURE SP_Admin_Create
(
    @IdAdmin NVARCHAR(50), 
    @NombreAdmin NVARCHAR(50), 
    @ApellidoAdmin NVARCHAR(50), 
    @Usuario NVARCHAR(50), 
    @Contra NVARCHAR(50), 
    @FechaRegistro DATE
)
AS
BEGIN
    INSERT INTO Administradores (IdAdmin, NombreAdmin, ApellidoAdmin, Usuario, Contra, FechaRegistro)
    VALUES (@IdAdmin, @NombreAdmin, @ApellidoAdmin, @Usuario, @Contra, @FechaRegistro)

    -- Devuelve el ID insertado
    SELECT Scope_identity() AS IdAdmin
END


---Procedimiento Eliminar Admin
go 
create procedure SP_Admin_Delete
(@IdAdmin nvarchar(50))
as
begin
delete from Administradores where IdAdmin = @IdAdmin
end
select SCOPE_IDENTITY();



---Procedimiento para saber si el usuario ya existe
go
create procedure SP_Usuario_Existente
(@Usuario nvarchar(50))
as
begin
print('Existe')
  IF EXISTS (
        SELECT 1
        FROM Administradores
        WHERE Usuario = @Usuario)
    BEGIN
        SELECT 'Si' AS Existe;
        RETURN;
    END
	print('No Existe')
	SELECT 'No' As Existe;
	RETURN;
end

---Procedimiento que valida si ya existe el id del admin ingresado
go
CREATE PROCEDURE SP_CheckIdAdminExists
    @IdAdmin NVARCHAR(50)
AS
BEGIN
    SELECT COUNT(*) 
    FROM Administradores 
    WHERE IdAdmin = @IdAdmin;
END

----------------------------------
---PROCEDIMIENTOS DOCENTES
----------------------------------
---Procedimiento Index Docentes
go
create procedure SP_Index_Docentes
as
begin 
select * from Docentes
end

---Procedimiento Crear Docente
go
create procedure SP_Docente_Create
(@IdDocente nvarchar(50),@NombreDocente nvarchar(50), @ApellidoDocente nvarchar(50), @Telefono nvarchar(50), @Facultad nvarchar(50), @Salario int, @FechaRegistro date)
as
begin
insert into Docentes values (@IdDocente ,@NombreDocente , @ApellidoDocente, @Telefono , @Facultad, @Salario , @FechaRegistro)
end
select Scope_identity()

---Procedimiento Eliminar Docente
go 
create procedure SP_Docente_Delete
(@IdDocente nvarchar(50))
as
begin
delete from Docentes where IdDocente = @IdDocente
end
select SCOPE_IDENTITY();

---Procedimiento Buscar Docentes por facultad
go 
create procedure SP_Docente_Filter
(@Facultad nvarchar(50))
as
begin
select * from Docentes where Facultad = @Facultad
end
select SCOPE_IDENTITY();

---Procedimiento para validar ID de docente
go
CREATE PROCEDURE SP_CheckIdDocenteExists
    @IdDocente NVARCHAR(50)
AS
BEGIN
    SELECT COUNT(*) 
    FROM Docentes 
    WHERE IdDocente = @IdDocente;
END



----------------------------------
---PROCEDIMIENTOS ESTUDIANTES
----------------------------------
---Procedimiento Index Estudiantes
go
create procedure SP_Index_Estudiantes
as
begin 
select * from Estudiantes
end

---Procedimiento Crear Estudiante
go
create procedure SP_Estudiante_Create
(@IdEstudiante nvarchar(50),@NombreEstudiante nvarchar(50), @ApellidoEstudiante nvarchar(50), @Programa nvarchar(50), @Telefono nvarchar(50), @Beca nvarchar(50), @FechaRegistro date)
as
begin
insert into Estudiantes values (@IdEstudiante ,@NombreEstudiante , @ApellidoEstudiante, @Programa, @Telefono , @Beca , @FechaRegistro)
end
select Scope_identity()

---Procedimiento Eliminar Estudiante
go 
create procedure SP_Estudiante_Delete
(@IdEstudiante nvarchar(50))
as
begin
delete from Estudiantes where IdEstudiante = @IdEstudiante
end
select SCOPE_IDENTITY();

---Procedimiento Buscar Estudiantes por programa
go 
create procedure SP_Estudiante_Filter
(@Programa nvarchar(50))
as
begin
select * from Estudiantes where Programa = @Programa
end
select SCOPE_IDENTITY();

---Procedimiento para validar ID de estudiante
go
CREATE PROCEDURE SP_CheckIdEstudianteExists
    @IdEstudiante NVARCHAR(50)
AS
BEGIN
    SELECT COUNT(*) 
    FROM Estudiantes
    WHERE IdEstudiante = @IdEstudiante;
END



----------------------------------
---PROCEDIMIENTOS NOMINAS
----------------------------------
---Procedimiento Index Nominas
go
create procedure SP_Index_Nominas
as
begin 
select * from Nominas
end

---Procedimiento Crear Nomina
go
create procedure SP_Nomina_Create
(@Nombre nvarchar(50), @Apellido nvarchar(50), @Facultad nvarchar(50), @SalarioContrato int, @HoraExtra int, @PagoXHoraExtra int, @TotalHoraExtra int, @SalarioNeto int ,@FechaRegistro date)
as
begin
insert into Nominas values (@Nombre , @Apellido, @Facultad, @SalarioContrato , @HoraExtra ,@PagoXHoraExtra , @TotalHoraExtra, @SalarioNeto, @FechaRegistro)
   SELECT Nombre, Apellido, Facultad, SalarioContrato, HoraExtra, PagoXhoraExtra,TotalHoraExtra, SalarioNeto ,FechaRegistro
    FROM Nominas
    WHERE IdNomina = SCOPE_IDENTITY();
end


---Procedimiento Eliminar Nomina
GO
CREATE PROCEDURE SP_Nomina_Delete
    @IdNomina INT
AS
BEGIN
    DELETE FROM Nominas WHERE IdNomina = @IdNomina;
END;
select SCOPE_IDENTITY();
drop procedure SP_Nomina_Delete


---Procedimiento Buscar Nominas por ID
go 
create procedure SP_Nomina_Filter
(@IdNomina int)
as
begin
select * from Nominas where IdNomina = @IdNomina
end
select SCOPE_IDENTITY();


---Procedimiento traer datos del docente (nombre, apellido, salario)
go
CREATE PROCEDURE [dbo].[SP_DatosDocenteById]
    @IdDocente nvarchar(50)
AS
BEGIN
    SELECT NombreDocente, ApellidoDocente, Facultad, Salario
    FROM Docentes
    WHERE IdDocente = @IdDocente;
END


----------------------------------
---PROCEDIMIENTOS CURSOS
----------------------------------
---Procedimiento index cursos
go
create procedure SP_Index_Cursos
as
begin 
select * from Cursos
end

---Procedimiento Crear Curso
go
CREATE PROCEDURE [dbo].[SP_Curso_Create]
    @NombreCurso NVARCHAR(50),
    @CantCreditos INT,
    @NumEstudiantes INT,
    @IdDocente NVARCHAR(50),
    @Facultad NVARCHAR(50),
    @FechaRegistro DATETIME
AS
BEGIN
    -- Realizar el INSERT
    INSERT INTO Cursos (NombreCurso, CantCreditos, NumEstudiantes, IdDocente, Facultad, FechaRegistro)
    VALUES (@NombreCurso, @CantCreditos, @NumEstudiantes, @IdDocente, @Facultad, @FechaRegistro);

    -- Retornar los datos insertados
    SELECT NombreCurso, CantCreditos, NumEstudiantes, IdDocente, Facultad, FechaRegistro
    FROM Cursos
    WHERE IdCurso = SCOPE_IDENTITY();  -- Asumiendo que IdCurso es autoincremental
END



---Procedimiento Eliminar Curso
go 
create procedure SP_Curso_Delete
(@IdCurso int)
as
begin
delete from Cursos where IdCurso = @IdCurso
end
select SCOPE_IDENTITY();


---Procedimiento para obtener datos del docente (nombre, apellido, facultad)
go
CREATE PROCEDURE [dbo].[SP_GetDocenteById]
    @IdDocente nvarchar(50)
AS
BEGIN
    SELECT NombreDocente, ApellidoDocente, Facultad
    FROM Docentes
    WHERE IdDocente = @IdDocente;
END




----------------------------------
---PROCEDIMIENTO DE VALIDACIÓN
----------------------------------
--Procedimiento para validar que tipo de usuario es el que se esta logueando.
--Si es Admin, Docente o Estudiante, y dirigirlo a su Form correspondiente
go
CREATE PROCEDURE SP_Validar_Usuario
    @Usuario NVARCHAR(100),  -- Nombre + Apellido + últimos 3 caracteres del ID
    @Contraseña NVARCHAR(50) -- Contraseña completa (el ID)
AS
BEGIN
    -- Validar primero si es un Administrador
	print('Validando Administrador');
    IF EXISTS (
        SELECT 1
        FROM Administradores
        WHERE Usuario = @Usuario
          AND Contra = @Contraseña)
    BEGIN
        SELECT 'Administrador' AS TipoUsuario;
        RETURN;
    END

    -- Validar si es un Docente
	print('Validando Docente');
    IF EXISTS (
        SELECT 1
        FROM Docentes
        WHERE NombreDocente + ApellidoDocente + SUBSTRING(IdDocente, LEN(IdDocente) - 2, 3) = @Usuario
          AND IdDocente = @Contraseña)
    BEGIN
        SELECT 'Docente' AS TipoUsuario;
        RETURN;
    END

    -- Validar si es un Estudiante
	print('Validando Estudiante');
    IF EXISTS (
        SELECT 1
        FROM Estudiantes
        WHERE NombreEstudiante + ApellidoEstudiante + SUBSTRING(IdEstudiante, LEN(IdEstudiante) - 2, 3) = @Usuario
          AND IdEstudiante = @Contraseña)
    BEGIN
        SELECT 'Estudiante' AS TipoUsuario;
        RETURN;
    END

    -- Si no coincide con ningún tipo de usuario
    SELECT 'Invalido' AS TipoUsuario;
END




