﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ej4.Models
{
    public class Peliculas
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int CalificacionEdad { get; set; }
        public Salas Salas { get; set; }
    }
}
