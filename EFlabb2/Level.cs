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
        //här letar EF efter publika properties som den gör till kolumner i tabellen.

        [Key]
        public int LevelId { get; set; }

        public int AvailableMoves { get; set; }

    }
}
