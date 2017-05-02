namespace SocialPhotoEditor.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "Sex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "Sex");
        }
    }
}
