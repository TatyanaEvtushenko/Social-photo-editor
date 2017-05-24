using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SocialPhotoEditor.DataLayer.DatabaseModels;

namespace SocialPhotoEditor.DataLayer.DatabaseContextes
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false) { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}