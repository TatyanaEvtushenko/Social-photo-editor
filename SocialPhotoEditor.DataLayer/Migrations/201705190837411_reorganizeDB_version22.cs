namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reorganizeDB_version22 : DbMigration
    {
        public override void Up()
        {
       //     DropTable("dbo.Likes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OwnerId = c.String(nullable: false),
                        ImageId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
