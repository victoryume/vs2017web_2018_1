﻿using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Interfaces
{
    public interface IProductoService
    {
        IEnumerable<Producto> GetAll(String nombre, int? categoriaID,int? marcaID);
        bool Save(Producto entity);
        Producto GetById(int id);
        ListaPaginada<ProductoSearch> BuscarProductosStock(ProductoSearchFiltros filtros);
    }
}
