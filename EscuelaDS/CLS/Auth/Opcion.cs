using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Auth
{
    public class Opcion
    {
        public int Id { get; set; }
        public string Nombre{ get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Nombre))
            {
                throw new ArgumentException("El nombre de la opción es requerido");
            }
        }
        public async static Task<List<Opcion>> GetAsync()
        {
            List<Opcion> opciones = new List<Opcion>();
            using (var context = new EscuelaDBContext())
            {
                opciones = await context.Opciones
                    .Select(opcion => new Opcion
                    {
                        Id = opcion.ID_Opcion,
                        Nombre = opcion.NombreOpcion
                    }).ToListAsync();
            }
            return opciones;
        }

        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var opcion = new Opciones
                {
                    NombreOpcion = this.Nombre
                };
                context.Opciones.Add(opcion);
                result = await context.SaveChangesAsync() > 0;
            }
            return result;
        }

        public async Task<bool> UpdateAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var opcion = context.Opciones.Find(this.Id);
                if (opcion != null)
                {
                    opcion.NombreOpcion = this.Nombre;
                    context.Entry(opcion).State = EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0;
                }
            }
            return result;
        }

        public async Task<bool> DeleteAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var opcion = context.Opciones.Find(this.Id);
                if (opcion != null)
                {
                    context.Opciones.Remove(opcion);
                    result = await context.SaveChangesAsync() > 0;
                }
            }
            return result;
        }
    }
}
