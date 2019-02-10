using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace App.UI.Web.MVC.ModelBinders
{
    public class CategoriaBinders : IModelBinder
    {
        public bool BindModel(ModelBindingExecutionContext modelBindingExecutionContext, ModelBindingContext bindingContext)
        {
            Categoria model = new Categoria();
            var request = HttpContext.Current.Request;
            bindingContext.Model = model;

            return true;
        }
    }
}