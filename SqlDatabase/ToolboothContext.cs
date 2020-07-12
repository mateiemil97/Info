using System;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SqlDatabase
{
    public class ToolboothContext: IdentityDbContext
    {
        public DbSet<Location> Location { get; set; }
        public DbSet<Toolbooth> Tollbooth { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<History> History { get; set; }

        public ToolboothContext(DbContextOptions options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IdentityRole>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityRoleClaim<string>>();
            modelBuilder.Entity<IdentityUser>()

                .Ignore(c => c.AccessFailedCount)
                .Ignore(c => c.LockoutEnabled)
                .Ignore(c => c.TwoFactorEnabled)
                .Ignore(c => c.ConcurrencyStamp)
                .Ignore(c => c.LockoutEnd)
                .Ignore(c => c.EmailConfirmed)
                .Ignore(c => c.TwoFactorEnabled)
                .Ignore(c => c.LockoutEnd)
                .Ignore(c => c.AccessFailedCount)
                .Ignore(c => c.PhoneNumberConfirmed)
                .Ignore(c => c.Email)
                .Ignore(c => c.NormalizedEmail)
                .Ignore(c => c.PhoneNumber);



            modelBuilder.Entity<IdentityUser>().ToTable("Users");//to change the name of table.

        }

        public object FromSql()
        {
            throw new NotImplementedException();
        }
    }
}
