using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ej4.Models
{
    public class Salas
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int IdPelicula { get; set; }
        public ICollection<Peliculas> Peliculas { get; set; }
    }
}
