using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace APIBowler.Data
{
    public class BowlerContext : DbContext
    {
        public BowlerContext(DbContextOptions<BowlerContext> options) : base(options) { }
        public DbSet<Bowler>Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
