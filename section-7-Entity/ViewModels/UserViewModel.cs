using section_7_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace section_7_Entity.ViewModels
{
    public class UserViewModel
    {
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        public  List<Addresses> Address { get; set; }
    }
}