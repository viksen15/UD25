using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ej3.Models
{
    public class Cajas
    {
        public string NumReferencia { get; set; }
        public string Contenido { get; set; }
        public int Valor { get; set; }
        public int IdAlmacen { get; set; }
        public Almacenes Almacenes { get; set; }
    }
}
