using System;
using System.ComponentModel.DataAnnotations;



namespace AspNetCoreWebApplication.Models
{
    //[Key]
    public class ReadDB
    {
        
        public String Fecha { get; set; }
        public int Temperatura { get; set; }
    }
}