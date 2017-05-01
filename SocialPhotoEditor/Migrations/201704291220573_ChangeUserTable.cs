namespace SocialPhotoEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AvatarFileName", c => c.String());
            AddColumn("dbo.AspNetUsers", "MinAvatarFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "MinAvatarFileName");
            DropColumn("dbo.AspNetUsers", "AvatarFileName");
        }
    }
}
