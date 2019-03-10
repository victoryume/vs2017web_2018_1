﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Queries
{
    public class ProductoSearchFiltros
    {
        public string Nombre { get; set; }

        public decimal Stock { get; set; }

        public int CurrentPagina { get; set; }

        public int PageSize { get; set; }
    }
}
