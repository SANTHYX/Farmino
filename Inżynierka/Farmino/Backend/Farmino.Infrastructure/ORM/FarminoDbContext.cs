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
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Auctioner> Auctioners { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Auction> Auctions { get; set; }
        public virtual DbSet<ParticipantAuction> ParticipantAuctions { get; set; }

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
                x.HasOne(y => y.Auctioner).WithOne(z => z.User).HasForeignKey<Auctioner>(q => q.UserId);
                x.HasOne(y => y.Participant).WithOne(z => z.User).HasForeignKey<Participant>(q => q.UserId);
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

            builder.Entity<Farmer>(x =>
            {
                x.HasKey(y => y.Id);
                x.HasMany(y => y.Offers).WithOne(z => z.Farmer).HasForeignKey(q => q.FarmerId);
            });

            builder.Entity<Customer>().HasKey(x => x.Id);

            builder.Entity<Order>(x =>
            {
                x.HasKey(y => new { y.CustomerId, y.OfferId});
                x.HasOne(y => y.Offer).WithMany(z => z.Orders).HasForeignKey(q => q.OfferId)
                    .OnDelete(DeleteBehavior.Restrict);
                x.HasOne(y => y.Customer).WithMany(z => z.Orders).HasForeignKey(q => q.CustomerId);
                x.OwnsOne(y => y.OrderAddress, z =>
                {
                    z.Property(q => q.City).HasColumnName("City").HasMaxLength(30);
                    z.Property(q => q.HouseNumber).HasColumnName("HouseNumber").HasMaxLength(3);
                    z.Property(q => q.PostalCode).HasColumnName("PostalCode").HasMaxLength(7); ;
                    z.Property(q => q.Street).HasColumnName("Street").HasMaxLength(30); ;
                });
            });

            builder.Entity<Offer>(x => {
                x.HasKey(y => y.Id);
                x.Property(y => y.Title).HasMaxLength(40).IsRequired();
                x.Property(y => y.Description).IsRequired();
                x.Property(y => y.CreatedAt).HasMaxLength(10).IsRequired();
            });

            builder.Entity<Product>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Name).IsRequired();
                x.Property(y => y.Price).IsRequired();
                x.Property(y => y.Quantity).IsRequired();
                x.HasOne(y => y.Offer).WithOne(z => z.Product).HasForeignKey<Offer>(q => q.ProductId);
                x.OwnsOne(y => y.Weight, z =>
                {
                    z.Property(q => q.Unit).HasColumnName("Unit");
                    z.Property(q => q.Value).HasColumnName("Value");
                });
            });

            builder.Entity<Auctioner>(x =>
            {
                x.HasKey(y => y.Id);
                x.HasMany(y => y.Auctions).WithOne(z => z.Auctioner).HasForeignKey(q => q.AuctionerId);
            });

            builder.Entity<Participant>().HasKey(x => x.Id);

            builder.Entity<Auction>(x => {
                x.HasKey(y => y.Id);
                x.Property(y => y.Title).HasMaxLength(40).IsRequired();
                x.Property(y => y.Description).IsRequired();
                x.Property(y => y.EndDate).HasMaxLength(10).IsRequired();
                x.Property(y => y.StartDate).HasMaxLength(10).IsRequired();
                x.Property(y => y.StartingPrice).IsRequired();
            });

            builder.Entity<ParticipantAuction>(x =>
            {
                x.HasKey(y => new { y.AuctionId, y.ParticipantId });
                x.HasOne(y => y.Participant).WithMany(z => z.Auctions).HasForeignKey(q => q.ParticipantId)
                    .OnDelete(DeleteBehavior.Restrict);
                x.HasOne(y => y.Auction).WithMany(z => z.Participants).HasForeignKey(q => q.AuctionId);
                x.Property(y => y.ProposedPrice).IsRequired();
            });
        }
    }
}
