﻿using section_7_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace section_7_Entity.ViewModels
{
    public class AddressViewModel
    {
        public string AddressDesc { get; set; }
        public  Users User { get; set; }
    }
}