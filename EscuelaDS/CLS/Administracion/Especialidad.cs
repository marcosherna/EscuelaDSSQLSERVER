using EscuelaDS.CLS.Catalogos;
using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Administracion
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Carrera { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Nombre)) throw new Exception("El nombre de la especialidad es requerido");
            if (string.IsNullOrEmpty(this.Carrera)) throw new Exception("La carrera es requerido");
        }

        public static async Task<List<Especialidad>> GetAsync()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            using (var context = new EscuelaDBContext())
            {
                especialidades = await context.Especialidades
                    .Select(especialidad => new Especialidad 
                    {
                        Id = especialidad.ID_Especialidad,
                        Nombre = especialidad.NombreEspecialidad,
                        Carrera = especialidad.Carrera
                    }).ToListAsync();
            }
            return especialidades;
        }

         

        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                context.Especialidades.Add(new Especialidades
                {
                    NombreEspecialidad = this.Nombre,
                    Carrera = this.Carrera
                });
                await context.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async Task<bool> UpdateAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var especialidad = await context.Especialidades
                    .Where(_especialidad => _especialidad.ID_Especialidad == this.Id).FirstOrDefaultAsync();
                if (especialidad != null)
                {
                    especialidad.NombreEspecialidad = this.Nombre;
                    especialidad.Carrera = this.Carrera;

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
                var especialidad = await context.Especialidades
                    .Where(_especialidad => _especialidad.ID_Especialidad == this.Id).FirstOrDefaultAsync();
                if (especialidad != null)
                {
                    context.Especialidades.Remove(especialidad);
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                }
            }
            return result;
        }
          
         
    }
}
