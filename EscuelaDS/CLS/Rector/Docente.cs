using EscuelaDS.CLS.Dtos;
using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Rector
{
    public class Docente
    {
        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        public int IdEspecialidad { get; set; }
        public string Escalafon { get; set; }

        public void Validate()
        {
            if (this.IdEmpleado <= 0) throw new Exception("Seleccione un empleado");
            if (this.IdEspecialidad <= 0) throw new Exception("Seleccione una especialidad");
            if (string.IsNullOrEmpty(this.Escalafon)) throw new Exception("El escalafon es requerido");
        }

        public async static Task<List<DocenteDto>> GetAsync()
        {
            List<DocenteDto> docentes = new List<DocenteDto>();
            using(var context = new EscuelaDBContext())
            {
                docentes = await context.Docentes
                    .Include(docente => docente.Empleados)
                    .Include(docente => docente.Especialidades)
                        .Select(docente => new DocenteDto { 
                            Id = docente.ID_Docente, 
                            Nombre = docente.Empleados.NombresEmpleado + " " +
                                docente.Empleados.ApellidosEmpleado,
                            Correo = docente.Empleados.Correo,
                            Especialidad = docente.Especialidades.NombreEspecialidad
                        }).ToListAsync();
            }
            return docentes;
        }

        public async static Task<Docente> GetAsync(int id)
        {
            Docente docente = null;
            using (var context = new EscuelaDBContext())
            {
                docente = await context.Docentes
                    .Where(_docente => _docente.ID_Docente == id)
                        .Select(_docente => new Docente
                        {
                            Id = _docente.ID_Docente,
                            Escalafon = _docente.Escalafon,
                            IdEmpleado = _docente.ID_Empleado,
                            IdEspecialidad = _docente.ID_Especialidad
                        }).FirstOrDefaultAsync();
            }
            return docente;
        }

        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var docente = new Docentes
                {
                    ID_Empleado = this.IdEmpleado,
                    ID_Especialidad = this.IdEspecialidad,
                    Escalafon = this.Escalafon
                };
                context.Docentes.Add(docente);
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
                var docente = await context.Docentes.FindAsync(this.Id);
                if(docente != null)
                {
                    docente.ID_Empleado = this.IdEmpleado;
                    docente.ID_Especialidad = this.IdEspecialidad;
                    docente.Escalafon = this.Escalafon;

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
                var docente = await context.Docentes.FindAsync(this.Id);
                if (docente != null)
                {
                     context.Docentes.Remove(docente);
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                } 
            }
            return result;
        }
    }
}
