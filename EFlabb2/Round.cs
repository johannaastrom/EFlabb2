using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EFlabb2
{
    public class Round
    {
        public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AngryBirds;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        [Key]
        public int RoundId { get; set; }
        public int Score { get; set; }

        public int LevelId { get; set; }
        [ForeignKey("LevelId")]
        public virtual Level Level { get; set; }

        public int PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }

        //round binder ihop alla tabeller genom foreign keys PlayerId och LevelId som används för att referera till andra tabeller.
    }
}
