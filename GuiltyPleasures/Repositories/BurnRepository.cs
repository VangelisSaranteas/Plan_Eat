using GuiltyPleasures.Models;
using HelperMyApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuiltyPleasures.Repositories
{
    public class BurnRepository
    {
        public IEnumerable<Burn> GetBurn()
        {
            IEnumerable<Burn> burns;

            using( ApplicationDbContext db = new ApplicationDbContext())
            {
                
                burns = db.Burns.ToList();
            }

            return burns;
        }

        public IEnumerable<Burn> GetBurn(int id,string searchString)
        {
            IEnumerable<Burn> burns;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                burns = db.Burns.Where(x => x.Name.Contains(searchString)).ToList();
            }

            return burns;
        }
     


        public void AddBurn(Burn burn)
        {
           // Throw.IfNullOrWhiteSpace(name, "Name cannot be null or whitespace");

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Burns.Add(new Burn
                {
                    Name = burn.Name,
                    Calories = burn.Calories,
                    Time=burn.Time
                });

                db.SaveChanges();
            }
        }

        public void UpdateBurn(Burn burn)
        {
            Throw.IfNull(burn, nameof(burn));

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Burns.Attach(burn);
                db.Entry(burn).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public bool UpdateBurnbool(Burn burn)
        {
            Throw.IfNull(burn, nameof(burn));
            bool updatebool = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    db.Burns.Attach(burn);
                    db.Entry(burn).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    updatebool = true;
                }
                catch
                {

                }
            }
            return updatebool;
        }

        public void DeleteBurn(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var burn = db.Burns.Find(id);
                db.Burns.Remove(burn);
                db.SaveChanges();
            }
        }
        public bool DeleteBurnbool(int id)
        {
            bool returnValue = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var burn = db.Burns.Find(id);
                try
                {
                    db.Burns.Remove(burn);
                    db.SaveChanges();
                    returnValue = true;
                }
                catch
                {

                }
                
            }
            return returnValue;
        }

        public Burn FindById(int id)
        {
            Burn burn;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                burn = db.Burns.Find(id);
            }

            return burn;
        }

        public void FindByIdAndChangeTime(int id, string userId,int quantity)
        {

            UsersBurns userBurns = new UsersBurns();
            Burn burn;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                burn = db.Burns.SingleOrDefault(x => x.BurnId == id);
                userBurns = db.UsersBurns.SingleOrDefault(x => x.UserId == userId && x.BurnId == id);
                if (userBurns==null)
                {
                    UsersBurns userBurns1 = new UsersBurns()
                    {
                        BurnId = id,
                        UserId=userId,
                        Duration=quantity
                    };
                    db.UsersBurns.Add(userBurns1);
               
                }
                else 
                {
                    
                        userBurns.Duration = quantity;

                }
                db.SaveChanges();
            }


        }

        public IEnumerable<UsersBurns> FindChosen(string currentUserId)
        {
            IEnumerable<UsersBurns> burns;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               burns = db.UsersBurns.Include("Burn").Where(x => x.Duration>0 && x.UserId == currentUserId).ToList();                  
                               
                
            }

            return burns;
        }

        public Burn Search(string name)
        {
            Burn burn;
            using (ApplicationDbContext db =new ApplicationDbContext())
            {
               burn = db.Burns.SingleOrDefault(x => x.Name == name);
            }
            return burn;
        }

    }
}