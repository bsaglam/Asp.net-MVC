using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _101_ActionLink_NestedPartialView.Controllers
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
            List<string> list = new List<string>() { "burcu", "sağlam", "arthur", "sütlaç" };

            return PartialView("_ListPatialView",list);
        }

        public MvcHtmlString DeleteData(int id)
        {
            List<string> list = new List<string>() { "burcu", "sağlam", "arthur", "sütlaç" };
            list.RemoveAt(id);
            return MvcHtmlString.Empty;
        }
    }
}