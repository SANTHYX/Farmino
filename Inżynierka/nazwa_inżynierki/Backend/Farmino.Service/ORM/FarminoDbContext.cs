using Farmino.Data.Models;
using Farmino.Data.Models.Aggregations;
using Microsoft.EntityFrameworkCore;

namespace Farmino.Service.ORM
{
    public class FarminoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public FarminoDbContext(DbContextOptions<FarminoDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().OwnsOne(p => p.Account).
                Property(z => z.Login).HasColumnName("Login").IsRequired(true);
            modelBuilder.Entity<User>().OwnsOne(p => p.Account).
                Property(z => z.Password).HasColumnName("Password").IsRequired(true);
            modelBuilder.Entity<User>().OwnsOne(p => p.Account).
                Property(z => z.Email).HasColumnName("Email").IsRequired(true);
            modelBuilder.Entity<User>().OwnsOne(p => p.Account).
               Property(z => z.Salt).HasColumnName("Salt").IsRequired(true);
            base.OnModelCreating(modelBuilder);
        }
    }
}
