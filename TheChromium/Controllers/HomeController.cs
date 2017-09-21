﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace TheChromium.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormSubmit()
        {
            var response = Request["g-recaptcha-response"];
            string secretKey = "6Lc7hDEUAAAAANubf-OwVIigqASJSrtQrXz03qND";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
           // ViewBag.Message = status ? "Google reCaptcha validation successful" : "Google reCaptcha validation failed";
            if(status == true)
            {
                ViewBag.Message = status ? "Google reCaptcha validation successful" : "Google reCaptcha validation failed";
                return View("Index");
            }
            else
            {
                ViewBag.Message = status ? "Google reCaptcha validation successful" : "Google reCaptcha validation failed";
                return (null);
            }
           
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}