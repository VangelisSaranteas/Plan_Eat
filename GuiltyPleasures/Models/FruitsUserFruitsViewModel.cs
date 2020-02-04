using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuiltyPleasures.Models
{
    public class FruitsUserFruitsViewModel
    {
        public string UserId { get; set; }
        public Fruit Fruit = new Fruit();
        public UsersFruits UsersFruit = new UsersFruits();
        public  IEnumerable<Fruit> Fruits { get; set; }
        public List<UsersFruits> UsersFruitsBreakfast { get; set; }
        public List<UsersFruits> UsersFruitsLunch { get; set; }
        public List<UsersFruits> UsersFruitsDinner { get; set; }
        public List<UsersFruits> UsersFruitsSnacks { get; set; }
        public List<UsersFruits> UsersFruitsAll { get; set; }

        public FruitsUserFruitsViewModel()
        {

            UsersFruitsBreakfast = new List<UsersFruits>();
            UsersFruitsLunch = new List<UsersFruits>();
            UsersFruitsDinner = new List<UsersFruits>();
            UsersFruitsSnacks = new List<UsersFruits>();
            UsersFruitsAll = new List<UsersFruits>();
        }
    }

    
}