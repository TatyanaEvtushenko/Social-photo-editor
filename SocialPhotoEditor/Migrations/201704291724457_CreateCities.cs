namespace SocialPhotoEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LandId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserInfoes", "CityId", c => c.String());
            DropColumn("dbo.UserInfoes", "Land");
            DropColumn("dbo.UserInfoes", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfoes", "City", c => c.String());
            AddColumn("dbo.UserInfoes", "Land", c => c.String());
            DropColumn("dbo.UserInfoes", "CityId");
            DropTable("dbo.Lands");
            DropTable("dbo.Cities");
        }
    }
}
