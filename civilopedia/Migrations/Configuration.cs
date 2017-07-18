namespace civilopedia.Migrations
{
    using civilopedia.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<civilopediaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(civilopediaContext context)
        {
            context.Civilizations.AddOrUpdate(x => x.CivId,
                new Civilization() { CivId = 1, CivName = "America" },
                new Civilization() { CivId = 2, CivName = "Egypt" },
                new Civilization() { CivId = 3, CivName = "Japan" }
                );

            context.Leaders.AddOrUpdate(x => x.LeaderId,
                new Leader() { LeaderId = 1, LeaderName = "Theodore Roosevelt", CivId = 1 },
                new Leader() { LeaderId = 2, LeaderName = "Cleopatra", CivId = 2 },
                new Leader() { LeaderId = 3, LeaderName = "Hojo Tokimune", CivId = 3 }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
