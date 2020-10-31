using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Farmino.Service.ORM
{
    public class FarminoDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PersonalData> PersonalDatas { get; set; }
        public FarminoDbContext(DbContextOptions<FarminoDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PersonalData>(x =>
            {
                x.OwnsOne(y => y.Address, z =>
                {
                    z.Property(q => q.City).HasColumnName("City").IsRequired();
                    z.Property(q => q.HouseNumber).HasColumnName("HouseNumber").IsRequired();
                    z.Property(q => q.PostalCode).HasColumnName("PostalCode").IsRequired();
                    z.Property(q => q.Street).HasColumnName("Street").IsRequired();
                });
            });
        }
    }
}
