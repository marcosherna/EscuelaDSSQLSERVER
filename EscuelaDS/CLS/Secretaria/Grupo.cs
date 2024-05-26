using EscuelaDS.CLS.Administracion;
using EscuelaDS.CLS.Catalogos;
using EscuelaDS.CLS.Dtos;
using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
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

        public void Validate()
        {
            if(string.IsNullOrEmpty(Grado)) throw new Exception("El grado es requerido");
            if(string.IsNullOrEmpty(Seccion)) throw new Exception("El seccion es requerido");
            if( Anio < 0 ) throw new Exception("El año es requerido");
            if( IdTurno < 0 ) throw new Exception("Seleccione un turno");
            if( IdAula < 0 ) throw new Exception("Seleccione un Aula");
            if( IdDocente < 0 ) throw new Exception("Seleccione un Profesor");
        }
        public async static Task<List<GrupoDto>> GetAsync()
        {
            List<GrupoDto> grupos =  new List<GrupoDto>();
            using(var context = new EscuelaDBContext())
            {
                grupos = await context.Grupos
                    .Include(grupo =>  grupo.Docentes)
                    .Include(grupo =>  grupo.Turnos)
                    .Include(grupo => grupo.Aulas)
                    .Include(grupo => grupo.Docentes.Empleados)
                    .Select(grupo => new GrupoDto {
                        Id = grupo.ID_Grupo, 
                        Grado = grupo.Grado,
                        Seccion =  grupo.Seccion, 
                        Anio = grupo.Anio,
                        Turno = grupo.Turnos.Turno,
                        Aula = "Edificio: "+ grupo.Aulas.Edificio + " No." + grupo.Aulas.NumeroAula, 
                        Docente = grupo.Docentes.Empleados.NombresEmpleado +" " + grupo.Docentes.Empleados.ApellidosEmpleado, 
                    }).ToListAsync();
            }
            return grupos;
        } 
         

        public async static Task<List<GrupoTree>> GetTreeAsync()
        {
            List<GrupoTree> grupos = new List<GrupoTree>();
            using (var context = new EscuelaDBContext())
            {
                grupos = await context.Grupos
                    .Include(grupo => grupo.Docentes)
                    .Include(grupo => grupo.Turnos)
                    .Include(grupo => grupo.Aulas)
                    .Include(grupo => grupo.Docentes.Empleados)
                    .Select( grupo => new GrupoTree { 
                        Id = grupo.ID_Grupo,
                        Detalle = grupo.Grado + " " + grupo.Seccion,
                        Profesor = new GrupoTree.Node { 
                            Id = grupo.Docentes.ID_Docente,
                            Detalle = grupo.Docentes.Empleados.NombresEmpleado + " " + grupo.Docentes.Empleados.ApellidosEmpleado
                        },
                        Estudies =  context.Matriculas
                            .Where(matricula => matricula.ID_Grupo == grupo.ID_Grupo)
                            .Select(matricula => matricula.Estudiantes)
                            .Select(estudiante => new GrupoTree.Node { 
                                Id = estudiante.NIE,
                                Detalle = estudiante.NIE + " " + estudiante.NombresEstudiante + " " + estudiante.ApellidosEstudiante
                            }).ToList(),
                    }).ToListAsync();
            }
            return grupos;
        }

        // obtiene los estudiantes de un grupo
        public async Task<List<EstudianteCalificadoDto>> GetEstudiantesAsync()
        {
            List<EstudianteCalificadoDto> estudiantes = new List<EstudianteCalificadoDto>();
            using (var context = new EscuelaDBContext())
            {
                estudiantes = await context.Matriculas
                    .Where(matricula => matricula.ID_Grupo == this.Id)
                    .Select(matricula => matricula.Estudiantes)
                    .Select(estudiante => new EstudianteCalificadoDto
                    {
                        NIE = estudiante.NIE,
                        Nombre = estudiante.NombresEstudiante + " " + estudiante.ApellidosEstudiante,
                        Encargado = estudiante.Encargados.NombresEncargado + " " + estudiante.Encargados.ApellidosEncargado,
                        Estado = context.Calificaciones
                            .Where(calificacion => calificacion.NIE == estudiante.NIE)
                            .Select(calificacion => calificacion.Estado)
                            .FirstOrDefault() ?? "Sin calificar"
                    }).ToListAsync();
            }
            return estudiantes;
        }

        public async Task<List<EstudianteModelReportDto>> GetEstudianteModelReportDtoAsync()
        {
            List<EstudianteModelReportDto> estudiantes = new List<EstudianteModelReportDto>();
            using (var context = new EscuelaDBContext())
            {
                estudiantes = await context.Matriculas
                    .Where(matricula => matricula.ID_Grupo == this.Id)
                    .Select(matricula => matricula.Estudiantes)
                    .Select(estudiante => new EstudianteModelReportDto { 
                        Id = estudiante.NIE,
                        Nombre = estudiante.NombresEstudiante + " " + estudiante.ApellidosEstudiante,
                        Edad = DateTime.Now.Year - estudiante.FechaNacEstudiante.Year, 
                        Genero = estudiante.GeneroEstudiante == "1" ? "Hombre" : estudiante.GeneroEstudiante == "2" ? "Mujer" : "Otro",
                        Seccion = this.Grado + " " + this.Seccion
                    }).ToListAsync();
            }
            return estudiantes;
        }

        public async static Task<Grupo> GetAsync(int id)
        {
            Grupo grupo = null;
            using (var context = new EscuelaDBContext())
            {
                grupo = await context.Grupos
                    .Where(_grupo => _grupo.ID_Grupo == id)
                    .Select(_grupo => new Grupo
                    {
                        Id = _grupo.ID_Grupo,
                        Grado = _grupo.Grado,
                        Seccion = _grupo.Seccion,
                        Anio = _grupo.Anio,
                        IdAula = _grupo.ID_Aula, 
                        IdDocente = _grupo.ID_Docente,
                        IdTurno = _grupo.ID_Turno,
                    }).FirstOrDefaultAsync();
            }
            return grupo;
        }
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

        public async static Task<bool> DeleteAsync(int Id)
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var grupo = await context.Grupos
                    .Where(_grupo => _grupo.ID_Grupo == Id)
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
