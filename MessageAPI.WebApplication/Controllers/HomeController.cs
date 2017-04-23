using MessageAPI.Core;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageAPI.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        [Dependency]
        public IRequestFacade RequestFacade
        {
            get;
            set;
        }

        public ActionResult Index()
        {
            ViewBag.Message = RequestFacade.GetMessage();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}