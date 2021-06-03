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
            //la variable json lo que contiene es el dato que recibe del API, convertido en un string
            var json = await httpClient.GetStringAsync("https://jgbo9n6qqk.execute-api.us-east-2.amazonaws.com/Testget/getreaddb");
            Console.WriteLine(json); 
           // el siguiente do, sirve como contador de caracteres, donde le indicamos en donde estan los valores de la temperatura 
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


            //el siguiente foreach, escribe en la consola, todos los valores de las temperaturas
                foreach(string val in lectura){
                    Console.WriteLine(val);
                    temp2.tempera = val;
                }
                
                // ReadDB temp = new ReadDB();
                // temp = _context.temptp.FirstOrDefault(i => i.tempera == x);
                // temp.Fecha = temp2.Fecha;
                // _context.Update(temp);
                // _context.SaveChanges();
                
            //envia a la vista el valor de la variable json
            ViewData["mensaje"] = json;

            return View(lectura);

            }        

        public IActionResult Error()
        {
            ViewData["Message"] = "We've encountered an error :(";
            return View();
        }

    }
}