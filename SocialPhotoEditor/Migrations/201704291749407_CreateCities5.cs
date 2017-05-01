namespace SocialPhotoEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCities5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "CityId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "CityId");
        }
    }
}
