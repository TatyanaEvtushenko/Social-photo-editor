namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeFolder3 : DbMigration
    {
        public override void Up()
        {
           // DropTable("dbo.Folders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Folders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OwnerId = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Subscribe = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
