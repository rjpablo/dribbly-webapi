namespace DribblyWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCourtPhotocourtId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourtPhotos", "Court_id", "dbo.Courts");
            DropIndex("dbo.CourtPhotos", new[] { "Court_id" });
            RenameColumn(table: "dbo.CourtPhotos", name: "Court_id", newName: "courtId");
            AlterColumn("dbo.CourtPhotos", "courtId", c => c.Int(nullable: false));
            CreateIndex("dbo.CourtPhotos", "courtId");
            AddForeignKey("dbo.CourtPhotos", "courtId", "dbo.Courts", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourtPhotos", "courtId", "dbo.Courts");
            DropIndex("dbo.CourtPhotos", new[] { "courtId" });
            AlterColumn("dbo.CourtPhotos", "courtId", c => c.Int());
            RenameColumn(table: "dbo.CourtPhotos", name: "courtId", newName: "Court_id");
            CreateIndex("dbo.CourtPhotos", "Court_id");
            AddForeignKey("dbo.CourtPhotos", "Court_id", "dbo.Courts", "id");
        }
    }
}
