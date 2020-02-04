using GuiltyPleasures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuiltyPleasures.Repositories
{
    public class UserGoalRepositoty
    {
        public double GetGoal(string userId)
        {
            double goal = 0;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var user = db.UsersWithGoals.FirstOrDefault(x => x.Id == userId);
                if (user == null)
                {
                    UserWithGoal userWithGoal = new UserWithGoal();
                    userWithGoal.Goal = 0;
                    userWithGoal.Id = userId;
                    db.UsersWithGoals.Add(userWithGoal);
                    db.SaveChanges();
                    goal = 0;
                }
                else
                {
                    goal = db.UsersWithGoals.FirstOrDefault(x => x.Id == userId).Goal;
                }

            }
            return goal;
        }

        public bool SetGoal(UserWithGoal userWithGoal)
        {
            bool goalbool = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    db.UsersWithGoals.Attach(userWithGoal);
                    db.Entry(userWithGoal).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    goalbool = true;
                }
                catch
                {

                }
                
            }
            return goalbool;
        }


    }
}