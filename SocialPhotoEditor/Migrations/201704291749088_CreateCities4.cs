namespace SocialPhotoEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCities4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserInfoes", "CityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfoes", "CityId", c => c.String());
        }
    }
}
