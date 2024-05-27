using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Rector
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Nombre)) throw new ApplicationException("El nombre de la materia es requerido");
        }
        public static async Task<List<Materia>> GetAsync()
        {
            List<Materia> materias = new List<Materia>();
            using (var context = new EscuelaDBContext())
            {
                materias = await context.Materias.Select(
                    materia => new Materia
                    { 
                        Id = materia.ID_Materia,
                        Nombre = materia.NombreMateria
                    }).ToListAsync();
            }
            return materias; 
        }


        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var materia = new Materias
                {
                    NombreMateria = this.Nombre
                };
                context.Materias.Add(materia);
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
                var materia = await context.Materias
                    .Where(_materia => _materia.ID_Materia == this.Id)
                    .FirstOrDefaultAsync();

                if (materia != null)
                {
                    materia.NombreMateria = this.Nombre;
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
                var materia = await context.Materias.Where(_materia => _materia.ID_Materia == this.Id)
                    .FirstOrDefaultAsync();
                if (materia != null)
                {
                    context.Materias.Remove(materia);
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                }
            }
            return result;
        }

        public async static Task<Materia> GetByNombre(string nombre)
        {
            Materia materia = null;
            using (var context = new EscuelaDBContext())
            {
                var _materia = await context.Materias
                    .Where(m => m.NombreMateria == nombre)
                    .FirstOrDefaultAsync();

                if (_materia != null)
                {
                    materia = new Materia
                    {
                        Id = _materia.ID_Materia,
                        Nombre = _materia.NombreMateria
                    };
                }
            }
            return materia;
        }

    }
}
