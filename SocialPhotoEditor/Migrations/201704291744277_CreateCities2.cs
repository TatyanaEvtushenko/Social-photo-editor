namespace SocialPhotoEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCities2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cities", "Name", c => c.String());
        }
    }
}
