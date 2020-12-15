using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Section15_Filters.Filters
{
    public class ActionFilterClass : FilterAttribute, IActionFilter
    {
        FilterSampleEntities db = new FilterSampleEntities();
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            db.Logs.Add(new Logs()
            {
                ActionName = filterContext.ActionDescriptor.ActionName,
                ControllerName= filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                UserName=(filterContext.HttpContext.Session["user"] as Users).UserName,
                Date=DateTime.Now,
                Description="Action'dan çıkıyor"
            }) ;
            db.SaveChanges();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            db.Logs.Add(new Logs()
            {
                ActionName = filterContext.ActionDescriptor.ActionName,
                ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                UserName = (filterContext.HttpContext.Session["user"] as Users).UserName,
                Date = DateTime.Now,
                Description = "Action'a giriyor."
            });
            db.SaveChanges();
        }
    }
}