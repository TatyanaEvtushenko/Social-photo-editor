namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeLike : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Likes");
            AlterColumn("dbo.Likes", "OwnerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Likes", "ImageId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Likes", new[] { "ImageId", "OwnerId" });
            DropColumn("dbo.Likes", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Likes", "Id", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Likes");
            AlterColumn("dbo.Likes", "ImageId", c => c.String(nullable: false));
            AlterColumn("dbo.Likes", "OwnerId", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Likes", "Id");
        }
    }
}
