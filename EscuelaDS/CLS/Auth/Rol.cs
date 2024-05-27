using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaDS.CLS.Auth
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Nombre))
            {
                throw new Exception("El nombre del rol es requerido");
            }
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
