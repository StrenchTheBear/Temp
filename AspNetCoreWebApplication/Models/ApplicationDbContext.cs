using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApplication.Models;

namespace AspNetCoreWebApplication.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //nos permite conectarnos a la BD en heroku mediante el uso de sus credenciales
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AspNetCoreWebApplication.Models.ReadDB> newtable { get; set; }
        
        

       
    }
}