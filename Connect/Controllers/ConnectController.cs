using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace Connect.Controllers
{
    public class ConnectController : Controller
    {   
        public ActionResult Index()
        {
            return View();  
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Connect");
        }
    }
}