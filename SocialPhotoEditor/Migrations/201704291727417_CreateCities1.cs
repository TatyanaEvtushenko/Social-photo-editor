namespace SocialPhotoEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCities1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lands", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lands", "Name", c => c.String());
        }
    }
}
