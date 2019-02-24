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
    public class MarcaService : IMarcaService
    {
        public IEnumerable<Marca> GetAll(string nombre)
        { 
            List<Marca> result;

            using (var unitOfWork = new AppUnitOfWork()) {
                result = unitOfWork.MarcaRepository.GetAll( 
                    item => item.Nombre.Contains(nombre)
                ).ToList();
            }

            return result;
        }

        public Marca GetById(int id)
        {
            Marca result;

            using (var unitOfWork = new AppUnitOfWork())
            {
                result = unitOfWork.MarcaRepository.GetById( id );
            }

            return result;
        }

        public bool Save(Marca marca)
        {
            bool result = false;
            try
            {
                using (var unitOfWork = new AppUnitOfWork())
                {
                    if (marca.MarcaID == 0)
                    {
                        unitOfWork.MarcaRepository.Add( marca );
                    }
                    else {
                        unitOfWork.MarcaRepository.Update(marca);
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
