namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteavatar : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Avatars");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Avatars",
                c => new
                    {
                        AvatarFileName = c.String(nullable: false, maxLength: 128),
                        ImageFileName = c.String(),
                    })
                .PrimaryKey(t => t.AvatarFileName);
            
        }
    }
}
