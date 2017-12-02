using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EFlabb2
{
    public class Player 
    {
        public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AngryBirdsGame;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual Level Level { get; set; }
        //A specified Include path is not valid. The EntityType 'EFlabb2.Player' does not declare a navigation property with the name 'Level'.'
    }
}
