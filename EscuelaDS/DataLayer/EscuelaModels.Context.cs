﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EscuelaDS.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EscuelaDBContext : DbContext
    {
        public EscuelaDBContext()
            : base("name=EscuelaDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AsignacionRolesOpciones> AsignacionRolesOpciones { get; set; }
        public virtual DbSet<Aulas> Aulas { get; set; }
        public virtual DbSet<Calificaciones> Calificaciones { get; set; }
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<Distritos> Distritos { get; set; }
        public virtual DbSet<Docentes> Docentes { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Encargados> Encargados { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Materias> Materias { get; set; }
        public virtual DbSet<Matriculas> Matriculas { get; set; }
        public virtual DbSet<Municipios> Municipios { get; set; }
        public virtual DbSet<Opciones> Opciones { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Turnos> Turnos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
