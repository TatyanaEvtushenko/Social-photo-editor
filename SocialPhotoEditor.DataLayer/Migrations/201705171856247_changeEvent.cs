namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Image");
            DropColumn("dbo.Events", "Time");
        }
    }
}
