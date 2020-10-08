using Farmino.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Farmino.Service.ORM
{
    public class FarminoDb : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
    }
}
