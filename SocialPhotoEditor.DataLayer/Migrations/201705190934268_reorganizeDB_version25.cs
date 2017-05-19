namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reorganizeDB_version25 : DbMigration
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
