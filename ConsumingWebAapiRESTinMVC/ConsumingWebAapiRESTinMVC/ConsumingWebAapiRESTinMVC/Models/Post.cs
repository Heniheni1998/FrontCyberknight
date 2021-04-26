using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConsumingWebAapiRESTinMVC.Models
{
    public class Post
    {
     
        public int postId { get; set; }

    
        public string title { get; set; }

        public string description { get; set; }

        [Display(Name = "Upload pilote picture")]
        [StringLength(2000)]
        public string image { get; set; }









    }
}