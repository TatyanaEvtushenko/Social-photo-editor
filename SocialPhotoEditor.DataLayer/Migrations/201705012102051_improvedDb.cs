namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class improvedDb : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Images");
            AddColumn("dbo.Images", "FileName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Images", "FileName");
            DropColumn("dbo.Images", "FieName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "FieName", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Images");
            DropColumn("dbo.Images", "FileName");
            AddPrimaryKey("dbo.Images", "FieName");
        }
    }
}
