using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Section15_Filters.Filters
{
    public class Authorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //burası actionlardan önce çalışır ve sign in yapılmış mı kontrol eder.
            //sign in yapılmadıysa yönlendirilecek olan sayfa burda çalışır.
            if (filterContext.HttpContext.Session["user"] == null)
            {
                //giriş yapılmadıysa kullanıcı Login sayfasına yönlendirilmeli.
                filterContext.Result = new RedirectResult("/Login/SignIn");
            }
           
        }
    }
}