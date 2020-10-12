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
    }
}
