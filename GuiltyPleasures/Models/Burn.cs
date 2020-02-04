using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GuiltyPleasures.Models
{

    public class Burn
    {
        public int BurnId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, 10000)]
        public double Calories { get; set; }
     

        [Required]
        [Range(0, 10000)]
        public int Time { get; set; }







    }
}