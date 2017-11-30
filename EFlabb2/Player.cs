using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFlabb2
{
    public class Player 
    {
        public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AngryBirds;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Id { get; set; }
        public string Name { get; set; }
        
    }
    public class PlayerContext : DbContext
    {
        public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AngryBirds;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public PlayerContext() : base(connectionString) { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Round> Rounds { get; set; }
    }
}
