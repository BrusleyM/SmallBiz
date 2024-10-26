using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmallBizAPI.Models;

namespace SmallBizAPI.Data
{
    public class SmallBizDBContext : IdentityDbContext<User>
    {
        public SmallBizDBContext(DbContextOptions<SmallBizDBContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
    }
}