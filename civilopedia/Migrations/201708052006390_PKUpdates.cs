namespace civilopedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PKUpdates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buildings", "CivId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buildings", "CivId", c => c.Int(nullable: false));
        }
    }
}
