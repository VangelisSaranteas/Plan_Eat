using GuiltyPleasures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuiltyPleasures.Repositories
{
    public class UsersBurnsRepository
    {
        public void AddBurnsToUser(string userId, IEnumerable<int> burnsIds)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                foreach (var item in burnsIds)
                {
                    db.UsersBurns.Add(new UsersBurns
                    {
                        UserId = userId,
                        BurnId = item
                    });
                }

                db.SaveChanges();
            }
        }
        public void RemoveBurnsFromUser(string userId, IEnumerable<int> burnsIds)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                foreach (var item in burnsIds)
                {
                    db.UsersBurns.Remove(new UsersBurns
                    {
                        UserId = userId,
                        BurnId = item
                    });
                }

                db.SaveChanges();
            }
        }

        public IEnumerable< double> CountCalories(string userId)
        {
            List<Burn> burns = new List<Burn>();
            List<int> durations = new List<int>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                burns = db.UsersBurns.Where(x => x.UserId == userId&& x.Duration > 0).Select(x => x.Burn).ToList();
                durations = db.UsersBurns.Where(x => x.UserId == userId && x.Duration > 0).Select(x => x.Duration).ToList();
            }
            List<double> nutrition = new List<double>();
            double calories = 0;
            double carbs = 0;
            double fat = 0;
            double protein = 0;
            for (int i = 0; i < burns.Count(); i++)
            {
                int multiply = durations[i] / burns[i].Time;
                calories = calories + burns[i].Calories * multiply;
                nutrition.Add(calories);
                nutrition.Add(carbs);
                nutrition.Add(fat);
                nutrition.Add(protein);
            }
            return nutrition;
        }

        public List<UsersBurns> GetUserBurns(string userId)
        {
            List<UsersBurns> burns = new List<UsersBurns>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                burns = db.UsersBurns.Include("Burn").Where(x => x.UserId == userId && x.Duration>0).ToList();
            }     
               
            return burns;
        }


        public bool UpdateDuration(UsersBurns object1)
        {
            UsersBurns userBurns = new UsersBurns();
            bool update = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                   userBurns =db.UsersBurns.Where(x => x.BurnId == object1.BurnId && x.UserId == object1.UserId).FirstOrDefault();
                    userBurns.Duration = object1.Duration;
                    if (object1.Duration > 0)
                    {
                        db.UsersBurns.Attach(userBurns);
                        db.Entry(userBurns).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        db.UsersBurns.Remove(userBurns);
                    }
                    db.SaveChanges();
                    update = true;
                }
                catch
                {

                }

            }
            return update;
        }

        public void CreateQuantity(UsersBurns object1)
        {
            UsersBurns userBurns = new UsersBurns();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.UsersBurns.Add(new UsersBurns
                {
                    UserId = object1.UserId,
                    BurnId = object1.BurnId,
                    Duration=object1.Duration
                });
                db.SaveChanges();

            }
            
        }

        public bool DeleteUserBurn(int id,string searchString)
        {
            bool returnValue = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    var userBurn = db.UsersBurns.Where(x => x.UserId == searchString && x.BurnId == id).FirstOrDefault();
                    db.UsersBurns.Remove(userBurn);
                    db.SaveChanges();
                    returnValue = true;
                }
                catch
                {

                }
                return returnValue;
            }
        }

   




    }
}
