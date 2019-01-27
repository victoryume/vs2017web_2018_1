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

            List<Categoria> result;

            using (var unitOfWork = new AppUnitOfWork())
            {
                result = unitOfWork.CategoriaRepository.GetAll(
                    item => item.Nombre.Contains(nombre)
                    ).ToList();
            }

            return result;

        }

        public Categoria GetById(int id)
        {
            Categoria result;

            using (var unitOfWork = new AppUnitOfWork())
            {
                result = unitOfWork.CategoriaRepository.GetById(id);
            }

            return result;
        }

        public bool Save(Categoria entity)
        {
            bool result = false;

            try
            {

                using (var unitOfWork = new AppUnitOfWork())
                {

                    if (entity.CategoriaID == 0)//registro nuevo
                    {
                        unitOfWork.CategoriaRepository.Add(entity);
                    }
                    else
                    {
                        unitOfWork.CategoriaRepository.Update(entity);
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
