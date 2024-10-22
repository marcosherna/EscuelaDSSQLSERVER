USE [master]
GO
/****** Object:  Database [escuela_ds2]    Script Date: 25/5/2024 10:30:12 ******/
CREATE DATABASE [escuela_ds2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'escuela_ds2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\escuela_ds2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'escuela_ds2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\escuela_ds2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [escuela_ds2] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [escuela_ds2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [escuela_ds2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [escuela_ds2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [escuela_ds2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [escuela_ds2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [escuela_ds2] SET ARITHABORT OFF 
GO
ALTER DATABASE [escuela_ds2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [escuela_ds2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [escuela_ds2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [escuela_ds2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [escuela_ds2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [escuela_ds2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [escuela_ds2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [escuela_ds2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [escuela_ds2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [escuela_ds2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [escuela_ds2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [escuela_ds2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [escuela_ds2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [escuela_ds2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [escuela_ds2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [escuela_ds2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [escuela_ds2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [escuela_ds2] SET RECOVERY FULL 
GO
ALTER DATABASE [escuela_ds2] SET  MULTI_USER 
GO
ALTER DATABASE [escuela_ds2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [escuela_ds2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [escuela_ds2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [escuela_ds2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [escuela_ds2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [escuela_ds2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'escuela_ds2', N'ON'
GO
ALTER DATABASE [escuela_ds2] SET QUERY_STORE = ON
GO
ALTER DATABASE [escuela_ds2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [escuela_ds2]
GO
/****** Object:  Table [dbo].[AsignacionRolesOpciones]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignacionRolesOpciones](
	[ID_AsignacionRol] [int] IDENTITY(1,1) NOT NULL,
	[ID_Rol] [int] NOT NULL,
	[ID_Opcion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_AsignacionRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aulas]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aulas](
	[ID_Aula] [int] IDENTITY(1,1) NOT NULL,
	[Edificio] [varchar](20) NULL,
	[Piso] [varchar](10) NULL,
	[NumeroAula] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Aula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificaciones](
	[ID_Calificacion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Materia] [int] NOT NULL,
	[NIE] [int] NOT NULL,
	[ID_Docente] [int] NOT NULL,
	[Examen1] [decimal](3, 1) NULL,
	[Examen2] [decimal](3, 1) NULL,
	[Examen3] [decimal](3, 1) NULL,
	[ExamenFinal] [decimal](3, 1) NULL,
	[Tareas] [decimal](3, 1) NULL,
	[Promedio] [decimal](3, 1) NULL,
	[Estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Calificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cargos]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargos](
	[ID_Cargo] [int] IDENTITY(1,1) NOT NULL,
	[Cargo] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Cargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamentos](
	[ID_Departamento] [int] IDENTITY(1,1) NOT NULL,
	[Departamento] [varchar](60) NOT NULL,
	[ID_Pais] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direcciones]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direcciones](
	[ID_Direccion] [int] IDENTITY(1,1) NOT NULL,
	[Linea1] [varchar](100) NOT NULL,
	[Linea2] [varchar](100) NULL,
	[ID_Distrito] [int] NOT NULL,
	[CodigoPostal] [char](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Direccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distritos]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distritos](
	[ID_Distrito] [int] IDENTITY(1,1) NOT NULL,
	[Distrito] [varchar](60) NOT NULL,
	[ID_Municipio] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Distrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Docentes]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docentes](
	[ID_Docente] [int] IDENTITY(1,1) NOT NULL,
	[ID_Empleado] [int] NOT NULL,
	[ID_Especialidad] [int] NOT NULL,
	[Escalafon] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Docente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[ID_Empleado] [int] IDENTITY(1,1) NOT NULL,
	[DUI_Empleado] [varchar](10) NOT NULL,
	[ISSS_Empleado] [varchar](15) NOT NULL,
	[NombresEmpleado] [varchar](60) NOT NULL,
	[ApellidosEmpleado] [varchar](60) NOT NULL,
	[FechaNacEmpleado] [date] NOT NULL,
	[TelefonoEmpleado] [varchar](10) NOT NULL,
	[Correo] [varchar](100) NULL,
	[ID_Cargo] [int] NOT NULL,
	[ID_Direccion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encargados]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encargados](
	[ID_Encargado] [int] IDENTITY(1,1) NOT NULL,
	[NombresEncargado] [varchar](60) NOT NULL,
	[ApellidosEncargado] [varchar](60) NOT NULL,
	[TelefonoEncargado] [varchar](10) NULL,
	[DUI_Encargado] [varchar](10) NOT NULL,
	[ID_Direccion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Encargado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especialidades]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidades](
	[ID_Especialidad] [int] IDENTITY(1,1) NOT NULL,
	[NombreEspecialidad] [varchar](100) NOT NULL,
	[Carrera] [varchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Especialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiantes]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiantes](
	[NIE] [int] NOT NULL,
	[NombresEstudiante] [varchar](60) NOT NULL,
	[ApellidosEstudiante] [varchar](60) NOT NULL,
	[FechaNacEstudiante] [date] NOT NULL,
	[GeneroEstudiante] [char](1) NULL,
	[TelefonoEstudiante] [varchar](10) NULL,
	[ID_Encargado] [int] NOT NULL,
	[ID_Direccion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NIE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grupos]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupos](
	[ID_Grupo] [int] IDENTITY(1,1) NOT NULL,
	[Grado] [varchar](30) NOT NULL,
	[Seccion] [varchar](10) NOT NULL,
	[Anio] [int] NOT NULL,
	[ID_Turno] [int] NOT NULL,
	[ID_Aula] [int] NOT NULL,
	[ID_Docente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Grupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materias]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materias](
	[ID_Materia] [int] IDENTITY(1,1) NOT NULL,
	[NombreMateria] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matriculas]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matriculas](
	[ID_Matricula] [int] IDENTITY(1,1) NOT NULL,
	[NIE] [int] NOT NULL,
	[ID_Grupo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Municipios]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Municipios](
	[ID_Municipio] [int] IDENTITY(1,1) NOT NULL,
	[Municipio] [varchar](60) NOT NULL,
	[ID_Departamento] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Municipio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Opciones]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Opciones](
	[ID_Opcion] [int] IDENTITY(1,1) NOT NULL,
	[NombreOpcion] [varchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Opcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paises](
	[ID_Pais] [int] IDENTITY(1,1) NOT NULL,
	[Pais] [varchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID_Rol] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [varchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turnos]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turnos](
	[ID_Turno] [int] IDENTITY(1,1) NOT NULL,
	[Turno] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Turno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 25/5/2024 10:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[ID_Empleado] [int] NOT NULL,
	[ID_Rol] [int] NOT NULL,
	[Usuario] [varchar](60) NOT NULL,
	[Clave] [varchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AsignacionRolesOpciones]  WITH CHECK ADD FOREIGN KEY([ID_Opcion])
REFERENCES [dbo].[Opciones] ([ID_Opcion])
GO
ALTER TABLE [dbo].[AsignacionRolesOpciones]  WITH CHECK ADD FOREIGN KEY([ID_Rol])
REFERENCES [dbo].[Roles] ([ID_Rol])
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD FOREIGN KEY([ID_Docente])
REFERENCES [dbo].[Docentes] ([ID_Docente])
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD FOREIGN KEY([ID_Materia])
REFERENCES [dbo].[Materias] ([ID_Materia])
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD FOREIGN KEY([NIE])
REFERENCES [dbo].[Estudiantes] ([NIE])
GO
ALTER TABLE [dbo].[Departamentos]  WITH CHECK ADD FOREIGN KEY([ID_Pais])
REFERENCES [dbo].[Paises] ([ID_Pais])
GO
ALTER TABLE [dbo].[Direcciones]  WITH CHECK ADD FOREIGN KEY([ID_Distrito])
REFERENCES [dbo].[Distritos] ([ID_Distrito])
GO
ALTER TABLE [dbo].[Distritos]  WITH CHECK ADD FOREIGN KEY([ID_Municipio])
REFERENCES [dbo].[Municipios] ([ID_Municipio])
GO
ALTER TABLE [dbo].[Docentes]  WITH CHECK ADD FOREIGN KEY([ID_Empleado])
REFERENCES [dbo].[Empleados] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Docentes]  WITH CHECK ADD FOREIGN KEY([ID_Especialidad])
REFERENCES [dbo].[Especialidades] ([ID_Especialidad])
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD FOREIGN KEY([ID_Cargo])
REFERENCES [dbo].[Cargos] ([ID_Cargo])
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD FOREIGN KEY([ID_Direccion])
REFERENCES [dbo].[Direcciones] ([ID_Direccion])
GO
ALTER TABLE [dbo].[Encargados]  WITH CHECK ADD FOREIGN KEY([ID_Direccion])
REFERENCES [dbo].[Direcciones] ([ID_Direccion])
GO
ALTER TABLE [dbo].[Estudiantes]  WITH CHECK ADD FOREIGN KEY([ID_Direccion])
REFERENCES [dbo].[Direcciones] ([ID_Direccion])
GO
ALTER TABLE [dbo].[Estudiantes]  WITH CHECK ADD FOREIGN KEY([ID_Encargado])
REFERENCES [dbo].[Encargados] ([ID_Encargado])
GO
ALTER TABLE [dbo].[Grupos]  WITH CHECK ADD FOREIGN KEY([ID_Aula])
REFERENCES [dbo].[Aulas] ([ID_Aula])
GO
ALTER TABLE [dbo].[Grupos]  WITH CHECK ADD FOREIGN KEY([ID_Docente])
REFERENCES [dbo].[Docentes] ([ID_Docente])
GO
ALTER TABLE [dbo].[Grupos]  WITH CHECK ADD FOREIGN KEY([ID_Turno])
REFERENCES [dbo].[Turnos] ([ID_Turno])
GO
ALTER TABLE [dbo].[Matriculas]  WITH CHECK ADD FOREIGN KEY([ID_Grupo])
REFERENCES [dbo].[Grupos] ([ID_Grupo])
GO
ALTER TABLE [dbo].[Matriculas]  WITH CHECK ADD FOREIGN KEY([NIE])
REFERENCES [dbo].[Estudiantes] ([NIE])
GO
ALTER TABLE [dbo].[Municipios]  WITH CHECK ADD FOREIGN KEY([ID_Departamento])
REFERENCES [dbo].[Departamentos] ([ID_Departamento])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([ID_Empleado])
REFERENCES [dbo].[Empleados] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([ID_Rol])
REFERENCES [dbo].[Roles] ([ID_Rol])
GO
USE [master]
GO
ALTER DATABASE [escuela_ds2] SET  READ_WRITE 
GO
