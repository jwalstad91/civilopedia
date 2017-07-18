using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace civilopedia.Models
{
    public class civilopediaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public civilopediaContext() : base("name=civilopediaContext")
        {
        }

        public DbSet<Civilization> Civilizations { get; set; }

        public DbSet<Leader> Leaders { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<Building> Buildings { get; set; }
    }
}
