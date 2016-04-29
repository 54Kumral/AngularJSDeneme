using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularJSDeneme.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Threading;
namespace AngularJSDeneme.Controllers
{
    public class HomeController : Controller
    {
        ImagesEntities db = new ImagesEntities();
        // GET: Home
        
        public ActionResult Index()
        {
           return View(db.Images.ToList());
        }

        public class aaa {
            [JsonProperty]
            public string IMAGE_URL;
            [JsonProperty]
            public string IMAGE_ALT;

        }
        //[Bind(Include = "IMAGE_URL,IMAGE_ALT")]aaa
        [HttpPost]
        public ActionResult AddImage(string data) 
        {
            
            Models.Images newImage = new Images();
            newImage.IMAGE_URL = Request["IMAGE_URL"];
            newImage.IMAGE_ALT = Request["IMAGE_ALT"];
            db.Images.Add(newImage);
            db.SaveChanges();

            /* var objects = JArray.Parse(data); // parse as array  
            foreach (JObject root in objects)
            {
                foreach (KeyValuePair<String, JToken> app in root)
                {
                    var imageId = app.Key;
                    var imageUrl = (String)app.Value["IMAGE_URL"];
                    var imageAlt = (String)app.Value["IMAGE_ALT"];

                }
            }*/

           
            return Json("Başarılı:");
        }

        public ActionResult AddPost() 
        {
            return View();
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        
        [HttpPost, ValidateInput(false)]
        public ActionResult AddPost(string data) 
        {
            
            Models.Posts newPost = new Posts();
            //newPost.POST_CONTENT = Base64Encode(Convert.ToString(Request["Post"]));
            newPost.POST_CONTENT = Request["Post"];
            db.Posts.Add(newPost);
            db.SaveChanges();
            return Json("Eklendi");
        }

        public ActionResult AddVideo(){
            return View(db.Videos.ToList());
        }

        [HttpPost]
        public ActionResult AddVideo(string data)
        {
            Models.Videos newVideo = new Videos();
            newVideo.VIDEO_URL = Request["VIDEO_URL"];
            newVideo.VIDEO_BASLIK = Request["VIDEO_BASLIK"];
            db.Videos.Add(newVideo);
            db.SaveChanges();
            return Json("Video Eklendi.");
        }

        public ActionResult TimeLine() 
        {
            return View(db.Posts.ToList());
        }
    }
}