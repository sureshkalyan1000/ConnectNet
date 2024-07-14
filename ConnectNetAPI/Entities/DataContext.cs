using ConnectNet.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectNet.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
