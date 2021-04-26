using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumingWebAapiRESTinMVC.Models
{
    public class Comment
    {
        public int postId { get; set; }
        public string text { get; set; }
        public string userName { get; set; }
    }
}