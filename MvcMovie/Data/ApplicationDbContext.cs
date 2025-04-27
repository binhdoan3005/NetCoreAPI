using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcMovie;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MvcMovie.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Person> Person { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HeThongPhanPhoi> HeThongPhanPhoi { get; set; }  // Đảm bảo chỉ khai báo một lần
        public DbSet<DaiLy> DaiLy { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<HeThongPhanPhoi>()
                .HasMany(htpp => htpp.DaiLys)
                .WithOne(dl => dl.HeThongPhanPhoi)
                .HasForeignKey(dl => dl.MaHTPP);
        }


    }
}
