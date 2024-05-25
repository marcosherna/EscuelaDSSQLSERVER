using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Secretaria
{
    public class Matricula
    {
        public int Id { get; set; }
        public int NIE { get; set; }
        public int IdGrupo { get; set; }

        public void Validate()
        {
            if (NIE < 0) throw new Exception("El NIE es requerido");
            if (IdGrupo < 0) throw new Exception("Seleccione un grupo");
            if (isMatriculado()) throw new Exception("El estudiante ya esta matriculado en este grupo");
        }

        public bool isMatriculado()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                result = context.Matriculas
                    .Where(matricula => matricula.NIE == this.NIE && matricula.ID_Grupo == this.IdGrupo)
                    .Count() > 0;
            }
            return result;
        }
        public async Task<bool> SaveAsync()
        {
            bool result = false; 
            using (var context = new EscuelaDBContext())
            {
                var matricula = new Matriculas { NIE = this.NIE, ID_Grupo = this.IdGrupo };
                context.Matriculas.Add(matricula);
                await context.SaveChangesAsync();
                result = true;
            }
            return result;
        }
         
        public async Task<bool> DeleteAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var matricula = await context.Matriculas.FindAsync(this.Id);
                context.Matriculas.Remove(matricula);
                await context.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async static Task<bool> DeleteAsync(int idGrupo,int idEstudiate)
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var matricula = await context.Matriculas
                    .Where(_matricula => _matricula.ID_Grupo == idGrupo && _matricula.NIE == idEstudiate)
                    .FirstOrDefaultAsync();

                context.Matriculas.Remove(matricula);
                await context.SaveChangesAsync();
                result = true;
            }
            return result;
        }
    }
}
