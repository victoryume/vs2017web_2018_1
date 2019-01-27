using System;
using App.Data.DataBase;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Repository.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExistenRegistros()
        {
            var model = new AppModel();
            using (var unitOfWork = new AppUnitOfWork(model))
            {
                var cantidad = unitOfWork.CategoriaRepository.Count();

                Assert.IsTrue(cantidad > 0);

            }
           
        }

        [TestMethod]
        public void NuevaCategoria()
        {
            var model = new AppModel();

            using (var unitOfWork = new AppUnitOfWork(model))
            {

                var categoria = new Categoria()
                {
                    Nombre = "Mouse",
                    Estado = true
                };

                unitOfWork.CategoriaRepository.Add(categoria);

                Assert.IsTrue(categoria.CategoriaID > 0);
                
            }
        }

    }

}
