﻿using App.UI.Web.MVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers
{
    [LoggingFilter]
    [HandleCustomError]
    public class BaseController : Controller
    {
        protected static readonly log4net.ILog log = log4net.LogManager.
        GetLogger(
            MethodBase.GetCurrentMethod().DeclaringType
        );

    }
}