using System;
using System.Linq;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.DataBase.Test
{
    [TestClass]
    public class CategoriaTest
    {
        [TestMethod]
        public void NuevaCategoria()
        {
            
            using (var model = new AppModel()) {

                var categoria = new Categoria()
                {
                    Nombre = "Mouse",
                    Estado = true
                };

                model.Categoria.Add(categoria);
                model.SaveChanges();//Es requerido para confirma la transaccion de EF

                //Verificando que se esté creando la categoría
                Assert.IsTrue(categoria.CategoriaID > 0);

            }
        }

        [TestMethod]
        public void VerificarRegistros() {

            using (var model = new AppModel()) {

                var cantidad = model.Categoria.Count();

                Assert.IsTrue(cantidad > 0);
            }

        }

    }
}
