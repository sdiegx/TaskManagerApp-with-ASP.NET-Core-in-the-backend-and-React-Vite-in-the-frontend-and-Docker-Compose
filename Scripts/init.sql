-- CREATE DATABASE ;

-- USE model;
-- GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'DBDevelopmentApp')
BEGIN
    -- Si la base de datos no existe, entonces la creamos
    PRINT 'Creating database: mydatabase';
    CREATE DATABASE DBDevelopmentApp;
END
-- PRINT 'Creating database: mydatabase';
-- USE DBDevelopmentApp;

CREATE TABLE Personas (
    ID_Persona INT PRIMARY KEY,
    Nombre VARCHAR(50),
	Apellido VARCHAR(50),
	Correo VARCHAR(50),
	Rol VARCHAR(50),
    -- Otros campos seg�n tus necesidades
);

INSERT INTO Personas (ID_Persona, Nombre, Apellido, Correo, Rol) VALUES (1, 'Diego', 'Sebastian','zebastian7616@gmail.com','dev');
INSERT INTO Personas (ID_Persona, Nombre, Apellido, Correo, Rol) VALUES (2, 'Jimena', 'Tutillo','jimenat@gmail.com','qa');
INSERT INTO Personas (ID_Persona, Nombre, Apellido, Correo, Rol) VALUES (3, 'Erick', 'Criollo','erickc@gmail.com','dev');
INSERT INTO Personas (ID_Persona, Nombre, Apellido, Correo, Rol) VALUES (4, 'Maggy', 'Art','maggy4@gmail.com','tester');
INSERT INTO Personas (ID_Persona, Nombre, Apellido, Correo, Rol) VALUES (5, 'Naty', 'Morales','naty4@gmail.com','dev');

-- SELECT * FROM Personas;

-- Primero, elimina la tabla existente si es necesario (ten en cuenta que esto eliminar� todos los datos)
--DROP TABLE IF EXISTS Tareas;
--DROP TABLE IF EXISTS Personas;
--DROP TABLE IF EXISTS Proyectos;
--DROP TABLE IF EXISTS PersonasProyecto;
--DROP TABLE IF EXISTS TareasProyecto;


-- Luego, crea la nueva tabla con la modificaci�n en el tipo de dato de Duracion
CREATE TABLE Tareas (
    ID_Tarea INT PRIMARY KEY,
    NombreTarea VARCHAR(50),
    Descripcion VARCHAR(255),
    Estado VARCHAR(50),
    Minutos INT, -- Modificado a INT
	Horas INT,
    ID_Persona INT,
    FOREIGN KEY (ID_Persona) REFERENCES Personas(ID_Persona)
    -- Otros campos seg�n tus necesidades
);


-- Ejemplo 1
INSERT INTO Tareas (ID_Tarea, NombreTarea, Descripcion, Estado, Minutos, Horas, ID_Persona)
VALUES (1, 'Desarrollo de la función de registro', 'Implementar la función de registro de usuarios en la aplicación', 'Pendiente', 1, 0, 1);

-- Ejemplo 2
INSERT INTO Tareas (ID_Tarea, NombreTarea, Descripcion, Estado, Minutos, Horas, ID_Persona)
VALUES (2, 'Pruebas de la interfaz de usuario', 'Realizar pruebas de usabilidad en la interfaz de usuario', 'Pendiente', 1, 0, 2);

-- Ejemplo 3
INSERT INTO Tareas (ID_Tarea, NombreTarea, Descripcion, Estado, Minutos, Horas, ID_Persona)
VALUES (3, 'Optimización de la base de datos', 'Mejorar el rendimiento de consultas en la base de datos', 'Pendiente', 1, 0, 3);

-- Ejemplo 4
INSERT INTO Tareas (ID_Tarea, NombreTarea, Descripcion, Estado, Minutos, Horas, ID_Persona)
VALUES (4, 'Hacer Presentación', 'Preparar slides y ensayar', 'Pendiente', 120, 4, 4);

-- Ejemplo 5
INSERT INTO Tareas (ID_Tarea, NombreTarea, Descripcion, Estado, Minutos, Horas, ID_Persona)
VALUES (5, 'Revisar Código', 'Revisar y corregir errores', 'Pendiente', 60, 2, 5);

-- Ejemplo 6
INSERT INTO Tareas (ID_Tarea, NombreTarea, Descripcion, Estado, Minutos, Horas, ID_Persona)
VALUES (6, 'Actualizar Documentación', 'Actualizar la documentación del proyecto', 'Pendiente', 30, 1, 1);

CREATE TABLE Proyectos (
    ID_Proyecto INT PRIMARY KEY,
	NombreProyecto VARCHAR(50),
	FechaCreacion DATETIME DEFAULT GETDATE(),
    -- Otros campos seg�n tus necesidades
);

-- Insertar un ejemplo de proyecto
INSERT INTO Proyectos (ID_Proyecto, NombreProyecto, FechaCreacion)
VALUES (1, 'Test Project', GETDATE());
INSERT INTO Proyectos (ID_Proyecto, NombreProyecto, FechaCreacion)
VALUES (2, 'Second Project', GETDATE());


CREATE TABLE PersonasProyecto (
    ID_PersonaProyecto INT PRIMARY KEY,
    ID_Persona INT,
    ID_Proyecto INT,
    FOREIGN KEY (ID_Persona) REFERENCES Personas(ID_Persona),
    FOREIGN KEY (ID_Proyecto) REFERENCES Proyectos(ID_Proyecto)
);

-- Insertar un ejemplo de relaci�n entre persona y proyecto
INSERT INTO PersonasProyecto (ID_PersonaProyecto, ID_Persona, ID_Proyecto)
VALUES (1, 1, 1);
INSERT INTO PersonasProyecto (ID_PersonaProyecto, ID_Persona, ID_Proyecto)
VALUES (2, 2, 1);
INSERT INTO PersonasProyecto (ID_PersonaProyecto, ID_Persona, ID_Proyecto)
VALUES (3, 3, 1);
INSERT INTO PersonasProyecto (ID_PersonaProyecto, ID_Persona, ID_Proyecto)
VALUES (4, 4, 2);
INSERT INTO PersonasProyecto (ID_PersonaProyecto, ID_Persona, ID_Proyecto)
VALUES (5, 5, 2);
INSERT INTO PersonasProyecto (ID_PersonaProyecto, ID_Persona, ID_Proyecto)
VALUES (6, 1, 2);

--SELECT * FROM PersonasProyecto;


CREATE TABLE TareasProyecto (
    ID_TareaProyecto INT PRIMARY KEY,
    ID_Tarea INT,
    ID_Proyecto INT,
    FOREIGN KEY (ID_Tarea) REFERENCES Tareas(ID_Tarea),
    FOREIGN KEY (ID_Proyecto) REFERENCES Proyectos(ID_Proyecto)
);

-- Insertar un ejemplo de relaci�n entre tarea y proyecto
INSERT INTO TareasProyecto (ID_TareaProyecto, ID_Tarea, ID_Proyecto)
VALUES (1, 1, 1);
INSERT INTO TareasProyecto (ID_TareaProyecto, ID_Tarea, ID_Proyecto)
VALUES (2, 2, 1);
INSERT INTO TareasProyecto (ID_TareaProyecto, ID_Tarea, ID_Proyecto)
VALUES (3, 3, 1);
INSERT INTO TareasProyecto (ID_TareaProyecto, ID_Tarea, ID_Proyecto)
VALUES (4, 4, 2);
INSERT INTO TareasProyecto (ID_TareaProyecto, ID_Tarea, ID_Proyecto)
VALUES (5, 5, 2);
INSERT INTO TareasProyecto (ID_TareaProyecto, ID_Tarea, ID_Proyecto)
VALUES (6, 6, 2);

--SELECT T.*
--FROM Tareas T
--JOIN TareasProyecto TP ON T.ID_Tarea = TP.ID_Tarea
--WHERE TP.ID_Proyecto = 1;
