using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GuiltyPleasures.Models
{
    public class UsersBurns
    {
        [ForeignKey("UserId")]
        public  ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("BurnId")]
        public virtual Burn Burn { get; set; }
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int BurnId { get; set; }
       
        [Required]
        [Range(0, 10000)]
        public int Duration { get; set; }

     



    }


}