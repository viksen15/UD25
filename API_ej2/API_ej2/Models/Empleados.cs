using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ej2.Models
{
    public class Empleados
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int IdDepartamentos { get; set; }
        public Departamentos Departamentos { get; set; }
    }
}
