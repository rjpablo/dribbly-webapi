namespace DribblyWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeCourtuserIdString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courts", "userId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courts", "userId", c => c.Int(nullable: false));
        }
    }
}
