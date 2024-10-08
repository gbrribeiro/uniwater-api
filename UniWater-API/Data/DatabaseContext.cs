using Compacts.Simple.Identity.EF;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniWater_API.Models;
using UniWater_API.Models.Identity;

namespace UniWater_API.Data
{
    public class DatabaseContext : IdentityDbContext<AppUser>
    {
        public DbSet<Recording> Records { get; set; }
        public DbSet<SystemParameters> SystemParameters { get; set; }
        public DbSet<StreamingData> StreamData { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            const string ADMIN_ID = "02174cf0–9412–4cfe - afbf - 59f706d72cf6";
            const string ROLE_ID = "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6";

            //Seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            //Create admin user
            var user = new AppUser
            {
                Id = ADMIN_ID,
                Email = "superadmin@admin.com",
                EmailConfirmed = true,
                UserName = "superadmin@admin.com",
                NormalizedUserName = "SUPERADMIN@ADMIN.COM",
                NormalizedEmail = "SUPERADMIN@ADMIN.COM"
            };

            //Set user password
            var hasher = new PasswordHasher<AppUser>();
            user.PasswordHash = hasher.HashPassword(user, "Admin@2024");

            //Seed user
            builder.Entity<AppUser>().HasData(user);

            //Set the role to the admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            base.OnModelCreating(builder);
        }
    }
}
