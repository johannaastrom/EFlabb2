using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFlabb2
{
    public class Player 
    {
        //här letar EF efter publika properties som den gör till kolumner i tabellen.

        public Player() { }

        [Key]
        public int Id { get; set; }
        //[Required]       ska detta läggas in?
        public string Name { get; set; }


        //public List<Level> Levels { get; set; } // ska detta vara i plural eller singular? 
        //public List<Round> Rounds { get; set; } // ska detta vara i plural eller singular? 

        //Relations
        //Level 1:n Player
        //Level 1:n Round
        //Player 1:n Level
        //Player 1:n Round
        //Round 1:1 Player
        //Round 1:1 Level
    }
}
