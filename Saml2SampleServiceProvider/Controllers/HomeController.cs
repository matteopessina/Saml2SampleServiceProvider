using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Saml2SampleServiceProvider.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [Authorize]
        public ActionResult Secure()
        {
            var identity = System.Web.HttpContext.Current.User.Identity as ClaimsIdentity;
            return View(identity.Claims);
        }

        [Authorize(Roles ="Administrator")]
        public ActionResult AdminOnly()
        {
            return View();
        }

    }
}
