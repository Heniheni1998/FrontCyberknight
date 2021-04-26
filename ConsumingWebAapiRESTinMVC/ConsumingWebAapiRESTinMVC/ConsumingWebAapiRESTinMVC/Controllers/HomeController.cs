using ConsumingWebAapiRESTinMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConsumingWebAapiRESTinMVC.Controllers
{
    public class HomeController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "http://localhost:8080/";
        public async Task<ActionResult> Index()
        {
            List<PostModel> EmpInfo = new List<PostModel>();

            using (var client = new HttpClient())
            {
                //Passing service base url 
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiJ9.eyJzdWIiOiJ1c2VyMyJ9.Ct2xnc101d2yXl811suqXiWuYunKCpvGNDv6dsVnv0ReL44gTaB07E9LmbXCu1E5VuYx8c6amX-kiaQ23vJKoR6k6Gjj1uX9QGNPueUtbk8qdNUjUFiuZMj0SfEY8cBAgTxkRDyTQJ6SlB4gUnsi0Kh4OzqmkdAgA3SC0KwKjHfG8EY-k2BlEhG7ZkM3Yl_WWjEzujaceCzfhiA6He_M-ASkBr5InCURmdxh_l1m3OcB2jlTks3mcpQg0ztRTDALSHcP8-DMb9IvjSeVpt2Cp5qaYsFrfhAoZ8z95SL_1FNdtpk9nZYUYCvaUEnV-246alMN7fn-gEdHWywWAB1-gw");


                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/posts/");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<List<PostModel>>(EmpResponse);

                }
                //returning the employee list to view  
                return View(EmpInfo);
            }
        }
        public async Task<ActionResult> PostsByUser(string name)
        {
            List<PostModel> EmpInfo = new List<PostModel>();

            using (var client = new HttpClient())
            {
                //Passing service base url 
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiJ9.eyJzdWIiOiJ1c2VyMyJ9.Ct2xnc101d2yXl811suqXiWuYunKCpvGNDv6dsVnv0ReL44gTaB07E9LmbXCu1E5VuYx8c6amX-kiaQ23vJKoR6k6Gjj1uX9QGNPueUtbk8qdNUjUFiuZMj0SfEY8cBAgTxkRDyTQJ6SlB4gUnsi0Kh4OzqmkdAgA3SC0KwKjHfG8EY-k2BlEhG7ZkM3Yl_WWjEzujaceCzfhiA6He_M-ASkBr5InCURmdxh_l1m3OcB2jlTks3mcpQg0ztRTDALSHcP8-DMb9IvjSeVpt2Cp5qaYsFrfhAoZ8z95SL_1FNdtpk9nZYUYCvaUEnV-246alMN7fn-gEdHWywWAB1-gw");


                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/posts/by-user/"+name);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<List<PostModel>>(EmpResponse);

                }
                //returning the employee list to view  
                return View(EmpInfo);
            }
        }
        public async Task<ActionResult> PostsById(int id)
        {
            PostViewModel viewModel = new PostViewModel();
            PostModel EmpInfo = new PostModel();
            List<CommentPayload> Comments = new List<CommentPayload>();

            using (var client = new HttpClient())
            {
                //Passing service base url 
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiJ9.eyJzdWIiOiJ1c2VyMyJ9.Ct2xnc101d2yXl811suqXiWuYunKCpvGNDv6dsVnv0ReL44gTaB07E9LmbXCu1E5VuYx8c6amX-kiaQ23vJKoR6k6Gjj1uX9QGNPueUtbk8qdNUjUFiuZMj0SfEY8cBAgTxkRDyTQJ6SlB4gUnsi0Kh4OzqmkdAgA3SC0KwKjHfG8EY-k2BlEhG7ZkM3Yl_WWjEzujaceCzfhiA6He_M-ASkBr5InCURmdxh_l1m3OcB2jlTks3mcpQg0ztRTDALSHcP8-DMb9IvjSeVpt2Cp5qaYsFrfhAoZ8z95SL_1FNdtpk9nZYUYCvaUEnV-246alMN7fn-gEdHWywWAB1-gw");


                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/posts/" + id);
                HttpResponseMessage Res1 = await client.GetAsync("api/comments/by-post/" + id);


                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<PostModel>(EmpResponse);

                }
                if (Res1.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CommentResponse = Res1.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Comments = JsonConvert.DeserializeObject<List<CommentPayload>>(CommentResponse);

                }
                viewModel.CommentPayloads = Comments;
                viewModel.postModel = EmpInfo;

                //returning the employee list to view  
                return View(viewModel);
            }
        }
        // GET: Categories/Create
        public ActionResult Create()
        {
            return  View();
        }
   
        // POST: Categories/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Post epm)
        {
            string Baseurl = "http://localhost:8080/";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiJ9.eyJzdWIiOiJ1c2VyMyJ9.Ct2xnc101d2yXl811suqXiWuYunKCpvGNDv6dsVnv0ReL44gTaB07E9LmbXCu1E5VuYx8c6amX-kiaQ23vJKoR6k6Gjj1uX9QGNPueUtbk8qdNUjUFiuZMj0SfEY8cBAgTxkRDyTQJ6SlB4gUnsi0Kh4OzqmkdAgA3SC0KwKjHfG8EY-k2BlEhG7ZkM3Yl_WWjEzujaceCzfhiA6He_M-ASkBr5InCURmdxh_l1m3OcB2jlTks3mcpQg0ztRTDALSHcP8-DMb9IvjSeVpt2Cp5qaYsFrfhAoZ8z95SL_1FNdtpk9nZYUYCvaUEnV-246alMN7fn-gEdHWywWAB1-gw");
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Add("X-Miva-API-Authorization", "MIVA xxxxxxxxxxxxxxxxxxxxxx");
              

                var response = await client.PostAsJsonAsync("api/posts/", epm);
                if (response.IsSuccessStatusCode) 
                {
                    return RedirectToAction("Index");
                }
           }
              return View(epm);
        }
        public ActionResult DeletePost(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiJ9.eyJzdWIiOiJ1c2VyMyJ9.Ct2xnc101d2yXl811suqXiWuYunKCpvGNDv6dsVnv0ReL44gTaB07E9LmbXCu1E5VuYx8c6amX-kiaQ23vJKoR6k6Gjj1uX9QGNPueUtbk8qdNUjUFiuZMj0SfEY8cBAgTxkRDyTQJ6SlB4gUnsi0Kh4OzqmkdAgA3SC0KwKjHfG8EY-k2BlEhG7ZkM3Yl_WWjEzujaceCzfhiA6He_M-ASkBr5InCURmdxh_l1m3OcB2jlTks3mcpQg0ztRTDALSHcP8-DMb9IvjSeVpt2Cp5qaYsFrfhAoZ8z95SL_1FNdtpk9nZYUYCvaUEnV-246alMN7fn-gEdHWywWAB1-gw");
                client.BaseAddress = new Uri("http://localhost:8080/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("api/posts/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Post epm = null;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiJ9.eyJzdWIiOiJ1c2VyMyJ9.Ct2xnc101d2yXl811suqXiWuYunKCpvGNDv6dsVnv0ReL44gTaB07E9LmbXCu1E5VuYx8c6amX-kiaQ23vJKoR6k6Gjj1uX9QGNPueUtbk8qdNUjUFiuZMj0SfEY8cBAgTxkRDyTQJ6SlB4gUnsi0Kh4OzqmkdAgA3SC0KwKjHfG8EY-k2BlEhG7ZkM3Yl_WWjEzujaceCzfhiA6He_M-ASkBr5InCURmdxh_l1m3OcB2jlTks3mcpQg0ztRTDALSHcP8-DMb9IvjSeVpt2Cp5qaYsFrfhAoZ8z95SL_1FNdtpk9nZYUYCvaUEnV-246alMN7fn-gEdHWywWAB1-gw");

                client.BaseAddress = new Uri("http://localhost:8080/");
                //HTTP GET
                var responseTask = client.GetAsync("api/posts/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Post>();
                    readTask.Wait();

                    epm = readTask.Result;
                    epm.postId = id;
                }
            }
            return View(epm);
        }


        //
        // POST: /Products/Edit/5

        [HttpPost]
        public ActionResult Edit(Post epm)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiJ9.eyJzdWIiOiJ1c2VyMyJ9.Ct2xnc101d2yXl811suqXiWuYunKCpvGNDv6dsVnv0ReL44gTaB07E9LmbXCu1E5VuYx8c6amX-kiaQ23vJKoR6k6Gjj1uX9QGNPueUtbk8qdNUjUFiuZMj0SfEY8cBAgTxkRDyTQJ6SlB4gUnsi0Kh4OzqmkdAgA3SC0KwKjHfG8EY-k2BlEhG7ZkM3Yl_WWjEzujaceCzfhiA6He_M-ASkBr5InCURmdxh_l1m3OcB2jlTks3mcpQg0ztRTDALSHcP8-DMb9IvjSeVpt2Cp5qaYsFrfhAoZ8z95SL_1FNdtpk9nZYUYCvaUEnV-246alMN7fn-gEdHWywWAB1-gw");


                //HTTP POST
                var putTask = client.PutAsJsonAsync<Post>("api/posts/"+epm.postId, epm);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(epm);
        }
        [HttpPost]
        public ActionResult CreateComment(Comment comment)
        {
            string Baseurl = "http://localhost:8080/";


            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiJ9.eyJzdWIiOiJ1c2VyMyJ9.Ct2xnc101d2yXl811suqXiWuYunKCpvGNDv6dsVnv0ReL44gTaB07E9LmbXCu1E5VuYx8c6amX-kiaQ23vJKoR6k6Gjj1uX9QGNPueUtbk8qdNUjUFiuZMj0SfEY8cBAgTxkRDyTQJ6SlB4gUnsi0Kh4OzqmkdAgA3SC0KwKjHfG8EY-k2BlEhG7ZkM3Yl_WWjEzujaceCzfhiA6He_M-ASkBr5InCURmdxh_l1m3OcB2jlTks3mcpQg0ztRTDALSHcP8-DMb9IvjSeVpt2Cp5qaYsFrfhAoZ8z95SL_1FNdtpk9nZYUYCvaUEnV-246alMN7fn-gEdHWywWAB1-gw");
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Add("X-Miva-API-Authorization", "MIVA xxxxxxxxxxxxxxxxxxxxxx");
                var postTask =  client.PostAsJsonAsync("api/comments/", comment);
                postTask.Wait();
                var result = postTask.Result;
                  if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("PostsById/"+comment.postId);
                }
                
            }
            return PartialView(comment);
        }
        public ActionResult CreateComment(int postId)
        {
            var comment = new Comment();
            comment.postId = postId;
            return PartialView();
        }
        public ActionResult DeleteComment(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiJ9.eyJzdWIiOiJ1c2VyMyJ9.Ct2xnc101d2yXl811suqXiWuYunKCpvGNDv6dsVnv0ReL44gTaB07E9LmbXCu1E5VuYx8c6amX-kiaQ23vJKoR6k6Gjj1uX9QGNPueUtbk8qdNUjUFiuZMj0SfEY8cBAgTxkRDyTQJ6SlB4gUnsi0Kh4OzqmkdAgA3SC0KwKjHfG8EY-k2BlEhG7ZkM3Yl_WWjEzujaceCzfhiA6He_M-ASkBr5InCURmdxh_l1m3OcB2jlTks3mcpQg0ztRTDALSHcP8-DMb9IvjSeVpt2Cp5qaYsFrfhAoZ8z95SL_1FNdtpk9nZYUYCvaUEnV-246alMN7fn-gEdHWywWAB1-gw");
                client.BaseAddress = new Uri("http://localhost:8080/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("api/comments/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return Redirect(Request.UrlReferrer.ToString());
                }
            }

            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult CreateVote(Vote vote)
        {
            string Baseurl = "http://localhost:8080/";


            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiJ9.eyJzdWIiOiJ1c2VyMyJ9.Ct2xnc101d2yXl811suqXiWuYunKCpvGNDv6dsVnv0ReL44gTaB07E9LmbXCu1E5VuYx8c6amX-kiaQ23vJKoR6k6Gjj1uX9QGNPueUtbk8qdNUjUFiuZMj0SfEY8cBAgTxkRDyTQJ6SlB4gUnsi0Kh4OzqmkdAgA3SC0KwKjHfG8EY-k2BlEhG7ZkM3Yl_WWjEzujaceCzfhiA6He_M-ASkBr5InCURmdxh_l1m3OcB2jlTks3mcpQg0ztRTDALSHcP8-DMb9IvjSeVpt2Cp5qaYsFrfhAoZ8z95SL_1FNdtpk9nZYUYCvaUEnV-246alMN7fn-gEdHWywWAB1-gw");
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Add("X-Miva-API-Authorization", "MIVA xxxxxxxxxxxxxxxxxxxxxx");
                var postTask = client.PostAsJsonAsync("api/votes/", vote);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("PostsById/" + vote.postId);
                }

            }
            return View(vote);
        }
        public ActionResult CreateVote()
        {
            return View();
        }
    }
}