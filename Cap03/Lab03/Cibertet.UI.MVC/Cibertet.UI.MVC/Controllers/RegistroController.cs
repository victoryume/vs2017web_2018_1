using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cibertet.UI.MVC.Models;

namespace Cibertet.UI.MVC.Controllers
{
    public class RegistroController : Controller
    {
        
        [HttpPost]
        public JsonResult Registro(PersonaViewModel persona)
        {
            persona.FullName = persona.Nombres + " " + persona.Apellidos;

            return Json(persona);

        }
    }
}