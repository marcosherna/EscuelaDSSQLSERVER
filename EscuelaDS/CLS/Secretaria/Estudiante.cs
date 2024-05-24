using EscuelaDS.CLS.Administracion;
using EscuelaDS.CLS.Dtos;
using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Secretaria
{
    public class Estudiante
    {
        public int NIE { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public System.DateTime FechaNac { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public int IdEncargado { get; set; }
        public int IdDireccion { get; set; }

        public void Validate()
        {
            if (this.NIE < 0) throw new ApplicationException("El NIE del estudiante es requerido");
            if (string.IsNullOrEmpty(this.Nombres)) throw new ApplicationException("El nombre del estudiante es requerido");
            if (string.IsNullOrEmpty(this.Apellidos)) throw new ApplicationException("El apellido del estudiante es requerido");
            if (this.FechaNac == null) throw new ApplicationException("La fecha de nacimiento del estudiante es requerida");
            if (string.IsNullOrEmpty(this.Telefono)) throw new ApplicationException("El teléfono del estudiante es requerido");
            if (string.IsNullOrEmpty(this.Genero)) throw new ApplicationException("El genero del estudiante es requerido");
            if (this.IdEncargado < 0) throw new ApplicationException("El encargdo del estudiante es requerido");
            if (this.IdDireccion < 0) throw new ApplicationException("La dirección del estudiante es requerida");
        }

        public async static Task<List<EstudianteDto>> GeAsync()
        {
            List<EstudianteDto> estudiantes = new List<EstudianteDto>();
            using (var context = new EscuelaDBContext())
            {
                estudiantes = await context.Estudiantes
                    .Include(estudiante => estudiante.Direcciones)
                    .Include(estudiante => estudiante.Encargados)
                    .Include(estudiante => estudiante.Direcciones.Distritos)
                    .Include(estudiante => estudiante.Direcciones.Distritos.Municipios)
                    .Include(estudiante => estudiante.Direcciones.Distritos.Municipios.Departamentos)
                    .Include(estudiante => estudiante.Direcciones.Distritos.Municipios.Departamentos.Paises)
                    .Select(estudiante => new EstudianteDto {
                        NIE = estudiante.NIE,
                        Nombres = estudiante.NombresEstudiante,
                        Apellidos = estudiante.ApellidosEstudiante,
                        Encargado = estudiante.Encargados.NombresEncargado + " " + estudiante.Encargados.ApellidosEncargado,
                        Direccion = estudiante.Direcciones.Distritos.Municipios.Departamentos.Paises.Pais + ", " 
                            + estudiante.Direcciones.Distritos.Municipios.Departamentos.Departamento + ", "
                            + estudiante.Direcciones.Distritos.Municipios.Municipio + ", "
                            + estudiante.Direcciones.Distritos.Distrito +", "
                            + estudiante.Direcciones.Linea1 + ", " + estudiante.Direcciones.Linea2
                    }).ToListAsync();
            }
            return estudiantes;
        }

        public async static Task<Estudiante> GeAsync(int NIE)
        {
            Estudiante estudiante = null;
            using (var context = new EscuelaDBContext())
            {
                var _estudiante = await context.Estudiantes
                    .Where(est => est.NIE == NIE)
                    .FirstOrDefaultAsync();

                if (_estudiante != null)
                {
                    estudiante = new Estudiante
                    {
                        NIE = _estudiante.NIE, 
                        Nombres = _estudiante.NombresEstudiante,
                        Apellidos =_estudiante.ApellidosEstudiante, 
                        FechaNac = _estudiante.FechaNacEstudiante, 
                        Genero = _estudiante.GeneroEstudiante, 
                        Telefono = _estudiante.TelefonoEstudiante,
                        IdDireccion = _estudiante.ID_Direccion, 
                        IdEncargado = _estudiante.ID_Encargado
                    };
                }
            }
            return estudiante;
        }
         
        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var estudiate = new Estudiantes
                {
                    NIE = this.NIE,
                    NombresEstudiante = this.Nombres,
                    ApellidosEstudiante = this.Apellidos,
                    FechaNacEstudiante = this.FechaNac, 
                    GeneroEstudiante = this.Genero,
                    TelefonoEstudiante = this.Telefono, 
                    ID_Direccion = this.IdDireccion, 
                    ID_Encargado = this.IdEncargado
                };
                context.Estudiantes.Add(estudiate);
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
                var estudiante = await context.Estudiantes
                    .Where(_estudiante => _estudiante.NIE == this.NIE)
                    .FirstOrDefaultAsync();

                if (estudiante != null)
                {
                    estudiante.NombresEstudiante = this.Nombres;
                    estudiante.ApellidosEstudiante = this.Apellidos;
                    estudiante.FechaNacEstudiante = this.FechaNac;
                    estudiante.GeneroEstudiante = this.Genero;
                    estudiante.TelefonoEstudiante = this.Telefono;
                    estudiante.ID_Direccion = this.IdDireccion;
                    estudiante.ID_Encargado = this.IdEncargado;

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
                var estudiante = await context.Estudiantes
                    .Where(_estudiante => _estudiante.NIE == this.NIE)
                    .FirstOrDefaultAsync();

                if (estudiante != null)
                {
                    context.Estudiantes.Remove(estudiante);
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                }
            }
            return result;
        }

        public async Task<Direccion> GetDireccionAsync()
        {
            Direccion direccion = null;
            using (var context = new EscuelaDBContext())
            {
                direccion = await context.Direcciones
                    .Where(_direccion => _direccion.ID_Direccion == this.IdDireccion)
                        .Select(_direccion => new Direccion
                        {
                            Id = _direccion.ID_Direccion,
                            CodigoPostal = _direccion.CodigoPostal,
                            Linea = _direccion.Linea1,
                            Linea2 = _direccion.Linea2,
                            IdDistrito = _direccion.ID_Distrito
                        }).FirstOrDefaultAsync();
            }
            return direccion;
        }

        public async Task<Encargado> GetEncargadoAsync()
        {
            Encargado encargado = null;
            using (var context = new EscuelaDBContext())
            { 
                encargado = await context.Estudiantes.Where(
                    estudiante => estudiante.ID_Encargado == this.IdEncargado && 
                    estudiante.NIE == this.NIE)
                    .Select(estudiante => estudiante.Encargados)
                    .Select(_encargado => new Encargado {
                        Nombres = _encargado.NombresEncargado, 
                        Apellidos = _encargado.ApellidosEncargado,
                        DUI = _encargado.DUI_Encargado, 
                        Id = _encargado.ID_Encargado, 
                        IdDireccion = _encargado.ID_Direccion, 
                        Telefono = _encargado.TelefonoEncargado
                    }).FirstAsync();
            }
            return encargado;
        }
    }
}
