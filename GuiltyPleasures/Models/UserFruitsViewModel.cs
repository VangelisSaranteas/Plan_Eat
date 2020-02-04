using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuiltyPleasures.Models
{
    public class UserFruitsViewModel
    {
        public string UserId { get; set; }
        public ICollection<Fruit> Fruits { get; set; }
    }
}