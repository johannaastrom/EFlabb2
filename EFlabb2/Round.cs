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
        //här letar EF efter publika properties som den gör till kolumner i tabellen.

        [Key]
        public int RoundId { get; set; }

        public int Score { get; set; }

        public int LevelId { get; set; }
        [ForeignKey("LevelId")]
        public virtual List<Level> Level { get; set; } //foreign key/navigation property

        public int PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public virtual List<Player> Player { get; set; } // foreign key/navigation property. Properties som har en klass som datatyp tolkar EF som Navigation properties. EF gör alla klasser den ser till tabeller på samma sätt som ovan.

        //round binder ihop alla tabeller genom foreign keys PlayerId och LevelId som används för att referera till andra tabeller.

    }
}
