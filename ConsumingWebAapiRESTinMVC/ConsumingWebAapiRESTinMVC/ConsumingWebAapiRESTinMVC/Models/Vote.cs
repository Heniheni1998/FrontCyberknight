using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumingWebAapiRESTinMVC.Models
{
    public class Vote
    {
        public int  postId { get; set; }

        public VoteType VoteType { get; set; }
    }
    public enum VoteType
    {
        UPVOTE,
        DOWNVOTE
    }
}