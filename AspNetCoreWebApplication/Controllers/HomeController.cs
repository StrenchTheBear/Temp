using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Temp.Models;

namespace AspNetCoreWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewData["Message"] = "You just created a ASP.Net Core web application!";
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://jgbo9n6qqk.execute-api.us-east-2.amazonaws.com/Testget/getreaddb");

            var DBlist = JsonConvert.DeserializeObject<List<ReadDB>>(json); 
           
         
            return View(DBlist);
        }

        public IActionResult Error()
        {
            ViewData["Message"] = "We've encountered an error :(";
            return View();
        }
    }
}
