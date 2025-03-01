using Divarcheh.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Claims;

namespace Divarcheh.Infrastructure.EfCore.Configurations;
public class UserConfigurations
{
    public static void SeedUsers(ModelBuilder builder)
    {
        var hasher = new PasswordHasher<User>();

         //SeedUsers
        var users = new List<User>
        {
            new User()
            {
                Id = 1,
                UserName = "Admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
                Mobile = "09377507920",
                SecurityStamp = Guid.NewGuid().ToString(),
                CityId = 1,
                RoleId = 1
            }
        };

        foreach (var user in users)
        {
            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "123456");
            builder.Entity<User>().HasData(user);
        }

        builder.Entity<IdentityUserClaim<int>>().HasData(
            new IdentityUserClaim<int>() { Id = 1 , UserId = 1 ,ClaimType = ClaimTypes.Role , ClaimValue = "Admin"},
            new IdentityUserClaim<int>() { Id = 2 , UserId = 1 ,ClaimType = "FullName" , ClaimValue = "مسعود ملکی"}
        );

        // Seed Roles
        builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole<int>() { Id = 2, Name = "Visitor", NormalizedName = "VISITOR" },
            new IdentityRole<int>() { Id = 3, Name = "Advertiser", NormalizedName = "ADVERTISER" }
        );

        //Seed Role To Users
        builder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int>() { RoleId = 1, UserId = 1 }
        );
    }
}