using App.Domain.Services;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using App.UI.Web.MVC.Filters;
using App.UI.Web.MVC.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    [Authorize(Roles = "Admin")]
    public class ProductoController : BaseController
    {
        private readonly IProductoService productoService;
        private readonly ICategoriaService categoriaService;
        private readonly IUnidadMedidaService unidadMedidaService;
        private readonly IMarcaService marcaService;

        public ProductoController(
            IProductoService pProductoService,
            ICategoriaService pCategoriaService,
            IUnidadMedidaService pUnidadMedidaService,
            IMarcaService pMarcaService)
        {
            productoService = pProductoService;
            categoriaService = pCategoriaService;
            unidadMedidaService = pUnidadMedidaService;
            marcaService = pMarcaService;
        }

        //GET: Producto
        public ActionResult Index(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName;
            ViewBag.filterByName = filterByName;
            ViewBag.categorias = categoriaService.GetAll("");
            ViewBag.marcas = marcaService.GetAll("");

            var model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);

            return View(model);
        }

        public ActionResult IndexVM(ProductoSearchViewModel model)
        {
            model.FilterByName = string.IsNullOrWhiteSpace(model.FilterByName) ? "" : model.FilterByName;

            model.Categorias = categoriaService.GetAll("");
            model.Marcas = marcaService.GetAll("");
            model.Productos = productoService.GetAll(
                model.FilterByName,
                model.FilterByCategoria,
                model.FilterByMarca
            );

            //model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);

            return View(model);
        }

        //GET: Producto
        public ActionResult Index2(string filterByName, int? filterByCategoria, int? filterByMarca)
        {

            ViewBag.categorias = categoriaService.GetAll("");
            ViewBag.marcas = marcaService.GetAll("");

            return View();
        }


        public ActionResult Index2Buscar(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName;
            var model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);

            return PartialView("Index2Resultado", model);
        }


        public ActionResult Index3(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            try
            {
                ViewBag.categorias = categoriaService.GetAll("");
                ViewBag.marcas = marcaService.GetAll("");                
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return View();
        }


        public JsonResult Index3Buscar(string filterByName, int? filterByCategoria, int? filterByMarca)
        {

            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName;

            var model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);

            JsonSerializerSettings config = new JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };

            var model2 = JsonConvert.SerializeObject(model, Formatting.Indented, config);

            return Json(model2);
        }

        public ActionResult Create()
        {
            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.UnidadesMedida = unidadMedidaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");

            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Producto model)
        {
            model.FechaCreacion = DateTime.Now;
            model.UsuarioCreador = new Guid("FCAE7105-0886-4944-853C-90F3C7892134");

            var resutl = productoService.Save(model);

            return RedirectToAction("Index4");
        }


        public ActionResult Edit(int id)
        {
            var model = productoService.GetById(id);

            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.UnidadesMedida = unidadMedidaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");

            return View("Save", model);

        }

        [HttpPost]
        public ActionResult Edit(Producto model)
        {
            model.FechaModificacion = DateTime.Now;
            model.UsuarioModificador = new Guid("FCAE7105-0886-4944-853C-90F3C7892134");

            var result = productoService.Save(model);

            return RedirectToAction("Index3");
        }

        // GET: Categoria
        public ActionResult Index4()
        {
            return View("IndexAjax");
        }

        //public JsonResult Index3Buscar(string filterByName, int? filterByCategoria, int? filterByMarca)
        //{

        //    filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName;

        //    var model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);

        //    JsonSerializerSettings config = new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //    };

        //    var model2 = JsonConvert.SerializeObject(model, Formatting.Indented, config);

        //    return Json(model2);
        //}

        public ActionResult Buscar(string filterByName, int? filterByCategoria, int? filterByMarca)
        {

            filterByName = filterByName != null ? filterByName : "";

            var model = productoService.GetAll(filterByName,filterByCategoria,filterByMarca);

            return PartialView("IndexListado", model);
        }

    }
}