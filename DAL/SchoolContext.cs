using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebApplication.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcWebApplication.DAL
{
    public class SchoolContext : DbContext
    {        
        public DbSet<Car> Car { get; set; }
        
        public DbSet<CarType> CarType { get; set; }
        
        public SchoolContext() : base("SchoolContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();            
        }
    }
}