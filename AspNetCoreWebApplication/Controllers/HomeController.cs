using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApplication.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor;


namespace AspNetCoreWebApplication.Controllers
{
    public class HomeController : Controller
    {
        ReadDB temp2 = new ReadDB();

        public IActionResult Index()
        {
            var Db=_context.temp.ToList();

            return View(Db);
    
        }

        private ApplicationDbContext _context;

        public HomeController(

            ApplicationDbContext c
            
        ) {
            _context = c;
         
        }

        
        public IActionResult Consulta()
        {                 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Consulta(int x)
        {
            List<String> lectura = new List<string>();
            int i =0;
            int j =0;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://jgbo9n6qqk.execute-api.us-east-2.amazonaws.com/Testget/getreaddb");
            Console.WriteLine(json); 
           
            do{
                string valor = "";
                if(i==0){
                    j=47;
                    
                    
                    i++;                
                }
                valor=json.Substring(j,2);
                j=j+40;
                lectura.Add(valor);

            }while(j<= (json.Length-48));

                foreach(string val in lectura){
                    Console.WriteLine(val);
                    temp2.Temperatura = val;
                }


                
                ReadDB temp = new ReadDB();
                temp = _context.temp.FirstOrDefault(i => i.Fecha == x);
                temp.Temperatura = temp2.Temperatura;
                _context.Update(temp);
                _context.SaveChanges();

            return View(temp);

            }
        

        public IActionResult Error()
        {
            ViewData["Message"] = "We've encountered an error :(";
            return View();
        }        
    }
}
