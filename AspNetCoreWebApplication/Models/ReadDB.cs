using System;
using System.ComponentModel.DataAnnotations;



namespace AspNetCoreWebApplication.Models
{
    //[Key]
    public class ReadDB
    {
        
        public int Fecha { get; set; }
        public string Temperatura { get; set; }
    }
}