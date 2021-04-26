using ConsumingWebAapiRESTinMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConsumingWebAapiRESTinMVC.Controllers
{
    public class CommentsController : Controller
    {
        string Baseurl = "http://localhost:8080/";

        [HttpPost]
        public async Task<ActionResult> CreateComment(Comment comment)
        {
            string Baseurl = "http://localhost:8080/";


            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiJ9.eyJzdWIiOiJ1c2VyMyJ9.Ct2xnc101d2yXl811suqXiWuYunKCpvGNDv6dsVnv0ReL44gTaB07E9LmbXCu1E5VuYx8c6amX-kiaQ23vJKoR6k6Gjj1uX9QGNPueUtbk8qdNUjUFiuZMj0SfEY8cBAgTxkRDyTQJ6SlB4gUnsi0Kh4OzqmkdAgA3SC0KwKjHfG8EY-k2BlEhG7ZkM3Yl_WWjEzujaceCzfhiA6He_M-ASkBr5InCURmdxh_l1m3OcB2jlTks3mcpQg0ztRTDALSHcP8-DMb9IvjSeVpt2Cp5qaYsFrfhAoZ8z95SL_1FNdtpk9nZYUYCvaUEnV-246alMN7fn-gEdHWywWAB1-gw");
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Add("X-Miva-API-Authorization", "MIVA xxxxxxxxxxxxxxxxxxxxxx");
                var response = await client.PostAsJsonAsync("api/comments/", comment);
            }
            return PartialView(comment);
        }
        public ActionResult CreateComment()
        {
            return PartialView();
        }
        // GET: Comments
        public ActionResult Index()
        {
            return View();
        }
    }
}