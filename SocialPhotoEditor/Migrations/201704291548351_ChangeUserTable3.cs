namespace SocialPhotoEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserTable3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "AvatarFileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AvatarFileName", c => c.String());
        }
    }
}
