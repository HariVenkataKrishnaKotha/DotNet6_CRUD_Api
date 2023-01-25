using DotNetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetAPI.Data
{
    public class FullStackDbContext: DbContext
    {
        public FullStackDbContext(DbContextOptions options): base(options) { }

        public DbSet<Team> Teams { get; set; }
    }
}
