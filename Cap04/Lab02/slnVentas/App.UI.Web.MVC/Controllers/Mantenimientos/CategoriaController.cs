using App.Domain.Services;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService categoriaService;

        public CategoriaController()
        {
            categoriaService = new CategoriaService();
        }

        // GET: Categoria
        public ActionResult Index()
        {
            var model = categoriaService.GetAll("");
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria model)
        {
            var result = categoriaService.Save(model);
                        
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}