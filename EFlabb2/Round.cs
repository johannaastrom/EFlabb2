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
        [Key]
        public int RoundId { get; set; }
        public int UsedMoves { get; set; }

        public int PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public Player Player { get; set; }

        public int LevelId { get; set; }
        [ForeignKey("LevelId")]
        public Level Level { get; set; }
    }
}
