using Microsoft.EntityFrameworkCore;
using SmallBizAPI.Models;

namespace SmallBizAPI.Data
{
    public class SmallBizDBContext : DbContext
    {
        public SmallBizDBContext(DbContextOptions<SmallBizDBContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
    }
}