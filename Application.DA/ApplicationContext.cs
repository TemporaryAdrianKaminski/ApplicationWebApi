using Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DA
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base()
        {

        }

        public DbSet<Model> Models { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Eurofins_dev2;Trusted_Connection=True;MultipleActiveResultSets=true");
            optionsBuilder.UseSqlite("Data Source=ApplicationDb");
            
        }
    }
}
