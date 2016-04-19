namespace CoachingCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        mobile = c.String(),
                        address = c.String(),
                        city = c.String(),
                        centerid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Centers", t => t.centerid, cascadeDelete: true)
                .Index(t => t.centerid);
            
            CreateTable(
                "dbo.Centers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        type = c.String(),
                        email = c.String(),
                        mobile = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        lastname = c.String(),
                        skill = c.String(),
                        mobile = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        lastname = c.String(),
                        mobile = c.String(),
                        email = c.String(),
                        teacherid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Teachers", t => t.teacherid, cascadeDelete: true)
                .Index(t => t.teacherid);
            
            CreateTable(
                "dbo.CenterTeacher",
                c => new
                    {
                        CenterId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CenterId, t.TeacherId })
                .ForeignKey("dbo.Centers", t => t.CenterId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.CenterId)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CenterTeacher", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.CenterTeacher", "CenterId", "dbo.Centers");
            DropForeignKey("dbo.Students", "teacherid", "dbo.Teachers");
            DropForeignKey("dbo.Branches", "centerid", "dbo.Centers");
            DropIndex("dbo.CenterTeacher", new[] { "TeacherId" });
            DropIndex("dbo.CenterTeacher", new[] { "CenterId" });
            DropIndex("dbo.Students", new[] { "teacherid" });
            DropIndex("dbo.Branches", new[] { "centerid" });
            DropTable("dbo.CenterTeacher");
            DropTable("dbo.Students");
            DropTable("dbo.Teachers");
            DropTable("dbo.Centers");
            DropTable("dbo.Branches");
        }
    }
}
