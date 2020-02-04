using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GuiltyPleasures.Models
{
    public enum FoodType { Alcohol, Meat, Milk, Pasta, Sweet, Fruit}
    public class Fruit
    {
        public int FruitId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Portion { get; set; }

        [Required]
        [Range(0,10000)]
        public double Calories { get; set; }
        [Required]
        [Range(0, 10000)]
        public double Carbs { get; set; }
        [Required]
        [Range(0, 10000)]
        public double Fat { get; set; }
        [Required]
        [Range(0, 10000)]
        public double Protein { get; set; }
        [Required]
        [MaxLength(100)]
        public string Type { get; set; }







    }
}