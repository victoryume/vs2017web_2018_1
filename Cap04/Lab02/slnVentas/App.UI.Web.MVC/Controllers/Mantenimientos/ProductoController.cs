using App.Domain.Services;
using App.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class ProductoController : Controller
    {
        private readonly IProductoService productoService;

        public ProductoController()
        {
            productoService = new ProductoService();
        }

        // GET: Producto
        public ActionResult Index()
        {
            var model = productoService.GetAll("");
            return View(model);
        }
    }
}