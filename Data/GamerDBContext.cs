using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UI.Models
{
    public class GamerDbContext : DbContext
    {
        public DbSet<Gamer> Gamers { get; set; }

        public GamerDbContext(DbContextOptions<GamerDbContext> options)
          : base(options)
        { }
    }
    public class Gamer
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string room { get; set; }

    }

}