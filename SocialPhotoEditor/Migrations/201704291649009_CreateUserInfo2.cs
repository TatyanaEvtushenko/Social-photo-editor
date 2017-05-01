namespace SocialPhotoEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserInfo2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfoes", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfoes", "Birthday", c => c.String());
        }
    }
}
