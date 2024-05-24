using EscuelaDS.CLS.Catalogos;
using EscuelaDS.CLS.Dtos;
using EscuelaDS.DataLayer;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Administracion
{
    public class Empleado
    {
        public int Id { get; set; }
        public string DUI { get; set; }
        public string ISSS { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public System.DateTime FechaNac { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int IdCargo { get; set; }
        public int IdDireccion { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Nombres)) throw new ApplicationException("El nombre del empleado es requerido");
            if (string.IsNullOrEmpty(this.Apellidos)) throw new ApplicationException("El apellido del empleado es requerido");
            if (this.FechaNac == null) throw new ApplicationException("La fecha de nacimiento del empleado es requerida");
            if (string.IsNullOrEmpty(this.Telefono)) throw new ApplicationException("El teléfono del empleado es requerido");
            if (string.IsNullOrEmpty(this.Correo)) throw new ApplicationException("El correo del empleado es requerido");
            if (this.IdCargo <= 0) throw new ApplicationException("El cargo del empleado es requerido");
            if (this.IdDireccion <= 0) throw new ApplicationException("La dirección del empleado es requerida");
        }

        public async static Task<List<EmpleadoDto>> GeAsync()
        {
            List<EmpleadoDto> empleados = new List<EmpleadoDto>();
            using(var context =  new EscuelaDBContext())
            {
               empleados = await context.Empleados
                    .Include(empleado => empleado.Direcciones)
                    .Include(empleado => empleado.Direcciones.Distritos)
                    .Include(empleado => empleado.Direcciones.Distritos.Municipios)
                    .Include(empleado => empleado.Direcciones.Distritos.Municipios.Departamentos)
                    .Include(empleado => empleado.Direcciones.Distritos.Municipios.Departamentos.Paises)
                    .Include(empleado => empleado.Cargos)
                    .Select(empleado => new EmpleadoDto
                       {
                           Id = empleado.ID_Empleado,
                           DUI = empleado.DUI_Empleado,
                           ISSS = empleado.ISSS_Empleado,
                           Descripcion = empleado.NombresEmpleado + " " + 
                                empleado.ApellidosEmpleado,
                           Telefono = empleado.TelefonoEmpleado,
                           Cargo = empleado.Cargos.Cargo,
                           Direccion = empleado.Direcciones.Distritos.Municipios.Departamentos.Paises.Pais + ", " +
                                empleado.Direcciones.Distritos.Municipios.Departamentos.Departamento + ", " +
                                empleado.Direcciones.Distritos.Municipios.Municipio + ", " +
                                empleado.Direcciones.Distritos.Distrito + " " + empleado.Direcciones.Linea1 + " " + empleado.Direcciones.Linea2,
                    }).ToListAsync(); 
            }
            return empleados;
        }

        public static Task<List<EmpleadoDto>> GeAsync(Func<Empleados, bool> query)
        {
            List<EmpleadoDto> empleados = new List<EmpleadoDto>();
            using (var context = new EscuelaDBContext())
            {
                empleados = context.Empleados
                     .Include(empleado => empleado.Direcciones)
                     .Include(empleado => empleado.Direcciones.Distritos)
                     .Include(empleado => empleado.Direcciones.Distritos.Municipios)
                     .Include(empleado => empleado.Direcciones.Distritos.Municipios.Departamentos)
                     .Include(empleado => empleado.Direcciones.Distritos.Municipios.Departamentos.Paises)
                     .Include(empleado => empleado.Cargos)
                     .Where(query)
                     .Select(empleado => new EmpleadoDto
                     {
                         Id = empleado.ID_Empleado,
                         DUI = empleado.DUI_Empleado,
                         ISSS = empleado.ISSS_Empleado,
                         Descripcion = empleado.NombresEmpleado + " " +
                                 empleado.ApellidosEmpleado,
                         Telefono = empleado.TelefonoEmpleado,
                         Cargo = empleado.Cargos.Cargo,
                         Direccion = empleado.Direcciones.Distritos.Municipios.Departamentos.Paises.Pais + ", " +
                                 empleado.Direcciones.Distritos.Municipios.Departamentos.Departamento + ", " +
                                 empleado.Direcciones.Distritos.Municipios.Municipio + ", " +
                                 empleado.Direcciones.Distritos.Distrito + " " + empleado.Direcciones.Linea1 + " " + empleado.Direcciones.Linea2,
                     }).ToList();
            }
            return Task.FromResult(empleados);
        }

        public async static Task<Empleado> GeAsync(int id)
        {
            Empleado empleado = null;
            using (var context = new EscuelaDBContext())
            { 
                var e = await context.Empleados
                    .Where(_empleado => _empleado.ID_Empleado == id)
                    .FirstOrDefaultAsync();
                if (e != null)
                {
                    empleado = new Empleado
                    {
                        Id = e.ID_Empleado,
                        DUI = e.DUI_Empleado,
                        ISSS = e.ISSS_Empleado,
                        Nombres = e.NombresEmpleado,
                        Apellidos = e.ApellidosEmpleado,
                        FechaNac = e.FechaNacEmpleado,
                        Telefono = e.TelefonoEmpleado,
                        Correo = e.Correo,
                        IdCargo = e.ID_Cargo,
                        IdDireccion = e.ID_Direccion
                    };
                }
            }
            return empleado;
        }

        

        public async Task<bool> SaveAsync()
        { 
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var empleado = new Empleados
                {
                    DUI_Empleado = this.DUI,
                    ISSS_Empleado = this.ISSS,
                    NombresEmpleado = this.Nombres,
                    ApellidosEmpleado = this.Apellidos,
                    FechaNacEmpleado = this.FechaNac,
                    TelefonoEmpleado = this.Telefono,
                    Correo = this.Correo,
                    ID_Cargo = this.IdCargo,
                    ID_Direccion = this.IdDireccion
                };
                context.Empleados.Add(empleado);
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
                var empleado = await context.Empleados
                    .Where(e => e.ID_Empleado == this.Id)
                    .FirstOrDefaultAsync();
                if (empleado != null)
                {
                    empleado.DUI_Empleado = this.DUI;
                    empleado.ISSS_Empleado = this.ISSS;
                    empleado.NombresEmpleado = this.Nombres;
                    empleado.ApellidosEmpleado = this.Apellidos;
                    empleado.FechaNacEmpleado = this.FechaNac;
                    empleado.TelefonoEmpleado = this.Telefono;
                    empleado.Correo = this.Correo;
                    empleado.ID_Cargo = this.IdCargo;
                    empleado.ID_Direccion = this.IdDireccion;
                    await context.SaveChangesAsync();
                    result = true;
                }
            }
            return result;
        }

        public async Task<bool> DeleteAsync()
        { 
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var empleado = await context.Empleados
                    .Where(e => e.ID_Empleado == this.Id)
                    .FirstOrDefaultAsync();
                if (empleado != null)
                {
                    context.Empleados.Remove(empleado);
                    await context.SaveChangesAsync();
                    result = true;
                }
            }
            return result;
        }

        public async Task<Direccion> GetDireccionAsync()
        {
            Direccion direccion = null;
            using(var context = new EscuelaDBContext())
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

         
    }
}
