using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFlabb2
{
    public class GameContext : DbContext
    {

        public GameContext() : base() { }

        public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AngryBirdsGame;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public GameContext(string connectionString) : base(connectionString) { }

        //DbSet implementerar IEnumerable
        //De tre tabeller som ska skapas med ett s på slutet i databasen:
        public DbSet<Player> Players { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Round> Rounds { get; set; }

        //PM> Enable-Migrations
        //Checking if the context targets an existing database...
        //The target context 'EFlabb2.GameContext' is not constructible. Add a default constructor or provide an implementation of IDbContextFactory.
        //PM>           felmeddelande från package manager console
    }
}

//Ändra databasens struktur

//När man ändrar i modellklasserna, så att databasen behöver uppdateras, så skapar Entity Framework en mapp med namnet Migrations.
//    När man är klar med sina ändringar så använder man Package Manager Console för att skapa en migration och uppdatera databasen.
//    Om man inte gör det här på rätt sätt får man ett Exception när man kör programmet, eftersom databasens struktur inte stämmer överens med modellen.

//Package Manager Console (PMC)
//Enable-Migrations       måste användas för att aktivera migreringar
//Add-Migration "Text"    lägger till mina ändringar i en migrationsfil, jämförelse git add
//Update-Database         genomför ändringarna i alla migrationsfiler, jämförelse git commit + git push

//NÄR JAG FÖRSÖKER GÖRA ADD-MIGRATION får jag detta felmeddelande:
//PM> Add-Migration "test"
//The target context 'EFlabb2.GameContext' is not constructible.Add a default constructor or provide an implementation of IDbContextFactory.
//PM> 