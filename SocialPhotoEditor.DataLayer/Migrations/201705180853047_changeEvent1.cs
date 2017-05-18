namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeEvent1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Events");
            AddColumn("dbo.Events", "RecipientId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Events", "EventType", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "OwnerId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Events", new[] { "Time", "RecipientId", "OwnerId" });
            DropColumn("dbo.Events", "Id");
            DropColumn("dbo.Events", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Text", c => c.String(nullable: false));
            AddColumn("dbo.Events", "Id", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Events", "OwnerId", c => c.String(nullable: false));
            DropColumn("dbo.Events", "EventType");
            DropColumn("dbo.Events", "RecipientId");
            AddPrimaryKey("dbo.Events", "Id");
        }
    }
}
