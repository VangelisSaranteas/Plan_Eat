using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuiltyPleasures.Models
{
    public class BurnsUserBurnsViewModel
    {
        public string UserId { get; set; }
        public Burn Burn = new Burn();
        public UsersBurns UsersBurn = new UsersBurns();
        public  IEnumerable<Burn> Burns { get; set; }
        public List<UsersBurns> UsersBurns { get; set; }

        public BurnsUserBurnsViewModel()
        {

            UsersBurns = new List<UsersBurns>();
        }
    }

    
}