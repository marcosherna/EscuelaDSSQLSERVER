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
    public class Municipio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdDepartamento { get; set; }
        public int IdPais { get; set; }


        public static async Task<List<MunicipioDto>> GetAsync() 
        {             
            List<MunicipioDto> municipios = new List<MunicipioDto>();
            using (var context = new EscuelaDBContext())
            {
                municipios = await context.Municipios
                    .Include(municipio => municipio.Departamentos.Paises)
                    .Include(municipio => municipio.Departamentos)
                        .Select(m => new MunicipioDto
                        {
                            Id = m.ID_Municipio,
                            Nombre = m.Municipio,
                            Departamento = m.Departamentos.Departamento,
                            Pais = m.Departamentos.Paises.Pais
                        }).ToListAsync();
            }
            return municipios; 
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Nombre)) throw new ApplicationException("El nombre del municipio es requerido");
            if (this.IdDepartamento <= 0) throw new ApplicationException("El departamento es requerido");
        }

        public async static Task<Municipio> GetByIdAsync(int id) 
        {
            Municipio municipio = null;
            using (var context = new EscuelaDBContext())
            {
                var m = await context.Municipios
                    .Include(_municipio => _municipio.Departamentos)
                    .Where(_municipio => _municipio.ID_Municipio == id)
                    .FirstOrDefaultAsync();

                if (m != null)
                {
                    municipio = new Municipio();
                    municipio.Id = m.ID_Municipio;
                    municipio.Nombre = m.Municipio;
                    municipio.IdDepartamento = m.ID_Departamento;
                    municipio.IdPais = m.Departamentos.ID_Pais;
                }
            }
            return municipio;
        }

        public async static Task<List<Municipio>> GetByIdDepartamentoAsync(int id)
        {
            List<Municipio> municipios = new List<Municipio>();
            using (var context = new EscuelaDBContext())
            {
                municipios = await context.Municipios
                    .Include(_municipio => _municipio.Departamentos)
                    .Where(_municipio => _municipio.ID_Departamento == id)
                    .Select(municipio => new Municipio
                    {
                        Id = municipio.ID_Municipio,
                        Nombre = municipio.Municipio,
                        IdDepartamento = municipio.ID_Departamento,
                        IdPais = municipio.Departamentos.ID_Pais
                    }).ToListAsync();
            }
            return municipios;
        }


        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var municipio = new Municipios
                {
                    Municipio = this.Nombre,
                    ID_Departamento = this.IdDepartamento
                };
                context.Municipios.Add(municipio);
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
                var municipio = await context.Municipios
                    .Where(m => m.ID_Municipio == this.Id)
                    .FirstOrDefaultAsync();

                if (municipio != null)
                {
                    municipio.Municipio = this.Nombre;
                    municipio.ID_Departamento = this.IdDepartamento;
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
                var municipio = await context.Municipios
                    .Where(m => m.ID_Municipio == this.Id)
                    .FirstOrDefaultAsync();

                if (municipio != null)
                {
                    context.Municipios.Remove(municipio);
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                }
            }
            return result;
        }
    }
}
