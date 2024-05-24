using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Administracion
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Linea { get; set; }
        public string Linea2 { get; set; }
        public int IdDistrito { get; set; }
        public string CodigoPostal { get; set; }

        public void Validate()
        {
            if (this.Linea == null || this.Linea.Length == 0)
            {
                throw new Exception("Debe ingresar una dirección");
            }
            if (this.IdDistrito < 0)
            {
                throw new Exception("Debe seleccionar un distrito");
            }
            if (this.CodigoPostal == null || this.CodigoPostal.Length == 0)
            {
                throw new Exception("Debe ingresar un código postal");
            }
        }

        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var direccion = new Direcciones
                {
                    Linea1 = this.Linea,
                    Linea2 = this.Linea2,
                    ID_Distrito = this.IdDistrito,
                    CodigoPostal = this.CodigoPostal
                };
                context.Direcciones.Add(direccion);
                int row = await context.SaveChangesAsync();
                result = row > 0;
            }
            return result;
        }

        public async Task<Direccion> SaveAndReturnAsync()
        {
            Direccion result = null;
            using (var context = new EscuelaDBContext())
            {
                var direccion = new Direcciones
                {
                    Linea1 = this.Linea,
                    Linea2 = this.Linea2,
                    ID_Distrito = this.IdDistrito,
                    CodigoPostal = this.CodigoPostal
                };
                context.Direcciones.Add(direccion);
                int row = await context.SaveChangesAsync();
                if (row > 0)
                {
                    result = new Direccion
                    {
                        Id = direccion.ID_Direccion,
                        Linea = direccion.Linea1,
                        Linea2 = direccion.Linea2,
                        IdDistrito = direccion.ID_Distrito,
                        CodigoPostal = direccion.CodigoPostal
                    };
                }
            }
            return result;
        }

        public async Task<bool> UpdateAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var direccion = await context.Direcciones.FindAsync(this.Id);
                if (direccion != null)
                {
                    direccion.Linea1 = this.Linea;
                    direccion.Linea2 = this.Linea2;
                    direccion.ID_Distrito = this.IdDistrito;
                    direccion.CodigoPostal = this.CodigoPostal;
                    context.Entry(direccion).State = System.Data.Entity.EntityState.Modified;
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
                var direccion = await context.Direcciones.FindAsync(this.Id);
                if (direccion != null)
                {
                    context.Direcciones.Remove(direccion);
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                }
            }
            return result;
        }
    }
}
