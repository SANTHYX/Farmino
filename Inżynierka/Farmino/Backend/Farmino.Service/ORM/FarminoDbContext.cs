using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Farmino.Service.ORM
{
    public class FarminoDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Farmer> Farmers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public FarminoDbContext(DbContextOptions<FarminoDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Login).HasMaxLength(15).IsRequired();
                x.Property(y => y.Password).HasMaxLength(70).IsRequired();
                x.Property(y => y.Salt).HasMaxLength(70).IsRequired();
                x.Property(y => y.Email).HasMaxLength(30).IsRequired();
                x.HasOne(y => y.Profile).WithOne(z => z.User).HasForeignKey<Profile>(q => q.UserId);
                x.HasMany(y => y.RefreshTokens).WithOne(z => z.User).HasForeignKey(q => q.UserId);
                x.HasOne(y => y.Farmer).WithOne(z => z.User).HasForeignKey<Farmer>(q => q.UserId);
                x.HasOne(y => y.Customer).WithOne(z => z.User).HasForeignKey<Customer>(q => q.UserId);
                x.Property(y => y.CreatedAt).HasMaxLength(10).IsRequired();
                x.Property(y => y.UpdatedAt).HasMaxLength(10).IsRequired();
            });

            builder.Entity<Profile>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.FirstName).HasMaxLength(25).IsRequired();
                x.Property(y => y.LastName).HasMaxLength(25).IsRequired();
                x.Property(y => y.PhoneNumber).HasMaxLength(12).IsRequired();
                x.OwnsOne(y => y.Address, z =>
                {
                    z.Property(q => q.City).HasColumnName("City").HasMaxLength(30);
                    z.Property(q => q.HouseNumber).HasColumnName("HouseNumber").HasMaxLength(3);
                    z.Property(q => q.PostalCode).HasColumnName("PostalCode").HasMaxLength(7); ;
                    z.Property(q => q.Street).HasColumnName("Street").HasMaxLength(30); ;
                });
            });

            builder.Entity<RefreshToken>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Token).HasMaxLength(80).IsRequired();
                x.Property(y => y.IsRevoked).HasMaxLength(1).IsRequired();
                x.Property(y => y.ExpiresAt).HasMaxLength(10).IsRequired();
                x.Property(y => y.GeneratedAt).HasMaxLength(10).IsRequired();
            });

            builder.Entity<Farmer>().HasKey(x => x.Id);

            builder.Entity<Customer>().HasKey(x => x.Id);

            builder.Entity<Offer>(x => {
                x.HasKey(y => y.Id);
                x.Property(y => y.Title).HasMaxLength(40).IsRequired();
                x.Property(y => y.Description).IsRequired();
                x.HasOne(y => y.Farmer).WithMany(z => z.Offers).HasForeignKey(q => q.FarmerId);
                x.HasOne(y => y.Product).WithOne(z => z.Offer).HasForeignKey<Product>(q => q.OfferId);
                x.Property(y => y.CreatedAt).HasMaxLength(10).IsRequired();
            });

            builder.Entity<Product>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Name).HasMaxLength(30).IsRequired();
                x.Property(y => y.Price).HasMaxLength(10).IsRequired().HasPrecision(2);
                x.Property(y => y.Quantity).HasMaxLength(4).IsRequired();
                x.OwnsOne(y => y.Weight, z =>
                {
                    z.Property(q => q.Unit).HasColumnName("Unit").HasMaxLength(1);
                    z.Property(q => q.Value).HasColumnName("WeightValue").HasMaxLength(5);
                });
            });
        }
    }
}
