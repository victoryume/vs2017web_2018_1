﻿using App.UI.Web.MVC.App_Start;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace App.UI.Web.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Configurando el componente de log4net
            log4net.Config.XmlConfigurator.Configure();

            //Configurando el AutoMapper
            Mappers.MappingDTO();

            //Aplicando Inyección por dependencia
            DIConfig.ConfigureInjector(); 

        }
    }
}
