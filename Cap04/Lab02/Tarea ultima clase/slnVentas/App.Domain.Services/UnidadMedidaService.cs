using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Repository;
using App.Entities.Base;

namespace App.Domain.Services.Interfaces
{
    public class UnidadMedidaService : IUnidadMedidaService
    { 
        public IEnumerable<UnidadMedida> GetAll(string nombre)
        {
            List<UnidadMedida> result;
            using (var unitOfWork = new AppUnitOfWork())
            {
                result = unitOfWork.UnidadMedidaRepository.GetAll(
                    item => item.Nombre.Contains(nombre)
                ).ToList();
            }

            return result;
        }

        public UnidadMedida GetById(int id)
        {
            UnidadMedida result;
            using (var unitOfWork = new AppUnitOfWork())
            {
                result = unitOfWork.UnidadMedidaRepository.GetById(id);
            }

            return result;
        }

        public bool Save(UnidadMedida entity)
        {
            bool result = false;

            try
            {
                using (var unitOfWork = new AppUnitOfWork())
                {
                    if (entity.UnidadMedidaID == 0 )
                    {
                        unitOfWork.UnidadMedidaRepository.Add( entity );
                    }
                    else
                    {
                        unitOfWork.UnidadMedidaRepository.Update( entity );
                    }

                    unitOfWork.Complete();
                }
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
}
