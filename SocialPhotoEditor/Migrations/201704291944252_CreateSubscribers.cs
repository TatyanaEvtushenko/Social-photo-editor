namespace SocialPhotoEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSubscribers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        SubscriberName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserName, t.SubscriberName });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscribers");
        }
    }
}
