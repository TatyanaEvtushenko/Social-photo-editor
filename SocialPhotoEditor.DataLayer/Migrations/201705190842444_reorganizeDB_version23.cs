namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reorganizeDB_version23 : DbMigration
    {
        public override void Up()
        {
            //DropTable("dbo.Cities");
            //DropTable("dbo.Comments");
            //DropTable("dbo.Events");
            //DropTable("dbo.Subscribers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        SubscriberName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Type = c.Int(nullable: false),
                        TypeElementId = c.String(nullable: false),
                        RecipientId = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
                        IsSeen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CommentatorId = c.String(nullable: false),
                        ImageId = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                        RecipientId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CountryName = c.String(nullable: false),
                        CityName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
