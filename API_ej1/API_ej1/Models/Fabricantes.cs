﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ej1.Models
{
    public class Fabricantes
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public ICollection<Articulos> Articulos { get; set; }
    }
}
