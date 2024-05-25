using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Secretaria
{
    public class Calificacion
    {
        public int Id { get; set; }
        public int IdMateria { get; set; }
        public int NIE { get; set; }
        public int IdDocente { get; set; }
        public decimal Examen1 { get; set; }
        public decimal Examen2 { get; set; }
        public decimal Examen3 { get; set; }
        public decimal ExamenFinal { get; set; }
        public decimal Tareas { get; set; }
        public decimal Promedio { get; set; }
        public string Estado { get; set; }

        public async Task<bool> SaveAsync()
        {
            bool result = false; 
            using(var context = new EscuelaDBContext())
            {
                var calificacion = new Calificaciones
                {
                    ID_Materia = this.IdMateria,
                    NIE = this.NIE,
                    ID_Docente = this.IdDocente,
                    Examen1 = this.Examen1,
                    Examen2 = this.Examen2,
                    Examen3 = this.Examen3,
                    ExamenFinal = this.ExamenFinal,
                    Tareas = this.Tareas,
                    Promedio = this.Promedio,
                    Estado = this.Estado
                };
                
                context.Calificaciones.Add(calificacion);
                int row = await context.SaveChangesAsync();
                result = row > 0;
            }
            return result;
        }

        public async Task<bool> UpdateAsync()
        {
            bool result = false;
            using(var context = new EscuelaDBContext())
            {
                var calificacion = await context.Calificaciones
                    .Where(x => x.NIE == this.NIE)
                    .FirstOrDefaultAsync();

                if(calificacion != null)
                {
                    calificacion.ID_Materia = this.IdMateria;
                    calificacion.ID_Docente = this.IdDocente;
                    calificacion.Examen1 = this.Examen1;
                    calificacion.Examen2 = this.Examen2;
                    calificacion.Examen3 = this.Examen3;
                    calificacion.ExamenFinal = this.ExamenFinal;
                    calificacion.Tareas = this.Tareas;
                    calificacion.Promedio = this.Promedio;
                    calificacion.Estado = this.Estado;
                    context.Entry(calificacion).State = EntityState.Modified;
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                }
            }
            return result;
        }


        public async Task<Calificacion> GetCalificacionByIdEstudiante ()
        {
            Calificacion calificacion = null;
            using(var context = new EscuelaDBContext())
            {
                calificacion = await context.Calificaciones
                    .Where(x => x.NIE == this.NIE)
                    .Select(_calificacion => new Calificacion { 
                        Id = _calificacion.ID_Calificacion,
                        IdMateria = _calificacion.ID_Materia,
                        NIE = _calificacion.NIE,
                        IdDocente = _calificacion.ID_Docente,
                        Examen1 = (decimal)_calificacion.Examen1,
                        Examen2 = (decimal)_calificacion.Examen2,
                        Examen3 = (decimal)_calificacion.Examen3,
                        ExamenFinal = (decimal)_calificacion.ExamenFinal,
                        Tareas = (decimal)_calificacion.Tareas,
                        Promedio = (decimal)_calificacion.Promedio, 
                        Estado = _calificacion.Estado
                    }).FirstOrDefaultAsync();
            }
            return calificacion;
        }
    }
}
