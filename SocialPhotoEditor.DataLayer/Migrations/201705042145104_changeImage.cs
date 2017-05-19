namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeImage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Images", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "Date", c => c.DateTime(nullable: false));
        }
    }
}
