using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Auth
{
    public class Usuario
    {
        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        public int IdRol { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var usuario = new Usuarios
                {
                    ID_Empleado = this.IdEmpleado,
                    ID_Rol = this.IdRol,
                    Usuario = this.UserName,
                    Clave = this.Password
                };
                context.Usuarios.Add(usuario);
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
                var usuario = context.Usuarios.Find(this.Id);
                if (usuario != null)
                {
                    usuario.ID_Empleado = this.IdEmpleado;
                    usuario.ID_Rol = this.IdRol;
                    usuario.Usuario = this.UserName;
                    usuario.Clave = this.Password;
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
                var usuario = context.Usuarios.Find(this.Id);
                if (usuario != null)
                {
                    context.Usuarios.Remove(usuario);
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                }
            }
            return result;
        }


    }
}
