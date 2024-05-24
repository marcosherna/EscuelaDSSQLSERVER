using EscuelaDS.CLS.Administracion;
using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Secretaria
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }
        public int Anio { get; set; }
        public int IdTurno { get; set; }
        public int IdAula { get; set; }
        public int IdDocente { get; set; }


        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var grupo = new Grupos
                { 
                    Grado = this.Grado, 
                    Seccion =  this.Seccion,
                    Anio = this.Anio,
                    ID_Turno = this.IdTurno, 
                    ID_Aula =  this.IdAula,
                    ID_Docente = this.IdDocente,
                };
                context.Grupos.Add(grupo);
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
                var grupo = await context.Grupos
                    .Where(_grupo => _grupo.ID_Grupo == this.Id)
                    .FirstOrDefaultAsync();

                if (grupo != null)
                {
                    grupo.Grado = this.Grado;
                    grupo.Seccion = this.Seccion;
                    grupo.Anio = this.Anio;
                    grupo.ID_Turno = this.IdTurno;
                    grupo.ID_Aula = this.IdAula;
                    grupo.ID_Docente = this.IdDocente;

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
                var grupo = await context.Grupos
                    .Where(_grupo => _grupo.ID_Grupo == this.Id)
                    .FirstOrDefaultAsync();

                if (grupo != null)
                {
                    context.Grupos.Remove(grupo);
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                }
            }
            return result;
        }
          
    }
}
