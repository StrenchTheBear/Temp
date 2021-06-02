using System;
using System.ComponentModel.DataAnnotations;



namespace AspNetCoreWebApplication.Models
{
 
    public class ReadDB
    {
        [Key]
        public String Fecha { get; set; }
        public int Temperatura { get; set; }
    }
}