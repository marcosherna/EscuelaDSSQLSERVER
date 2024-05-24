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
    public class Distrito
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdMunicipio { get; set; }
        public int IdDepartamento { get; set; }
        public int IdPais { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Nombre)) throw new ApplicationException("El nombre del distrito es requerido");
            if (this.IdMunicipio <= 0) throw new ApplicationException("El municipio es requerido");
        }


        public static async Task<List<DistritoDto>> GetAsync()
        {
            List<DistritoDto> distritos = new List<DistritoDto>();
            using (var context = new EscuelaDBContext())
            {
                distritos = await context.Distritos
                    .Include(distrito => distrito.Municipios)
                    .Include(distrito => distrito.Municipios.Departamentos)
                    .Include(distrito => distrito.Municipios.Departamentos.Paises)
                        .Select(d => new DistritoDto
                        {
                            Id = d.ID_Distrito,
                            Nombre = d.Distrito,
                            Municipio = d.Municipios.Municipio,
                            Departamenbto = d.Municipios.Departamentos.Departamento,
                            Pais = d.Municipios.Departamentos.Paises.Pais
                        }).ToListAsync();
            }
            return distritos;
        }

        public static async Task<Distrito> GetByIdAsync(int id)
        {
            Distrito distrito = null;
            using (var context = new EscuelaDBContext())
            {
                var d = await context.Distritos
                    .Include(_distrito => _distrito.Municipios)
                    .Include(_distrito => _distrito.Municipios.Departamentos)
                    .Include(_distrito => _distrito.Municipios.Departamentos.Paises)
                    .FirstOrDefaultAsync(_distrito => _distrito.ID_Distrito == id);

                if (d != null)
                {
                    distrito = new Distrito();
                    distrito.Id = d.ID_Distrito;
                    distrito.Nombre = d.Distrito;
                    distrito.IdMunicipio = d.ID_Municipio;
                    distrito.IdDepartamento = d.Municipios.ID_Departamento;
                    distrito.IdPais = d.Municipios.Departamentos.ID_Pais;
                }
            }
            return distrito;
        }

        public async Task<bool> SaveAsync()
        {  
            bool result = false;
            using (var context = new EscuelaDBContext())
            {
                var distrito = new Distritos
                {
                    Distrito = this.Nombre,
                    ID_Municipio = this.IdMunicipio
                };
                context.Distritos.Add(distrito);
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
                var distrito = await context.Distritos
                    .Where(d => d.ID_Distrito == this.Id)
                    .FirstOrDefaultAsync();

                if (distrito != null)
                {
                    distrito.Distrito = this.Nombre;
                    distrito.ID_Municipio = this.IdMunicipio;
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
                var distrito = await context.Distritos
                    .Where(d => d.ID_Distrito == this.Id)
                    .FirstOrDefaultAsync();
                if (distrito != null)
                {
                    context.Distritos.Remove(distrito);
                    int row = await context.SaveChangesAsync();
                    result = row > 0;
                }
            }
            return result;
        }

    }
}
