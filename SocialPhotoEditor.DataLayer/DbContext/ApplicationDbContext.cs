using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SocialPhotoEditor.DataLayer.Models;

namespace SocialPhotoEditor.DataLayer.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Avatar> Avatars { get; set; }

        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false) { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscriber>().HasKey(x => new {x.UserName, x.SubscriberName});
            base.OnModelCreating(modelBuilder);
        }
    }
}