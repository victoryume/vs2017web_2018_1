using App.Domain.Services;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using App.UI.Web.MVC.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    [LoggingFilter]
    [HandleCustomError]
    public class ProductoController : Controller
    {
        private readonly IProductoService productoService;
        private readonly ICategoriaService categoriaService;
        private readonly IMarcaService marcaService;
        private readonly IUnidadMedidaService unidadMedidaService;

        public ProductoController()
        {
            productoService = new ProductoService();
            categoriaService = new CategoriaService();
            marcaService = new MarcaService();
            unidadMedidaService = new UnidadMedidaService();
        }

        // GET: Producto
        public ActionResult Index(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName)? "" : filterByName.Trim();
            ViewBag.filterByName = filterByName;
            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");


            var model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);
            return View(model);
        }

        // GET: Producto
        public ActionResult Index2(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();
            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");

            throw new Exception("Lanzando un error simulado");

            return View();
        }

        public ActionResult Index3(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();
            //ViewBag.filterByName = filterByName;
            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");
            //var model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);
            return View();
        }

        public ActionResult Index2Buscar(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();

            var model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);
            
            return PartialView("Index2Resultado", model);
        }

        public JsonResult Index3Buscar(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();

            var model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);

            JsonSerializerSettings config = new JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore };

            var model2 = JsonConvert.SerializeObject(model, Formatting.Indented, config);

            return Json(model2);
        }


        public ActionResult Create()
        {
            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");
            ViewBag.UnidadMedida = unidadMedidaService.GetAll("");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto model)
        {
            var result = productoService.Save(model);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");
            ViewBag.UnidadMedida = unidadMedidaService.GetAll("");

            var model = productoService.GetById(id);
            return View("Create", model);

        }

        [HttpPost]
        public ActionResult Edit(Producto model)
        {
            var result = productoService.Save(model);

            return RedirectToAction("Index");
        }
    }
}