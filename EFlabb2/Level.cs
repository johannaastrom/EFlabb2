using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EFlabb2
{
    public class Level
    {
        public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AngryBirdsGame;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //här letar EF efter publika properties som den gör till kolumner i tabellen.

        [Key]
        public int LevelId { get; set; }
        public int AvailableMoves { get; set; }
    }
}
