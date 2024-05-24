using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Catalogos
{
    public class Genero
    {

        public string Id { get; set; }
        public string Nombre { get; set; } 

        private static List<Genero> generos = new List<Genero>()
        {
            new Genero { Id = "1", Nombre = "Hombre" },
            new Genero { Id = "2", Nombre = "Mujer" },
            new Genero { Id = "3", Nombre = "Otro" }
        };


        public static List<Genero> Get()
        {
            return generos;
        } 
    }
}
