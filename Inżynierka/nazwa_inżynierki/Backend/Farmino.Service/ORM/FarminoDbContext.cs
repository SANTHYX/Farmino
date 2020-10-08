using Farmino.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Farmino.Service.ORM
{
    public class FarminoDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address>Addresses { get; set; }

        public FarminoDbContext(DbContextOptions<FarminoDbContext> options) : base(options) { }
    }
}
