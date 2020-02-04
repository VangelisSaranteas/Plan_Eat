using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuiltyPleasures.Models
{
    public class AboutViewModel
    {
    
        public List<double> NutritionBreakfast { get; set; } = new List<double>();
        public List<double> NutritionLunch { get; set; } = new List<double>();
        public List<double> NutritionDinner { get; set; } = new List<double>();
        public List<double> NutritionSnacks { get; set; } = new List<double>();
        public List<double> NutritionBurn { get; set; } = new List<double>();

        public string UserId { get; set; }

    }
}