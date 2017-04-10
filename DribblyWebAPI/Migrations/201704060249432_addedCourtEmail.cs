namespace DribblyWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCourtEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courts", "email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courts", "email");
        }
    }
}
