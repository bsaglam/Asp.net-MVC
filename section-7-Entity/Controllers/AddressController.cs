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
    public class AddressController : Controller
    {
        // GET: Address
        public ActionResult AddAddress()
        {
            DatabaseContext db = new DatabaseContext();
            List<SelectListItem> userList = (from user in db.UsersEntity.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = user.Name,
                                                 Value = user.Id.ToString()
                                             }).ToList();
            ViewBag.UserList = userList;
            //Bunu post metodunda değerini kullanabilmek için kullanacağız.
            TempData["UserList"] = ViewBag.UserList;
            return View();
        }

        [HttpPost]
        public ActionResult AddAddress(AddressViewModel model)
        {
            DatabaseContext db = new DatabaseContext();
            //1-seçilen Id ye karşılık gelen kullanıcını bilgilerini adres sayfasından gelen modele ekliyoruz.2.aşamada
            Users user = db.UsersEntity.Where(x => x.Id == model.User.Id).FirstOrDefault();
            if (user != null)
            {
                model.User = user; //2.aşama
                Addresses address = new Addresses()
                {
                    AddressDesc = model.AddressDesc,
                    User = model.User
                };
                db.AddressEntity.Add(address);
                var result = db.SaveChanges();
            }
            

            //sadece yukarıdaki işlemleri yaptıgımızda patlayacaktır.
            //çünkü viewBag'in ömrü sadece 1 action Lıktır.HttpPost metdounada gönderilmiş olsa da değeri kaybolur
            ViewBag.UserList = TempData["UserList"];
            return View();
        }



        public ActionResult EditAddress(int? addressId)
        {
            AddressViewModel model = null;
            DatabaseContext db = new DatabaseContext();
            List<SelectListItem> userList = (from user in db.UsersEntity.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = user.Name,
                                                 Value = user.Id.ToString()
                                             }).ToList();


            if (addressId != null)
            {
                Addresses address = new Addresses();
                address = db.AddressEntity.Where(x => x.Id == addressId).FirstOrDefault();
                model = new AddressViewModel()
                {
                    AddressDesc=address.AddressDesc,
                    User=address.User
                };
                
                ViewBag.UserList = userList;
                //Bunu post metodunda değerini kullanabilmek için kullanacağız.
                TempData["UserList"] = ViewBag.UserList;
            }

            
            return View(model);
        }


        [HttpPost]
        public ActionResult EditAddress(AddressViewModel model,int? addressId)
        {
            int result = 0;
            if (model != null)
            {
                DatabaseContext db = new DatabaseContext();
                Users user = new Users();
                user = db.UsersEntity.Where(x => x.Id == model.User.Id).FirstOrDefault();
                Addresses address = new Addresses();
                address = db.AddressEntity.Where(x => x.Id == addressId).FirstOrDefault();
                address.AddressDesc = model.AddressDesc;
                address.User = user;
                 
                result=db.SaveChanges();

                ViewBag.UserList = TempData["UserList"];
            }
            ViewBag.Result = (result > 0) ? "success" : ViewBag.result = "danger";
            return View();
        }
    }
}