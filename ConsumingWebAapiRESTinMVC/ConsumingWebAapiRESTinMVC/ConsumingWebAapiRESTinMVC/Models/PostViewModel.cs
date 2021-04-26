using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumingWebAapiRESTinMVC.Models
{
    public class PostViewModel
    {
        public PostModel postModel { get; set; }
        public IEnumerable<CommentPayload> CommentPayloads { get; set; }

        public Comment comment { get; set; }
    }
}