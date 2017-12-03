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

        public string Name { get; set; }

        //public List<Level> Levels { get; set; } // ska detta vara i plural eller singular? 
        //public List<Round> Rounds { get; set; } // ska detta vara i plural eller singular? 

        //Relations
        //Level 1:n Player
        //Level  Round
        //Player  Level
        //Player  Round
        //Round  Player
        //Round  Level
    }
}
