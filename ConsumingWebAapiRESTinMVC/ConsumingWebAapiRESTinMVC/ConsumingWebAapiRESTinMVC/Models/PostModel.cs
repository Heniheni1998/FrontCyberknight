using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumingWebAapiRESTinMVC.Models
{
    public class PostModel
    {
        public int id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string image { get; set; }

        public int voteCount { get; set; }

        public string userName { get; set; }

        public int commentCount { get; set; }


        public string duration { get; set; }
}
}