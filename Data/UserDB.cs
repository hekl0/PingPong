using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public class UserDB : DbContext
    {
        public DbSet<User> users { get; set; }

        // public UserDB(DbContextOptions<UserDB> options)
        //   : base(options)
        // { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite("Data Source = UserDB");
        }
    }

}