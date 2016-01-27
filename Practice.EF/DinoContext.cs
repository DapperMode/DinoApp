using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Practice.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Practice.EF
{
    public class DinoContext : DbContext
    {
        public DinoContext() : base("DinoDatabase") 
        {

        }
        
        public DbSet<Dino> Dinos { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
