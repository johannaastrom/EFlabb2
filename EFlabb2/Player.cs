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
        public Player() { }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Avatar { get; set; }
    }
}
    