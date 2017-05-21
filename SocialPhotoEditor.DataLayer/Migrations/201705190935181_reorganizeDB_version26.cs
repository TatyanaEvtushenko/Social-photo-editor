namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reorganizeDB_version26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "CityId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "CityId");
        }
    }
}
