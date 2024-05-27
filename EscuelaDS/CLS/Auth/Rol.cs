using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaDS.CLS.Auth
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Opcion> Opcions = new List<Opcion>();

        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Nombre))
            {
                throw new Exception("El nombre del rol es requerido");
            }
        }

        public async Task OpcionEstaAsignada(Opcion opcion) {
            using (var context = new EscuelaDBContext())
            {
                var asignacion = await context.AsignacionRolesOpciones
                    .Where(x => x.ID_Rol == this.Id && x.ID_Opcion == opcion.Id)
                    .FirstOrDefaultAsync();
                if (asignacion != null) throw new Exception("La opción ya está asignada al rol");
            }
        }

        public async Task<bool> AsignarOpcionAsync(Opcion opcion)
        {
            bool result = false; 

            using (var context = new EscuelaDBContext())
            {
                var asignacion = new AsignacionRolesOpciones
                {
                    ID_Rol = this.Id,
                    ID_Opcion = opcion.Id
                };
                context.AsignacionRolesOpciones.Add(asignacion);
                int row = await context.SaveChangesAsync();
                result = row > 0;
            }
            return result;
        }

        public async Task<bool> EliminarOpcionAsignada(Opcion opcion)
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            { 
                var asignacion = context.AsignacionRolesOpciones
                    .Where(x => x.ID_Rol == this.Id && x.ID_Opcion == opcion.Id)
                    .FirstOrDefault();

                if (asignacion != null)
                {
                    context.AsignacionRolesOpciones.Attach(asignacion);
                    context.AsignacionRolesOpciones.Remove(asignacion);
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                }
            }
            return result;
        }

        public async static Task<List<Rol>> GetWithOpcionesAsync()
        {
            List<Rol> roles = new List<Rol>();
            using (var context = new EscuelaDBContext())
            {
                roles = await context.Roles.Select(rol => new Rol {
                    Id = rol.ID_Rol,
                    Nombre = rol.NombreRol,
                    Opcions = rol.AsignacionRolesOpciones.Select(opcion => new Opcion
                    {
                        Id = opcion.ID_Opcion,
                        Nombre = opcion.Opciones.NombreOpcion,
                    }).ToList()
                }).ToListAsync();
            }
            return roles;
        }
        public async static Task<List<Rol>> GetAsync()
        {
            List<Rol> roles = new List<Rol>();
            using (var context = new EscuelaDBContext())
            {
                roles = await context.Roles.Select(x => new Rol
                {
                    Id = x.ID_Rol,
                    Nombre = x.NombreRol
                }).ToListAsync();
            }
            return roles;
        }

        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                 var rol = new Roles
                 {
                     NombreRol = this.Nombre
                 };
                context.Roles.Add(rol);
                int row = await context.SaveChangesAsync();
                result = row > 0;
            }
            return result;
        }

        public async Task<bool> UpdateAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var rol = context.Roles.Where(x => x.ID_Rol == this.Id).FirstOrDefault();
                if (rol != null)
                {
                    rol.NombreRol = this.Nombre;
                    context.Roles.Attach(rol);
                    context.Entry(rol).State = EntityState.Modified;
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                }
            }
            return result;
        }

        public async Task<bool> DeleteAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var rol = context.Roles.Where(x => x.ID_Rol == this.Id).FirstOrDefault();
                if (rol != null)
                {
                    context.Roles.Attach(rol);
                    context.Roles.Remove(rol);
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                }
            }
            return result;
        }
    }
}
