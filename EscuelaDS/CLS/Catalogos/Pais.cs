using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Catalogos
{
    public class Pais
    {
        public int Id { get; set; }
        public String Nombre { get; set; }

        public void Validate()
        {
            if(string.IsNullOrEmpty(this.Nombre)) throw new Exception("El nombre del país es requerido");
        } 
        
        public static async Task<List<Pais>> GetAsync()
        {
            List<Pais> paises = new List<Pais>();
            using (var context = new EscuelaDBContext())
            {
                paises = await context.Paises.Select(pais => new Pais {
                    Id = pais.ID_Pais,
                    Nombre = pais.Pais
                }).ToListAsync();
            }
            return paises;
        }

        public static Task<List<Pais>> GetAsync(Func<Paises, bool> query)
        {
            List<Pais> paises = new List<Pais>();
            using (var context = new EscuelaDBContext())
            {
                paises = context.Paises 
                    .Where(query).Select(pais => new Pais {
                    Id = pais.ID_Pais,
                    Nombre = pais.Pais
                }).ToList();
            }
            return Task.FromResult(paises);
        }

        public async Task<bool> Save()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                context.Paises.Add(new Paises
                {
                    Pais = this.Nombre
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
                var pais = context.Paises.Where(p => p.ID_Pais == this.Id).FirstOrDefault();
                if (pais != null)
                {
                    pais.Pais = this.Nombre;
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
                var pais = context.Paises.Where(p => p.ID_Pais == this.Id).FirstOrDefault();
                if (pais != null)
                {
                    context.Paises.Remove(pais);
                    await context.SaveChangesAsync();
                    result = true;
                }
            }
            return result;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            List<Departamento> departamentos = new List<Departamento>();
            using (var context = new EscuelaDBContext())
            {
                departamentos = await context.Departamentos
                    .Where(d => d.ID_Pais == this.Id)
                    .Select(d => new Departamento
                    {
                        Id = d.ID_Departamento,
                        Nombre = d.Departamento
                    }).ToListAsync();
            }
            return departamentos;
        }

        public Task<List<Departamento>> GetDepartamentosAsync(Func<Departamentos, bool> query)
        {
            List<Departamento> departamentos = new List<Departamento>();
            using (var context = new EscuelaDBContext())
            {
                departamentos = context.Departamentos
                    
                    .Where(d => d.ID_Pais == this.Id)
                    .Where(query)
                    .Select(d => new Departamento
                    {
                        Id = d.ID_Departamento,
                        Nombre = d.Departamento
                    }).ToList();
            }
            return Task.FromResult(departamentos);
        }

        public static async Task<Pais> GetByIDAsync(int ID)
        {
            Pais pais = new Pais();
            using (var context = new EscuelaDBContext())
            {
                pais = await context.Paises.Where(p => p.ID_Pais == ID).Select(p => new Pais 
                { 
                    Id = p.ID_Pais,
                    Nombre = p.Pais
                }).FirstOrDefaultAsync();
                 
            }
            return pais;
        }
    }
}
