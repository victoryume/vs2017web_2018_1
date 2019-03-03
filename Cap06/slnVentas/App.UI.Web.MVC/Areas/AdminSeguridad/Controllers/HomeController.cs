using App.Domain.Services.Interfaces;
using App.UI.Web.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Areas.Seguridad.Controllers
{
    public class HomeController : BaseController
    {

        private readonly ISeguridadService seguridadServices;
        private readonly IProductoService productoService;

        public HomeController(ISeguridadService pSeguridadService, IProductoService pProductoService)
        {
            seguridadServices = pSeguridadService;
            productoService = pProductoService;
        }

        // GET: Seguridad/Home
        public ActionResult Index()
        {
            var model = seguridadServices.GetAll("");

            return View(model);
        }

        public ActionResult Buscar(string filterByName)
        {

            filterByName = filterByName != null ? filterByName : "";

            var model = seguridadServices.GetAll(filterByName);

            return PartialView("IndexListado", model);
        }
    }
}