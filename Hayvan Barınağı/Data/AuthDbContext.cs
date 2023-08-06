using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hayvan_Barınağı.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Seed roles (User, Admin)

            var adminRoleId = "97410e6b-c4ae-4218-9b64-0d2c7f9471a1";
            var userRoleId = "d1149f3c-3b71-4b71-a501-88b441e5f3f0";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            var adminId = "48b55585-3b1e-4b39-bf37-d391536b502a";
            var AdminUser = new IdentityUser
            {
                UserName = "B221210374@sakarya.edu.tr",
                Email = "B221210374@sakarya.edu.tr",
                NormalizedEmail = "B221210374@sakarya.edu.tr".ToUpper(),
                Id = adminId
            };
            AdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(AdminUser, "sau");
            builder.Entity<IdentityUser>().HasData(AdminUser);

            var adminRole = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId ="97410e6b-c4ae-4218-9b64-0d2c7f9471a1" ,
                    UserId = adminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = "d1149f3c-3b71-4b71-a501-88b441e5f3f0",
                    UserId = adminId
                }

            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRole);
        }
    }
}
