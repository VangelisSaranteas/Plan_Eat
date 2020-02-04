using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuiltyPleasures.Models;
using HelperMyApp;

namespace GuiltyPleasures.Repositories
{
    public class PackageRepository
    {
        public IEnumerable<Package> GetPackages()
        {
            IEnumerable<Package> packages;
            using ( ApplicationDbContext db=new ApplicationDbContext())
            {
                packages=db.Packages.Select(x => x).ToList();
            }
            return packages;
        }
        public Package FindById(int id)
        {
            Package package;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                package = db.Packages.Find(id);
            }

            return package;
        }

        //public double GetBalance(string userId)
        //{
        //    double balance = 500;
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        var user = db.Money.FirstOrDefault(x => x.Id == userId);
        //        if (user == null)
        //        {
        //            Money money = new Money();
        //            money.Balance =Convert.ToDecimal( balance);
        //            money.Id = userId;
        //            db.Money.Add(money);
        //            db.SaveChanges();
                   
        //        }
        //        else
        //        {
        //            balance = Convert.ToDouble(db.Money.FirstOrDefault(x => x.Id == userId).Balance);
        //        }

        //    }
        //    return balance;
        //}
        public bool BuyPackagePartGoal(string userId, int? packageId)
        {
            bool ok = false;
            using (ApplicationDbContext db= new ApplicationDbContext()) 
            {
                try
                {
                    Package package = db.Packages.Find(packageId);
                    UserWithGoal userWithGoal = db.UsersWithGoals.Find(userId);
                    // Money money = db.Money.Find(userId);
                    userWithGoal.PackageId = package.Id;
                    // money.Balance = money.Balance - package.Price;
                    db.UsersWithGoals.Attach(userWithGoal);
                    // db.Money.Attach(money);
                    db.Entry(userWithGoal).State = System.Data.Entity.EntityState.Modified;
                    // db.Entry(money).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ok = true;
                }
                catch
                {

                }

            }
            return ok;
        }

        //public bool BuyPackagePartMoney(string searchString, decimal balance)
        //{
        //    bool ok = false;
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        try
        //        {
        //            Money money = db.Money.Where(x => x.Id == searchString).FirstOrDefault();
        //            if (money!=null)
        //            {
        //                money.Balance = balance;
        //                db.Money.Attach(money);
        //                db.Entry(money).State = System.Data.Entity.EntityState.Modified;
        //                ok = true;
        //            }
        //            else
        //            {
        //                Money money1 = new Money();
        //                money1.Id = searchString;
        //                money1.Balance = balance;
        //                db.Money.Add(money1);
        //                ok = true;
        //            }

        //            db.SaveChanges();
                  
        //        }
        //        catch
        //        {

        //        }

        //    }

        //    return ok;
        //}

        public void Add(Package package)
        {
            // Throw.IfNullOrWhiteSpace(name, "Name cannot be null or whitespace");

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    db.Packages.Add(new Package
                    {
                        Name = package.Name,
                        Price = package.Price,
                        Description = package.Description
                    });

                    db.SaveChanges();
                }
                catch 
                {

                }
            }
        }

        public bool Updatebool(Package package)
        {
            Throw.IfNull(package, nameof(package));
            bool updatebool = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    db.Packages.Attach(package);
                    db.Entry(package).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    updatebool = true;
                }
                catch
                {

                }
            }
            return updatebool;
        }

        public bool Deletebool(int id)
        {
            bool returnValue = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var package = db.Packages.Find(id);
                try
                {
                    db.Packages.Remove(package);
                    db.SaveChanges();
                    returnValue = true;
                }
                catch
                {

                }

            }
            return returnValue;
        }
    }
}