namespace civilopedia.Migrations
{
    using civilopedia.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<civilopedia.Models.civilopediaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(civilopedia.Models.civilopediaContext context)
        {
            context.Civilizations.AddOrUpdate(x => x.Id,
                new Civilization() { Id = 1, Name = "America" },
                new Civilization() { Id = 2, Name = "Egypt" },
                new Civilization() { Id = 3, Name = "Japan" }
                );

            context.Leaders.AddOrUpdate(x => x.Id,
                new Leader() { Id = 1, Name = "Theodore Roosevelt", CivilizationId = 1 },
                new Leader() { Id = 2, Name = "Cleopatra", CivilizationId = 2 },
                new Leader() { Id = 3, Name = "Hojo Tokimune", CivilizationId = 3 }
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
