namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReorganizeDb : DbMigration
    {
        public override void Up()
        {
        //    DropPrimaryKey("dbo.Cities");
            DropPrimaryKey("dbo.Comments");
            DropPrimaryKey("dbo.Countries");
            AddColumn("dbo.Avatars", "ImageFileName", c => c.String());
            AddColumn("dbo.Cities", "CountryName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Cities", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "CommentatorId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Comments", "ImageId", c => c.String(nullable: false, maxLength: 128));
       //     AddPrimaryKey("dbo.Cities", new[] { "CountryName", "Name" });
            AddPrimaryKey("dbo.Comments", new[] { "ImageId", "CommentatorId", "Time" });
            AddPrimaryKey("dbo.Countries", "Name");
            DropColumn("dbo.Avatars", "ImageId");
            DropColumn("dbo.Avatars", "OwnerId");
       //     DropColumn("dbo.Cities", "CountryId");
            DropColumn("dbo.Comments", "Id");
            DropColumn("dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Countries", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Comments", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Cities", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.Avatars", "OwnerId", c => c.String(nullable: false));
            AddColumn("dbo.Avatars", "ImageId", c => c.String());
            DropPrimaryKey("dbo.Countries");
            DropPrimaryKey("dbo.Comments");
            DropPrimaryKey("dbo.Cities");
            AlterColumn("dbo.Comments", "ImageId", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "CommentatorId", c => c.String(nullable: false));
            AlterColumn("dbo.Cities", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Cities", "CountryName");
            DropColumn("dbo.Avatars", "ImageFileName");
            AddPrimaryKey("dbo.Countries", "Id");
            AddPrimaryKey("dbo.Comments", "Id");
            AddPrimaryKey("dbo.Cities", "Id");
        }
    }
}
