﻿using App.Domain.Services;
using App.Domain.Services.Interfaces;
using Newtonsoft.Json;
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
        private readonly ICategoriaService categoriaService;
        private readonly IMarcaService marcaService;

        public ProductoController()
        {
            productoService = new ProductoService();
            categoriaService = new CategoriaService();
            marcaService = new MarcaService();
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
            //ViewBag.filterByName = filterByName;
            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");
            //var model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);
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
    }
}