namespace civilopedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PKUpdates2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Leaders", "CivId", "dbo.Civilizations");
            DropIndex("dbo.Leaders", new[] { "CivId" });
            AlterColumn("dbo.Districts", "CivId", c => c.Int());
            AlterColumn("dbo.Leaders", "CivId", c => c.Int());
            AlterColumn("dbo.Units", "CivId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Units", "CivId", c => c.Int(nullable: false));
            AlterColumn("dbo.Leaders", "CivId", c => c.Int(nullable: false));
            AlterColumn("dbo.Districts", "CivId", c => c.Int(nullable: false));
            CreateIndex("dbo.Leaders", "CivId");
            AddForeignKey("dbo.Leaders", "CivId", "dbo.Civilizations", "CivId", cascadeDelete: true);
        }
    }
}
