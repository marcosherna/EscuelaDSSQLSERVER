using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Rector
{
    public class Turno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Nombre)) throw new ApplicationException("El turno es requerido");
        }
        public static async Task<List<Turno>> GetAsync()
        {
            List<Turno> Turnos = new List<Turno>();
            using (var context = new EscuelaDBContext())
            {
                Turnos = await context.Turnos.Select(
                    turno => new Turno
                    {
                        Id =turno.ID_Turno,
                        Nombre = turno.Turno
                    }).ToListAsync();
            }
            return Turnos;

        }


        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var turno = new Turnos
                { 
                    Turno = this.Nombre
                };
                context.Turnos.Add(turno);
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
                var turno = await context.Turnos
                    .Where(_turno => _turno.ID_Turno == this.Id)
                    .FirstOrDefaultAsync();

                if (turno != null)
                {
                    turno.Turno = this.Nombre;  
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
                var turno = await context.Turnos.Where(_turno => _turno.ID_Turno == this.Id)
                    .FirstOrDefaultAsync();
                if (turno != null)
                {
                    context.Turnos.Remove(turno);
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                }
            }
            return result;
        }

    }
}
