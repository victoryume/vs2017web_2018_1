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
    }
}