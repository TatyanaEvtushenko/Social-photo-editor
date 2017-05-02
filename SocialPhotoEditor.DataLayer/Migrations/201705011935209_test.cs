namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Lands", newName: "Countries");
            AddColumn("dbo.Cities", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.UserInfoes", "RegisterDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Cities", "LandId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "LandId", c => c.Int(nullable: false));
            DropColumn("dbo.UserInfoes", "RegisterDate");
            DropColumn("dbo.Cities", "CountryId");
            RenameTable(name: "dbo.Countries", newName: "Lands");
        }
    }
}
