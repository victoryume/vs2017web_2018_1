using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.UI.Web.MVC.Models.ViewModels
{
    public class ProductoSearchViewModel
    {
        public string filterByName { set; get; }
        public int filterByCategoria { set; get; }
        public int filterByMarca { set; get; }
        public List<Categoria> Categorias { get; set; }
        public List<Marca> Marcas { get; set; }
        public List<Producto> Productos { get; set; }

    }
}