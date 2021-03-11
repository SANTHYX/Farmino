using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Farmino.Infrastructure.ORM 
{
    public class FarminoDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Farmer> Farmers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Observed> Observeds { get; set; }

        public FarminoDbContext(DbContextOptions<FarminoDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.UserName).HasMaxLength(15).IsRequired();
                x.Property(y => y.Password).HasMaxLength(70).IsRequired();
                x.Property(y => y.Salt).HasMaxLength(70).IsRequired();
                x.Property(y => y.Email).HasMaxLength(30).IsRequired();
                x.HasOne(y => y.Profile).WithOne(z => z.User).HasForeignKey<Profile>(q => q.UserId);
                x.HasMany(y => y.RefreshTokens).WithOne(z => z.User).HasForeignKey(q => q.UserId);
                x.HasOne(y => y.Farmer).WithOne(z => z.User).HasForeignKey<Farmer>(q => q.UserId);
                x.HasOne(y => y.Customer).WithOne(z => z.User).HasForeignKey<Customer>(q => q.UserId);
                x.HasMany(y => y.Observeds).WithOne(z => z.User).HasForeignKey(q => q.UserId).OnDelete(DeleteBehavior.Restrict);
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
                    z.Property(q => q.HouseNumber).HasColumnName("HouseNumber").HasMaxLength(5);
                    z.Property(q => q.PostalCode).HasColumnName("PostalCode").HasMaxLength(7); ;
                    z.Property(q => q.Street).HasColumnName("Street").HasMaxLength(30);
                    z.OwnsOne(q => q.Node, w =>
                    {
                        w.Property(z => z.Lat).HasColumnName("Lat").HasMaxLength(20);
                        w.Property(z => z.Lon).HasColumnName("Lon").HasMaxLength(20);
                    });
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

            builder.Entity<Farmer>(x =>
            {
                x.HasKey(y => y.Id);
                x.HasMany(y => y.Offers).WithOne(z => z.Farmer).HasForeignKey(q => q.FarmerId);
            });

            builder.Entity<Customer>().HasKey(x => x.Id);

            builder.Entity<Order>(x =>
            {
                x.HasKey(y => y.Id);
                x.HasOne(y => y.Offer).WithMany(z => z.Orders).HasForeignKey(q => q.OfferId)
                    .OnDelete(DeleteBehavior.Restrict);
                x.HasOne(y => y.Customer).WithMany(z => z.Orders).HasForeignKey(q => q.CustomerId);
                x.Property(y => y.OrderQuantity).IsRequired();
                x.Property(y => y.PriceSummary).IsRequired();
                x.Property(y => y.ReleaseDate);
                x.Property(y => y.OrderStatus);
                x.Property(y => y.CustomAddress).IsRequired();
                x.OwnsOne(y => y.OrderDetails, z =>
                {
                    z.Property(q => q.FirstName).HasMaxLength(25).HasColumnName("OrderFirstName").IsRequired();
                    z.Property(q => q.LastName).HasMaxLength(25).HasColumnName("OrderLastName").IsRequired();
                    z.Property(q => q.PhoneNumber).HasMaxLength(12).HasColumnName("OrderPhoneNumber").IsRequired();
                    z.OwnsOne(q => q.Address, z =>
                    {
                        z.Property(w => w.City).HasColumnName("OrderCity").HasMaxLength(30);
                        z.Property(w => w.HouseNumber).HasColumnName("OrderHouseNumber").HasMaxLength(5);
                        z.Property(w => w.PostalCode).HasColumnName("OrderPostalCode").HasMaxLength(7); ;
                        z.Property(w => w.Street).HasColumnName("OrderStreet").HasMaxLength(30);
                        z.OwnsOne(q => q.Node, w =>
                        {
                            w.Property(z => z.Lat).HasColumnName("OrderLat").HasMaxLength(20);
                            w.Property(z => z.Lon).HasColumnName("OrderLon").HasMaxLength(20);
                        });
                    });
                });
            });

            builder.Entity<Offer>(x => {
                x.HasKey(y => y.Id);
                x.Property(y => y.Title).HasMaxLength(40).IsRequired();
                x.Property(y => y.Description).IsRequired();
                x.Property(y => y.CreatedAt).HasMaxLength(10).IsRequired();
                x.Property(y => y.ImageName).HasMaxLength(40);
                x.Property(y => y.Category).HasMaxLength(2);
                x.Property(y => y.Region).HasMaxLength(2);
                x.Property(y => y.IsActive).HasMaxLength(3);
                x.HasMany(y => y.Observeds).WithOne(z => z.Offer).HasForeignKey(q => q.OfferId);
                x.OwnsOne(y => y.Product, z =>
                {
                    z.Property(q => q.BasePrice).IsRequired();
                    z.Property(q => q.BaseWeightUnit).IsRequired();
                });
            });

            builder.Entity<Observed>(x =>
            {
                x.HasKey(y => new { y.OfferId, y.UserId });
            });
        }
    }
}
