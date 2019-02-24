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
    public class MarcaController : BaseController
    {

        private readonly IMarcaService marcaServices;

        public MarcaController(IMarcaService pMarcaServices) {
            marcaServices = pMarcaServices;
        }

        // GET: Marca
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Buscar(string filterByName)
        {

            filterByName = filterByName != null ? filterByName : "";

            var model = marcaServices.GetAll(filterByName);

            return PartialView("IndexListado", model);
        }


        public ActionResult Create() {
            return PartialView("Save");
        }

        [HttpPost]
        public ActionResult Create( Marca model )
        {
            var result = marcaServices.Save(model);
            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            var model = marcaServices.GetById(id);
            return View("Save",model);
        }

        [HttpPost]
        public ActionResult Edit(Marca model)
        {
            var result = marcaServices.Save(model);
            return RedirectToAction("index");
        }



    }
}