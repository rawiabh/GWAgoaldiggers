namespace GWA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersession1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Sessions");
            AddColumn("dbo.Sessions", "IdUser", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Sessions", "IdUser");
            CreateIndex("dbo.Sessions", "IdUser");
            AddForeignKey("dbo.Sessions", "IdUser", "dbo.Users", "Id");
            DropColumn("dbo.Sessions", "Id");
            DropColumn("dbo.Sessions", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sessions", "UserName", c => c.String());
            AddColumn("dbo.Sessions", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Sessions", "IdUser", "dbo.Users");
            DropIndex("dbo.Sessions", new[] { "IdUser" });
            DropPrimaryKey("dbo.Sessions");
            DropColumn("dbo.Sessions", "IdUser");
            AddPrimaryKey("dbo.Sessions", "Id");
        }
    }
}
