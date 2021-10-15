namespace TestEFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Class", t => t.ClassID, cascadeDelete: true)
                .Index(t => t.ClassID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "ClassID", "dbo.Class");
            DropIndex("dbo.Student", new[] { "ClassID" });
            DropTable("dbo.Student");
            DropTable("dbo.Class");
        }
    }
}
