namespace civilopedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReseedDb : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Buildings");
            DropPrimaryKey("dbo.Districts");
            DropPrimaryKey("dbo.Units");

            DropColumn("dbo.Buildings", "BuildingId");
            DropColumn("dbo.Districts", "DistrictId");
            DropColumn("dbo.Units", "UnitId");

            AddColumn("dbo.Buildings", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Buildings", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Districts", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Districts", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Units", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Units", "Name", c => c.String(nullable: false));

            AddPrimaryKey("dbo.Buildings", "Id");
            AddPrimaryKey("dbo.Districts", "Id");
            AddPrimaryKey("dbo.Units", "Id");

            DropColumn("dbo.Buildings", "BuildingName");

            DropColumn("dbo.Districts", "DistrictName");

            DropColumn("dbo.Units", "UnitName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Units", "UnitName", c => c.String(nullable: false));
            AddColumn("dbo.Units", "UnitId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Districts", "DistrictName", c => c.String(nullable: false));
            AddColumn("dbo.Districts", "DistrictId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Buildings", "BuildingName", c => c.String(nullable: false));
            AddColumn("dbo.Buildings", "BuildingId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Units");
            DropPrimaryKey("dbo.Districts");
            DropPrimaryKey("dbo.Buildings");
            DropColumn("dbo.Units", "Name");
            DropColumn("dbo.Units", "Id");
            DropColumn("dbo.Districts", "Name");
            DropColumn("dbo.Districts", "Id");
            DropColumn("dbo.Buildings", "Name");
            DropColumn("dbo.Buildings", "Id");
            AddPrimaryKey("dbo.Units", "UnitId");
            AddPrimaryKey("dbo.Districts", "DistrictId");
            AddPrimaryKey("dbo.Buildings", "BuildingId");
        }
    }
}
