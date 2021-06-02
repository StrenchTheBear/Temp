using System;
using System.ComponentModel.DataAnnotations;



namespace AspNetCoreWebApplication.Models
{
 
    public class ReadDB
    {
        [Key]
        public String fecha { get; set; }
        public String tempera { get; set; }
    }
}