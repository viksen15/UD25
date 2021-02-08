using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ej3.Models
{
    public class Almacenes
    {
        public int Codigo { get; set; }
        public string Lugar { get; set; }
        public int Capacidad { get; set; }
        public ICollection<Cajas> Cajas { get; set; }
    }
}
