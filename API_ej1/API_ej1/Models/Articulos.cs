using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ej1.Models
{
    public class Articulos
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int IdFabricante { get; set; }
        public Fabricantes Fabricante { get; set; }
    }
}
