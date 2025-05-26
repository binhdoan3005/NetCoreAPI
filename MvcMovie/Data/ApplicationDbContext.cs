using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcMovie.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MvcMovie.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Employee2> Employee2s { get; set; }
        public DbSet<MemberUnit> MemberUnits { get; set; }


        public DbSet<Person> Person { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HeThongPhanPhoi> HeThongPhanPhoi { get; set; } 
        public DbSet<DaiLy> DaiLy { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

            builder.Entity<HeThongPhanPhoi>()
                .HasMany(htpp => htpp.DaiLys)
                .WithOne(dl => dl.HeThongPhanPhoi)
                .HasForeignKey(dl => dl.MaHTPP);
        }


    }
}
