using section_7_Entity.Context;
using section_7_Entity.Models;
using section_7_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace section_7_Entity.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult AddUser()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel model)
        {
            DatabaseContext db = new DatabaseContext();
            Users user = new Users()
            {
                Name = model.Name,
                Surname = model.Surname,
                Address = model.Address
            };
            db.UsersEntity.Add(user);
            int result = db.SaveChanges();
            ViewBag.Result = (result > 0) ? "success" : ViewBag.result = "danger";

            return View();
        }

        public ActionResult EditUser(int? userId)
        {
            DatabaseContext db = new DatabaseContext();
            Users user = db.UsersEntity.Where(x => x.Id == userId).FirstOrDefault();
            UserViewModel uvm = new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname

            };

            return View(uvm);
        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel model,int? userId)
        {
            DatabaseContext db = new DatabaseContext();
            Users user = db.UsersEntity.Where(x => x.Id == userId).FirstOrDefault();
            if (user != null)
            {
                user.Name = model.Name;
                user.Surname = model.Surname;
               
            }
            int result = db.SaveChanges();
            ViewBag.Result = (result > 0) ? "success" : ViewBag.result = "danger";
            return View();
        }
    }
}