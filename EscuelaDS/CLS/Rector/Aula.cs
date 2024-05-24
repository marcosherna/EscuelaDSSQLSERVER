using EscuelaDS.CLS.Catalogos;
using EscuelaDS.CLS.Dtos;
using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Rector
{
    public class Aula
    {
        public int Id { get; set; }
        public string Edificio { get; set; }
        public string Piso { get; set; }
        public string Numero { get; set; }


        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Edificio)) throw new ApplicationException("El edificio del aula es requerido");
            if (string.IsNullOrEmpty(this.Piso)) throw new ApplicationException("El piso del aula es requerido");
            if (string.IsNullOrEmpty(this.Numero)) throw new ApplicationException("El numero del aula es requerido");
        }
        public static async Task<List<Aula>> GetAsync()
        {
            List<Aula> aulas = new List<Aula>();
            using (var context = new EscuelaDBContext())
            {
                aulas = await context.Aulas.Select(
                    aula => new Aula {
                        Id = aula.ID_Aula,
                        Edificio = aula.Edificio,
                        Piso = aula.Piso,
                        Numero = aula.NumeroAula,
                    }).ToListAsync();
            }
            return aulas;

        }
         

        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var aula = new Aulas
                {
                    Edificio = this.Edificio,
                    Piso = this.Piso,
                    NumeroAula = this.Numero
                };
                context.Aulas.Add(aula);
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
                var aula = await context.Aulas
                    .Where(_aula => _aula.ID_Aula == this.Id)
                    .FirstOrDefaultAsync();

                if (aula != null)
                {
                    aula.Piso = this.Piso;
                    aula.Edificio = this.Edificio;
                    aula.NumeroAula = this.Numero;

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
                var aula = await context.Aulas.Where(_aula => _aula.ID_Aula == this.Id)
                    .FirstOrDefaultAsync();
                if (aula != null)
                {
                    context.Aulas.Remove(aula);
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                } 
            }
            return result;
        }
          
    }
}

