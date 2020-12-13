using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Section15_Filters.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            return View(new Users());
        }
       
        [HttpPost]
        public ActionResult SignIn(Users model)
        {
            FilterSampleEntities db = new FilterSampleEntities();
            Users user = null;
            if (model != null)
            {
                user = db.Users.FirstOrDefault(m => m.UserName == model.UserName && m.Password == model.Password);
                if (user != null)
                {
                    Session["user"] = user;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı yada şifre hatalı!");
                    return View();
                }
               
            }
            else
            {
                return View();
            }
            
        }
    }
}