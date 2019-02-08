using App.Data.DataBase;
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
        public IEnumerable<Producto> GetAll(string nombre, int? categoriaID, int? marcaID)
        {

            List<Producto> result;
           
            using (var unitOfWork = new AppUnitOfWork())
            {
                result = unitOfWork.ProductoRepository.GetAll(
                    item => item.Nombre.Contains(nombre) 
                    && (categoriaID == null ||item.CategoriaID== categoriaID)
                    && (marcaID == null || item.MarcaID == marcaID)
                    , "Categoria,Marca"
                    ).ToList();
            }

            return result;

        }

        public Producto GetById(int id)
        {
            Producto result;

            using (var unitOfWork = new AppUnitOfWork())
            {
                result = unitOfWork.ProductoRepository.GetById(id);
            }

            return result;
        }

        public bool Save(Producto entity)
        {
            bool result = false;

            try
            {

                using (var unitOfWork = new AppUnitOfWork())
                {

                    if (entity.ProductoID == 0)//registro nuevo
                    {
                        unitOfWork.ProductoRepository.Add(entity);
                    }
                    else
                    {
                        unitOfWork.ProductoRepository.Update(entity);
                    }

                    unitOfWork.Complete();

                }

                result = true;
            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }

    }
}
