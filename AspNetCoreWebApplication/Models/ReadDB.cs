using System;
using System.ComponentModel.DataAnnotations;



namespace AspNetCoreWebApplication.Models
{
    //define la estructura de la BD para el aplicativo web
 
    public class ReadDB
    {
        [Key]
        public String fecha { get; set; }
        public String tempera { get; set; }
    }
}