namespace SocialPhotoEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCities3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Cities");
            AlterColumn("dbo.Cities", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Cities");
            AlterColumn("dbo.Cities", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Cities", "Id");
        }
    }
}
