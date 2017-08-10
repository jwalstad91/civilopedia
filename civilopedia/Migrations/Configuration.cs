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
            context.Civilizations.AddOrUpdate(c => c.Id,
                new Civilization() { Id = 1, Name = "America" },
                new Civilization() { Id = 2, Name = "Egypt" },
                new Civilization() { Id = 3, Name = "Japan" }
                );

            context.Leaders.AddOrUpdate(l => l.Id,
                new Leader() { Id = 1, Name = "Theodore Roosevelt", CivId = 1 },
                new Leader() { Id = 2, Name = "Cleopatra", CivId = 2 },
                new Leader() { Id = 3, Name = "Hojo Tokimune", CivId = 3 }
                );

            context.Buildings.AddOrUpdate(b => b.Id,
                new Building() { Id = 1, Name = "Monument" },
                new Building() {  Id = 2, Name = "Granary" }
                );

            context.Districts.AddOrUpdate(d => d.Id,
                new District() { Id = 1, Name = "Holy Site" },
                new District() { Id = 2, Name = "Campus" }
                );

            context.Units.AddOrUpdate(
                new Unit() { Id = 1, Name = "Scout" },
                new Unit() { Id = 2, Name = "Settler" },
                new Unit() { Id = 3, Name = "Warrior" }
                );
        }
    }
}