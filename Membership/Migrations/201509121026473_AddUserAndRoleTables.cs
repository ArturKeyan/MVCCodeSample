namespace Membership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAndRoleTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(),
                        Password = c.String(nullable: false),
                        LastLoginDate = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users2Roles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users2Roles", new[] { "RoleId" });
            DropIndex("dbo.Users2Roles", new[] { "UserId" });
            DropForeignKey("dbo.Users2Roles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users2Roles", "UserId", "dbo.Users");
            DropTable("dbo.Users2Roles");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
        }
    }
}
