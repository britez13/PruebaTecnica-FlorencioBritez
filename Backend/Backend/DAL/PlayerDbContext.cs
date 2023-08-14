using Backend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Backend.DAL
{
    public class PlayerDbContext : DbContext
    {
        public PlayerDbContext() : base("name=myFDBConnectionString")
        {
        }

        public DbSet<Player> Players { get; set; } 
    }
}