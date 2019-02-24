using App.Domain.Services.Interfaces;
using App.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Entities.Base;
using App.UI.Web.MVC.ModelBinders;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class CategoriaController : Controller
    {

        private readonly ICategoriaService categoriaServices;



        public CategoriaController(ICategoriaService pCategoriaServices) {
            categoriaServices = pCategoriaServices;
        }

        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buscar(string filterByName) {

            filterByName = filterByName != null ? filterByName : "";

            var model = categoriaServices.GetAll(filterByName);

            return PartialView("IndexListado",model);
        }

        public ActionResult Create() {
            return PartialView();
        }

        //[HttpPost]
        //public ActionResult Create( Categoria model )
        //{
        //    var result = categoriaServices.Save(model);

        //    return RedirectToAction("index");            
        //}

        [HttpPost]
        public ActionResult Create(
            [ModelBinder(binderType:typeof(CategoriaBinder))] Categoria model )
        {
            var result = categoriaServices.Save(model);

            return RedirectToAction("index");
        }

        public ActionResult Edit(int id) {

            var model = categoriaServices.GetById(id);

            return View("Create",model);
        }

        [HttpPost]
        public ActionResult Edit(Categoria model)
        {
            var result = categoriaServices.Save(model);
            return RedirectToAction("index");
        }

    }
}