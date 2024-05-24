using EscuelaDS.CLS.Catalogos;
using EscuelaDS.CLS.Dtos;
using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Administracion
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Nombre)) throw new ApplicationException("El nombre del departamento es requerido");
        }
        public static async Task<List<Cargo>> GetAsync()
        {  
            List<Cargo> cargos = new List<Cargo>();
            using (var context = new EscuelaDBContext())
            {
                cargos = await context.Cargos
                    .Select(cargo => new Cargo
                    {
                        Id = cargo.ID_Cargo,
                        Nombre = cargo.Cargo
                    }).ToListAsync();
            }
            return cargos;
        }


        public async Task<bool> SaveAsync()
        { 
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                context.Cargos.Add(new Cargos
                {
                    Cargo = this.Nombre
                });
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
                var cargo = await context.Cargos
                    .Where(c => c.ID_Cargo == this.Id)
                    .FirstOrDefaultAsync();
                if (cargo != null)
                {
                    cargo.Cargo = this.Nombre;
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
                var cargo = await context.Cargos
                    .Where(c => c.ID_Cargo == this.Id)
                    .FirstOrDefaultAsync();
                if (cargo != null)
                {
                    context.Cargos.Remove(cargo);
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                }
            }
            return result;
        }

        public static async Task<Cargo> GetAsync(int id)
        { 
            Cargo cargo = null;
            using (var context = new EscuelaDBContext())
            {
                var c = await context.Cargos
                    .Where(_cargo => _cargo.ID_Cargo == id)
                    .FirstOrDefaultAsync();

                if (c != null)
                {
                    cargo = new Cargo();
                    cargo.Id = c.ID_Cargo;
                    cargo.Nombre = c.Cargo;
                }
            }
            return cargo;
        } 
    }
}
