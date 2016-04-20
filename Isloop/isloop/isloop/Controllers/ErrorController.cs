using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace isloop.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = 200;
            return View("404");
        }

        public ActionResult InternalServerError()
        {
            Response.StatusCode = 200;
            return View("500");
        }
    }
}