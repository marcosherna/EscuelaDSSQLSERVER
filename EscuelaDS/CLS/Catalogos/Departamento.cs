using EscuelaDS.CLS.Dtos;
using EscuelaDS.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Catalogos
{
    public class Departamento
    { 
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdPais { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Nombre)) throw new ApplicationException("El nombre del departamento es requerido"); 
            if (this.IdPais <= 0) throw new ApplicationException("El país es requerido");
        }
        public static async Task<List<DepartamentoDto>> GetAsync()
        {
            List<DepartamentoDto> departamentos = new List<DepartamentoDto>();
            using(var context = new EscuelaDBContext())
            {
                departamentos = await context.Departamentos
                    .Include(departamento => departamento.Paises)
                        .Select(d => new DepartamentoDto {
                            Id = d.ID_Departamento,
                            Nombre = d.Departamento,
                            Pais = d.Paises.Pais
                        }).ToListAsync();
            }
            return departamentos;

        }
        
        public async Task<List<Municipio>> GetMunicipiosAsync()
        {
            List<Municipio> municipios = new List<Municipio>();
            using (var context = new EscuelaDBContext())
            {
                municipios = await context.Municipios
                    .Where(municipio => municipio.ID_Departamento == this.Id)
                    .Select(municipio => new Municipio
                    {
                        Id = municipio.ID_Municipio,
                        Nombre = municipio.Municipio,
                        IdDepartamento = municipio.ID_Departamento
                    }).ToListAsync(); 
            }
            return municipios;
        }

        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var d = new Departamentos
                {
                    Departamento = this.Nombre,
                    ID_Pais = this.IdPais
                };
                context.Departamentos.Add(d);
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
                var departemento = await context.Departamentos
                    .Where(d => d.ID_Departamento == this.Id)
                    .FirstOrDefaultAsync();

                if (departemento != null)
                {
                    departemento.Departamento = this.Nombre;
                    departemento.ID_Pais = this.IdPais;
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
                var departamento = await context.Departamentos
                    .Where(d => d.ID_Departamento == this.Id)
                    .FirstOrDefaultAsync();
                if (departamento != null) 
                {
                    context.Departamentos.Remove(departamento);
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                }

                
            }
            return result;
        }

        public static async Task<Departamento> GetAsync(int id)
        {
            Departamento departamento = null;
            using (var context = new EscuelaDBContext())
            {
                var d = await context.Departamentos
                    .Where(_departamento => _departamento.ID_Departamento == id)
                    .FirstOrDefaultAsync();
                if(d != null)
                {
                    departamento = new Departamento();
                    departamento.Id = d.ID_Departamento;
                    departamento.Nombre = d.Departamento;
                    departamento.IdPais = d.ID_Pais;
                }
            }
            return departamento;
        }

        public async Task<Pais> GetPaisAsync()
        { 
            Pais pais = null;
            using (var context = new EscuelaDBContext())
            {
                var p = await context.Paises
                    .Where(_pais => _pais.ID_Pais == this.IdPais)
                    .FirstOrDefaultAsync();

                if (p != null)
                {
                    pais = new Pais();
                    pais.Id = p.ID_Pais;
                    pais.Nombre = p.Pais;
                }
            }
            return pais;
        }
    }
}
