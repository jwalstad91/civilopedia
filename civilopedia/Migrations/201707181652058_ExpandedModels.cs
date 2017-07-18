namespace civilopedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpandedModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Leaders", "CivilizationId", "dbo.Civilizations");
            RenameColumn(table: "dbo.Leaders", name: "CivilizationId", newName: "CivId");
            RenameIndex(table: "dbo.Leaders", name: "IX_CivilizationId", newName: "IX_CivId");
            DropPrimaryKey("dbo.Civilizations");
            DropPrimaryKey("dbo.Leaders");
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        BuildingId = c.Int(nullable: false, identity: true),
                        BuildingName = c.String(nullable: false),
                        ProductionCost = c.Int(nullable: false),
                        MaintenanceCost = c.Int(nullable: false),
                        IsUnique = c.Boolean(nullable: false),
                        CivId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BuildingId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(nullable: false),
                        ProductionCost = c.Int(nullable: false),
                        MaintenanceCost = c.Int(nullable: false),
                        IsUnique = c.Boolean(nullable: false),
                        CivId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistrictId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        UnitId = c.Int(nullable: false, identity: true),
                        UnitName = c.String(nullable: false),
                        IsUnique = c.Boolean(nullable: false),
                        CivId = c.Int(nullable: false),
                        MeleeStrength = c.Int(nullable: false),
                        RangedStrength = c.Int(nullable: false),
                        AttackRange = c.Int(nullable: false),
                        MaintenanceCost = c.Int(nullable: false),
                        ProductionCost = c.Int(nullable: false),
                        Ability = c.String(),
                    })
                .PrimaryKey(t => t.UnitId);

            DropColumn("dbo.Civilizations", "Id");
            DropColumn("dbo.Leaders", "Id");
            AddColumn("dbo.Civilizations", "CivId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Civilizations", "CivName", c => c.String(nullable: false));
            AddColumn("dbo.Leaders", "LeaderId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Leaders", "LeaderName", c => c.String(nullable: false));
            AddColumn("dbo.Leaders", "LeaderAbility", c => c.String());
            AddColumn("dbo.Leaders", "LeaderAgenda", c => c.String());
            AddPrimaryKey("dbo.Civilizations", "CivId");
            AddPrimaryKey("dbo.Leaders", "LeaderId");
            AddForeignKey("dbo.Leaders", "CivId", "dbo.Civilizations", "CivId", cascadeDelete: true);
            
            DropColumn("dbo.Civilizations", "Name");
            
            DropColumn("dbo.Leaders", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leaders", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Leaders", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Civilizations", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Civilizations", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Leaders", "CivId", "dbo.Civilizations");
            DropPrimaryKey("dbo.Leaders");
            DropPrimaryKey("dbo.Civilizations");
            DropColumn("dbo.Leaders", "LeaderAgenda");
            DropColumn("dbo.Leaders", "LeaderAbility");
            DropColumn("dbo.Leaders", "LeaderName");
            DropColumn("dbo.Leaders", "LeaderId");
            DropColumn("dbo.Civilizations", "CivName");
            DropColumn("dbo.Civilizations", "CivId");
            DropTable("dbo.Units");
            DropTable("dbo.Districts");
            DropTable("dbo.Buildings");
            AddPrimaryKey("dbo.Leaders", "Id");
            AddPrimaryKey("dbo.Civilizations", "Id");
            RenameIndex(table: "dbo.Leaders", name: "IX_CivId", newName: "IX_CivilizationId");
            RenameColumn(table: "dbo.Leaders", name: "CivId", newName: "CivilizationId");
            AddForeignKey("dbo.Leaders", "CivilizationId", "dbo.Civilizations", "Id", cascadeDelete: true);
        }
    }
}
