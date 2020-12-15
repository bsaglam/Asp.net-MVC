using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _99_Ajax_ActionLink.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult LoadData()
        {
            List<String> list = new List<string>() {"burcu","saglam","ali" };

            return PartialView("_ListPartial",list);
        }
    }
}