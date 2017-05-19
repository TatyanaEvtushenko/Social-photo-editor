namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reorganizeDB_version2 : DbMigration
    {
        public override void Up()
        {
         /*   DropPrimaryKey("dbo.Cities");
            DropPrimaryKey("dbo.Comments");
            DropPrimaryKey("dbo.Events");
            DropPrimaryKey("dbo.Likes");
            DropPrimaryKey("dbo.Subscribers");
            AddColumn("dbo.Cities", "CityName", c => c.String(nullable: false));
            AddColumn("dbo.Comments", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Events", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Events", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "TypeElementId", c => c.String(nullable: false));
            AddColumn("dbo.Events", "IsSeen", c => c.Boolean(nullable: false));
            AddColumn("dbo.Likes", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Subscribers", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Cities", "CountryName", c => c.String(nullable: false));
            AlterColumn("dbo.Cities", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Comments", "ImageId", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "CommentatorId", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "RecipientId", c => c.String(nullable: false));
            AlterColumn("dbo.Likes", "ImageId", c => c.String(nullable: false));
            AlterColumn("dbo.Likes", "OwnerId", c => c.String(nullable: false));
            AlterColumn("dbo.Subscribers", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Subscribers", "SubscriberName", c => c.String(nullable: false));
            AlterColumn("dbo.UserInfoes", "CityId", c => c.String());
            AddPrimaryKey("dbo.Cities", "Id");
            AddPrimaryKey("dbo.Comments", "Id");
            AddPrimaryKey("dbo.Events", "Id");
            AddPrimaryKey("dbo.Likes", "Id");
            AddPrimaryKey("dbo.Subscribers", "Id");
            DropColumn("dbo.Cities", "Name");
            DropColumn("dbo.Events", "OwnerId");
            DropColumn("dbo.Events", "EventType");
            DropColumn("dbo.Events", "Image");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Events");
            DropTable("dbo.Likes");
            DropTable("dbo.Subscribers");*/

        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Name);
            
            AddColumn("dbo.Events", "Image", c => c.String());
            AddColumn("dbo.Events", "EventType", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "OwnerId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 50));
            DropPrimaryKey("dbo.Subscribers");
            DropPrimaryKey("dbo.Likes");
            DropPrimaryKey("dbo.Events");
            DropPrimaryKey("dbo.Comments");
            DropPrimaryKey("dbo.Cities");
            AlterColumn("dbo.UserInfoes", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Subscribers", "SubscriberName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Subscribers", "UserName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Likes", "OwnerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Likes", "ImageId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Events", "RecipientId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Comments", "CommentatorId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Comments", "ImageId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Cities", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Cities", "CountryName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Subscribers", "Id");
            DropColumn("dbo.Likes", "Id");
            DropColumn("dbo.Events", "IsSeen");
            DropColumn("dbo.Events", "TypeElementId");
            DropColumn("dbo.Events", "Type");
            DropColumn("dbo.Events", "Id");
            DropColumn("dbo.Comments", "Id");
            DropColumn("dbo.Cities", "CityName");
            AddPrimaryKey("dbo.Subscribers", new[] { "UserName", "SubscriberName" });
            AddPrimaryKey("dbo.Likes", new[] { "ImageId", "OwnerId" });
            AddPrimaryKey("dbo.Events", new[] { "Time", "RecipientId", "OwnerId" });
            AddPrimaryKey("dbo.Comments", new[] { "ImageId", "CommentatorId", "Time" });
            AddPrimaryKey("dbo.Cities", new[] { "CountryName", "Name" });
        }
    }
}
