namespace SocialPhotoEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFolders1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Folders", "OwnerUserName", c => c.String());
            DropColumn("dbo.Folders", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Folders", "OwnerId", c => c.String());
            DropColumn("dbo.Folders", "OwnerUserName");
        }
    }
}
