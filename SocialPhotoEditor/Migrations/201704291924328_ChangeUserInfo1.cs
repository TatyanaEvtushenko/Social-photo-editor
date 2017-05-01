namespace SocialPhotoEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserInfo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "IsFemale", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "IsFemale");
        }
    }
}
