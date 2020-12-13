using Section15_Filters.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Section15_Filters.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [ActionFilterClass]
        public ActionResult Index2()
        {
            //İndex2 ye girince ve çıkınca log tablosuna kayıt atması beklenir.
            return View();
        }
    }
}