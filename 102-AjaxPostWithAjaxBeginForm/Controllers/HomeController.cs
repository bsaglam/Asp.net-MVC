using _102_AjaxPostWithAjaxBeginForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _102_AjaxPostWithAjaxBeginForm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new ToDoItem());
        }

        public PartialViewResult AddData(ToDoItem model)
        {
            return PartialView("_ToDoListPartial", model);
        }
    }
}