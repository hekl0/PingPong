using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UI.Controllers
{
    public class GamerDbContext : DbContext
    {
        public DbSet<Gamer> Gamers { get; set; }

        public GamerDbContext(DbContextOptions<GamerDbContext> options)
          : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = GamerData.db");
        }
    }
    public class Gamer
    {
        public string userName { get; set; }
        public string room { get; set; }

    }

}