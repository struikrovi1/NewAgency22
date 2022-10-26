using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewAgency.Models;

namespace NewAgency.Data
{
    public class NewAgencyDBContext : IdentityDbContext<User>
    {
        public NewAgencyDBContext(DbContextOptions opt) : base(opt)
        {

        }

        public DbSet<Header> Mastheads { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("User");
            builder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}
