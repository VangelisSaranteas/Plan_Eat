using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GuiltyPleasures.Models
{
    public class UsersFruits
    {
        [ForeignKey("UserId")]
        public  ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("FruitId")]
        public virtual Fruit Fruit { get; set; }
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int FruitId { get; set; }

        [Range(0, 10000)]
        public double QuantityBreakfast{ get; set; }
        [Range(0, 10000)]
        public double QuantityLunch
        {
        
                get; set;
            
        }
        [Range(0, 10000)]
        public double QuantityDinner
        {
            get;set;
        }
        [Range(0, 10000)]
        public double QuantitySnacks
        {
            get;set;
        }








    }


}