using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaDS.CLS.Dtos
{
    public class GrupoTree
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public class Node
        {
            public int Id { get; set; }
            public string Detalle { get; set; }
        } 

        public Node Profesor { get; set; }

        public List<Node> Estudies { get; set; }
    }
}
