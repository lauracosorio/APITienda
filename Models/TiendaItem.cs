﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    public class TiendaItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set;  }

    }
}
