using Microsoft.EntityFrameworkCore;
using Divarcheh.Domain.Core.Entities.User;
using Divarcheh.Domain.Core.Entities.BaseEntities;
using Divarcheh.Domain.Core.Entities.Advertisement;
using Divarcheh.Infrastructure.EfCore.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Divarcheh.Infrastructure.EfCore.Common
{
    public class AppDbContext : IdentityDbContext<User,IdentityRole<int>,int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.ApplyConfiguration(new AdvertisementConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new BrandConfigurations());
           // modelBuilder.ApplyConfiguration(new ImageConfigurations());
            modelBuilder.ApplyConfiguration(new CityConfigurations());
           // modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new UsersFavoriteAdvertisementsConfigurations());

            UserConfigurations.SeedUsers(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<UsersFavoriteAdvertisements> UsersFavoriteAdvertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
