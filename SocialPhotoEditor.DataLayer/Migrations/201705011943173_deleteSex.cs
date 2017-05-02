namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteSex : DbMigration
    {
        public override void Up()
        {
           // DropColumn("dbo.UserInfoes", "Sex");
        }
        
        public override void Down()
        {
         //   AddColumn("dbo.UserInfoes", "Sex", c => c.Int(nullable: false));
        }
    }
}
