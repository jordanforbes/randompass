using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RandomPass.Models;

namespace RandomPass.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            int? count = HttpContext.Session.GetInt32("Count");
            char GetLetter()
            {
                Random rand = new Random();
                int num = rand.Next(0,26);
                char letter = (char)('a'+ num);
                return letter;
            }
            string CreateString(){ 
                Random rand = new Random();
                Random coinFlip = new Random();
                string finStr = "";
                for(int i = 0; i< 15; i++){
                    if(rand.Next(0,2) == 0)
                    {
                        finStr +=rand.Next(0,10);
                    }else{
                        finStr += GetLetter();
                    }
                }
                return finStr;
            }

            if(count == null){
                HttpContext.Session.SetInt32("Count",0);
            }
            

            ViewBag.RandStr = CreateString();
            ViewBag.Count = HttpContext.Session.GetInt32("Count");
            return View(ViewBag);
        }
        [HttpGet("generate")]
        public IActionResult Generate()
        {
            int? count = HttpContext.Session.GetInt32("Count");
            count++;
            HttpContext.Session.SetInt32("Count",(int)count);
            return Redirect("/");

        }
    

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
