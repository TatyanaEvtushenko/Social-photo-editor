namespace SocialPhotoEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AvatarFileName", c => c.String());
            DropColumn("dbo.AspNetUsers", "AvatarId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AvatarId", c => c.String());
            DropColumn("dbo.AspNetUsers", "AvatarFileName");
        }
    }
}
