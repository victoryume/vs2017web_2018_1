﻿using App.Data.DataBase;
using App.Data.Repository;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class ProductoService : IProductoService
    {
        public IEnumerable<Producto> GetAll(string nombre)
        {

            List<Producto> result;
           
            using (var unitOfWork = new AppUnitOfWork())
            {
                result = unitOfWork.ProductoRepository.GetAll(
                    item => item.Nombre.Contains(nombre), "Categoria,Marca"
                    ).ToList();
            }

            return result;

        }

    }
}