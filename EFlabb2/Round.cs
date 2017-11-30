using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFlabb2
{
    public class Round
    {
        public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AngryBirds;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int RoundId { get; set; }
        public int LevelId { get; set; }
        public int PlayerId { get; set; }
        public int Score { get; set; }

        public virtual IList<Level> Level { get; set; }
        public virtual IList<Player> Player { get; set; }
    }
}
