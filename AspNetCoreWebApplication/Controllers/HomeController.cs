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
            // var ReadDB=_context.newtable.ToList();

            return View();
    
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
                    j=19;
                    
                    
                    i++;                
                }
                valor=json.Substring(j,2);
                j=j+40;
                lectura.Add(valor);

            }while(j<= (json.Length-48));

                foreach(string val in lectura){
                    Console.WriteLine(val);
                    temp2.tempera = val;
                }


                
                // ReadDB temp = new ReadDB();
                // temp = _context.temptp.FirstOrDefault(i => i.tempera == x);
                // temp.Fecha = temp2.Fecha;
                // _context.Update(temp);
                // _context.SaveChanges();

            return View(lectura);

            }
        

        public IActionResult Error()
        {
            ViewData["Message"] = "We've encountered an error :(";
            return View();
        }

        public async Task<IActionResult> Cargar(int x){
            // var datos = _context.newtable.ToList();
            // return View(datos);

            List<String> lectura = new List<string>();
            int i =0;
            int j =0;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://jgbo9n6qqk.execute-api.us-east-2.amazonaws.com/Testget/getreaddb");
            Console.WriteLine(json); 
           
            do{
                string valor = "";
                if(i==0){
                    j=46;
                    i++;                
                }
                valor=json.Substring(j,2);
                j=j+40;
                lectura.Add(valor);
                }
            while(j<= (json.Length-49));

            foreach(string val in lectura){
                Console.WriteLine(val);
                // temp2.tempera = val;
            }
                ReadDB temp = new ReadDB();
                temp = _context.newtable.FirstOrDefault();
                // temp.Fecha = temp2.Fecha;
                // _context.Update(temp);
                // _context.SaveChanges();
            return View(lectura);
        }
    }
}
