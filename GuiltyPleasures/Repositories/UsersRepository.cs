using GuiltyPleasures.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GuiltyPleasures.Repositories
{
    public class UsersRepository
    {
        public  void SaveUser(UserWithGoal applicationUser)
        {
            using (ApplicationDbContext db=new ApplicationDbContext())
            {
                var userExsist=db.UsersFruits.FirstOrDefault(x => x.UserId == applicationUser.Id);
                if (userExsist!=null)
                {
                    db.UsersWithGoals.Attach(applicationUser);
                    db.Entry(applicationUser).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    db.UsersWithGoals.Add(applicationUser);
                    db.UsersWithGoals.Attach(applicationUser);
                    db.Entry(applicationUser).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();

            }
        }



        public void InsertUser(UserWithGoal applicationUser)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var userExsist = db.UsersFruits.FirstOrDefault(x => x.UserId == applicationUser.Id);
                if (userExsist != null)
                {
                    db.UsersWithGoals.Add(applicationUser);

                }
                else
                {
                    db.UsersWithGoals.Add(applicationUser);
                }

                db.SaveChanges();

            }
        }
    }
}