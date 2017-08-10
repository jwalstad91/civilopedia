namespace civilopedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        BuildingId = c.Int(nullable: false, identity: true),
                        BuildingName = c.String(nullable: false),
                        ProductionCost = c.Int(nullable: false),
                        MaintenanceCost = c.Int(nullable: false),
                        IsUnique = c.Boolean(nullable: false),
                        CivId = c.Int(),
                    })
                .PrimaryKey(t => t.BuildingId);
            
            CreateTable(
                "dbo.Civilizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(nullable: false),
                        ProductionCost = c.Int(nullable: false),
                        MaintenanceCost = c.Int(nullable: false),
                        IsUnique = c.Boolean(nullable: false),
                        CivId = c.Int(),
                    })
                .PrimaryKey(t => t.DistrictId);
            
            CreateTable(
                "dbo.Leaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Ability = c.String(),
                        Agenda = c.String(),
                        CivId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        UnitId = c.Int(nullable: false, identity: true),
                        UnitName = c.String(nullable: false),
                        IsUnique = c.Boolean(nullable: false),
                        CivId = c.Int(),
                        MeleeStrength = c.Int(nullable: false),
                        RangedStrength = c.Int(nullable: false),
                        AttackRange = c.Int(nullable: false),
                        MaintenanceCost = c.Int(nullable: false),
                        ProductionCost = c.Int(nullable: false),
                        Ability = c.String(),
                    })
                .PrimaryKey(t => t.UnitId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Units");
            DropTable("dbo.Leaders");
            DropTable("dbo.Districts");
            DropTable("dbo.Civilizations");
            DropTable("dbo.Buildings");
        }
    }
}
