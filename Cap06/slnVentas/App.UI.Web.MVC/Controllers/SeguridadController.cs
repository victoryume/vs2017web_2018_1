using App.Domain.Services.Interfaces;
using App.UI.Web.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers
{
    public class SeguridadController : BaseController
    {

        private readonly ISeguridadService seguridadService;

        public SeguridadController(ISeguridadService pSeguridadService)
        {
            seguridadService = pSeguridadService;
        }

        [AllowAnonymous]//Esla única acción con acceso público sin seguridad
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var usuario = seguridadService.VerificarUsuario(model.Login, model.Password);

            if (usuario != null)
            {
                //Ingreso a la aplicación
            }
            else
            {
                model.MemsajeValidacion = "Usuario no resgistrado en el sistema";
                return View(model);
            }

            return View();
        }

    }
}