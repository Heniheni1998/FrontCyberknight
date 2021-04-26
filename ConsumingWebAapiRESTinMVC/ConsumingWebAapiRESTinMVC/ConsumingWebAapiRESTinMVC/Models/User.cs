using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumingWebAapiRESTinMVC.Models
{
    public class User
    {
        public string created { get; set; }
        public string email { get; set; }
        public bool enabled { get; set; }
        public string password { get; set; }
        public int userId { get; set; }
        public string username { get; set; }
    }
}