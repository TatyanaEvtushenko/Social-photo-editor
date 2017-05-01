namespace SocialPhotoEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AvatarId", c => c.String());
            DropColumn("dbo.AspNetUsers", "AvatarFileName");
            DropColumn("dbo.AspNetUsers", "MinAvatarFileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "MinAvatarFileName", c => c.String());
            AddColumn("dbo.AspNetUsers", "AvatarFileName", c => c.String());
            DropColumn("dbo.AspNetUsers", "AvatarId");
        }
    }
}
