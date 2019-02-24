using App.Domain.Services.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class UnidadMedidaController : Controller
    {

        private readonly IUnidadMedidaService unidadMedidaServices;

        public UnidadMedidaController(IUnidadMedidaService pUnidadMedidaServices) {
            unidadMedidaServices = pUnidadMedidaServices;
        }

        // GET: UnidadMedida
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Buscar(string filterByName)
        {

            filterByName = filterByName != null ? filterByName : "";

            var model = unidadMedidaServices.GetAll(filterByName);

            return PartialView("IndexListado", model);
        }

        public ActionResult Create() {
            return PartialView("Save");
        }

        [HttpPost]
        public ActionResult Create(UnidadMedida model) {

            var result = unidadMedidaServices.Save( model );

            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            var model = unidadMedidaServices.GetById( id );
            return View("Save",model);
        }

        [HttpPost]
        public ActionResult Edit(UnidadMedida model)
        {

            var result = unidadMedidaServices.Save(model);

            return RedirectToAction("index");
        }

    }
}