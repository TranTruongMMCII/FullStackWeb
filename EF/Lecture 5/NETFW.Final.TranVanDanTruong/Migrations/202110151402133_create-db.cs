namespace NETFW.Final.TranVanDanTruong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Performent",
                c => new
                    {
                        ActorID = c.Int(nullable: false),
                        MovieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ActorID, t.MovieID })
                .ForeignKey("dbo.Actor", t => t.ActorID, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.ActorID)
                .Index(t => t.MovieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Performent", "MovieID", "dbo.Movie");
            DropForeignKey("dbo.Performent", "ActorID", "dbo.Actor");
            DropIndex("dbo.Performent", new[] { "MovieID" });
            DropIndex("dbo.Performent", new[] { "ActorID" });
            DropTable("dbo.Performent");
            DropTable("dbo.Actor");
        }
    }
}
