using EscuelaDS.CLS.Administracion;
using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Secretaria
{
    public class Encargado
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string DUI { get; set; }
        public int IdDireccion { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Nombres)) throw new Exception("Los nombres son requerido");
            if (string.IsNullOrEmpty(this.Apellidos)) throw new Exception("Los apellidos son requerido");
            if (string.IsNullOrEmpty(this.Telefono)) throw new Exception("El Telefono es requerido");
            if (string.IsNullOrEmpty(this.DUI)) throw new Exception("El dui es requerido");
            if (this.IdDireccion < 0) throw new Exception("Se necesita de una direccion");
        }

        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var encargado = new Encargados
                { 
                    NombresEncargado = this.Nombres,
                    ApellidosEncargado = this.Apellidos,
                    DUI_Encargado = this.DUI,
                    TelefonoEncargado = this.Telefono,
                    ID_Direccion = this.IdDireccion
                };
                context.Encargados.Add(encargado);
                await context.SaveChangesAsync();
                result = true;
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

        public async Task<Encargado> SaveAndReturnAsync()
        {
            Encargado encargado = null;
            using (var context = new EscuelaDBContext())
            {
                var _encargado = new Encargados
                {
                    NombresEncargado = this.Nombres,
                    ApellidosEncargado = this.Apellidos,
                    DUI_Encargado = this.DUI, 
                    TelefonoEncargado = this.Telefono,
                    ID_Direccion = this.IdDireccion,
                };
                context.Encargados.Add(_encargado);
                int row = await context.SaveChangesAsync();
                if (row > 0)
                {
                    encargado = new Encargado
                    { 
                        Id = _encargado.ID_Encargado,
                        Nombres = _encargado.NombresEncargado,
                        Apellidos = _encargado.ApellidosEncargado,
                        DUI = _encargado.DUI_Encargado,
                        Telefono = _encargado.TelefonoEncargado,
                        IdDireccion = _encargado.ID_Direccion,
                    };
                }
            }
            return encargado;
        }


        public async Task<bool> UpdateAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var encargado = await context.Encargados
                    .Where(_encargado => _encargado.ID_Encargado == this.Id)
                    .FirstOrDefaultAsync();
                if (encargado != null)
                {
                    encargado.NombresEncargado = this.Nombres;
                    encargado.ApellidosEncargado = this.Apellidos;
                    encargado.DUI_Encargado = this.DUI;
                    encargado.TelefonoEncargado = this.Telefono;
                    encargado.ID_Direccion = this.IdDireccion;

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
                var encargado = await context.Encargados
                    .Where(_encargado => _encargado.ID_Encargado == this.Id)
                    .FirstOrDefaultAsync();

                if (encargado != null)
                {
                    context.Encargados.Remove(encargado);
                    await context.SaveChangesAsync();
                    result = true;
                }
            }
            return result;
        }
    }
}
