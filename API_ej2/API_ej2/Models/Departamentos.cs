using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ej2.Models
{
    public class Departamentos
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Presupuesto { get; set; }
        public ICollection<Empleados> Empleados { get; set; }
    }
}
