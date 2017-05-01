namespace SocialPhotoEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserInfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfoes", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfoes", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
