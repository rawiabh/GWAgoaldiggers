namespace GWA.WEB1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ver2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RegisterEmail", c => c.String());
            AddColumn("dbo.AspNetUsers", "RegisterUserName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "JoinDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "EmailLinkDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "LAstLoginDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LAstLoginDate");
            DropColumn("dbo.AspNetUsers", "EmailLinkDate");
            DropColumn("dbo.AspNetUsers", "JoinDate");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "RegisterUserName");
            DropColumn("dbo.AspNetUsers", "RegisterEmail");
        }
    }
}
