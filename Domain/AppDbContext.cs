using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyAspNetApp.Domain.Entities;

namespace MyAspNetApp.Domain
{
    //  DB CONTEXT
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<ServiceCategory> ServiceCategories{get;set;} = null!;
        public DbSet<Service> Services{get;set;} = null!;

        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string adminName = "admin";
            string roleAdminId = "407BFA8F-8CE1-45E1-9F2A-2270E884ED28";
            string userAdminId = "433D71D7-3843-4E9F-B934-5177D755F545";


            //Add role of admin  
            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
               Id = roleAdminId,
               Name = "adminName",
                NormalizedName = adminName.ToUpper()
            });
            //Add new identity user like admin of webb app
            builder.Entity<IdentityUser>().HasData(new IdentityUser()
            {
              Id = userAdminId,
              UserName = adminName,
              NormalizedUserName = adminName.ToUpper(),
              Email="admin@admin.com",
              NormalizedEmail= "admin@admin.com",
              EmailConfirmed = true,
              PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(new IdentityUser(),adminName),
              SecurityStamp = string.Empty,
              PhoneNumberConfirmed = true

            });

            //Admin role 

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
              RoleId = roleAdminId,
              UserId = userAdminId
            });
        }
    }
    
}