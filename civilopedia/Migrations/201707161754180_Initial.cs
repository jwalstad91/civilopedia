namespace civilopedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Civilizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Leaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CivilizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Civilizations", t => t.CivilizationId, cascadeDelete: true)
                .Index(t => t.CivilizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leaders", "CivilizationId", "dbo.Civilizations");
            DropIndex("dbo.Leaders", new[] { "CivilizationId" });
            DropTable("dbo.Leaders");
            DropTable("dbo.Civilizations");
        }
    }
}
