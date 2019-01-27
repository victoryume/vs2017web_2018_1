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
    public class CategoriaService : ICategoriaService
    {
        public IEnumerable<Categoria> GetAll(string nombre)
        {

            List<Categoria> results;
            
            using (var unitOfWork = new AppUnitOfWork())
            {
                results = unitOfWork.CategoriaRepository.GetAll(
                    item => item.Nombre.Contains(nombre)
                    ).ToList();
            }

            return results;

        }

        public bool Save(Categoria entity)
        {
            bool result = false;

            try
            {

                if (entity.CategoriaID == 0)//registro nuevo
                {
                    using (var unitOfWork = new AppUnitOfWork())
                    {
                        unitOfWork.CategoriaRepository.Add(entity);
                        unitOfWork.Complete();
                    }
                }
                else//edición
                {
                    
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
