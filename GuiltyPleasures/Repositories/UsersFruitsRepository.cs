using GuiltyPleasures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuiltyPleasures.Repositories
{
    public class UsersFruitsRepository
    {
        public void AddFruitsToUser(string userId, IEnumerable<int> fruitsIds)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                foreach (var item in fruitsIds)
                {
                    db.UsersFruits.Add(new UsersFruits
                    {
                        UserId = userId,
                        FruitId = item
                    });
                }

                db.SaveChanges();
            }
        }
        public void RemoveFruitsFromUser(string userId, IEnumerable<int> fruitsIds)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                foreach (var item in fruitsIds)
                {
                    db.UsersFruits.Remove(new UsersFruits
                    {
                        UserId = userId,
                        FruitId = item
                    });
                }

                db.SaveChanges();
            }
        }

        public IEnumerable<Fruit> GetUserFruits(string userId)
        {
            IEnumerable<Fruit> fruits;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                fruits = db.UsersFruits.Where(x => x.UserId == userId).Select(x => x.Fruit);
            }
            return fruits;
        }
        public  IEnumerable< double> CountCaloriesBreakfast(string userId)
        {
            List<Fruit> fruits = new List<Fruit>();
            List<double> quantities = new List<double>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                fruits = db.UsersFruits.Where(x => x.UserId == userId&& x.QuantityBreakfast>0).Select(x => x.Fruit).ToList();
                quantities=db.UsersFruits.Where(x => x.UserId == userId && x.QuantityBreakfast > 0).Select(x => x.QuantityBreakfast).ToList();
            }
            List<double> nutrition = new List<double>();
            double calories = 0;
            double carbs = 0;
            double fat = 0;
            double protein = 0;
            for (int i=0;i<fruits.Count();i++)
            {
                calories = calories + fruits[i].Calories * quantities[i];
                carbs=carbs+ fruits[i].Carbs * quantities[i];
                fat = fat + fruits[i].Fat * quantities[i];
                protein = protein + fruits[i].Protein * quantities[i];
                nutrition.Add(calories);
                nutrition.Add(carbs);
                nutrition.Add(fat);
                nutrition.Add(protein);
            }
            return nutrition;
        }

        public IEnumerable< double> CountCaloriesLunch(string userId)
        {
            List<Fruit> fruits = new List<Fruit>();
            List<double> quantities = new List<double>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                fruits = db.UsersFruits.Where(x => x.UserId == userId && x.QuantityLunch > 0).Select(x => x.Fruit).ToList();
                quantities = db.UsersFruits.Where(x => x.UserId == userId && x.QuantityLunch > 0).Select(x => x.QuantityLunch).ToList();
            }
            List<double> nutrition = new List<double>();
            double calories = 0;
            double carbs = 0;
            double fat = 0;
            double protein = 0;
            for (int i = 0; i < fruits.Count(); i++)
            {
                calories = calories + fruits[i].Calories * quantities[i];
                carbs = carbs + fruits[i].Carbs * quantities[i];
                fat = fat + fruits[i].Fat * quantities[i];
                protein = protein + fruits[i].Protein * quantities[i];
                nutrition.Add(calories);
                nutrition.Add(carbs);
                nutrition.Add(fat);
                nutrition.Add(protein);
            }
            return nutrition;
        }

        public IEnumerable< double> CountCaloriesDinner(string userId)
        {
            List<Fruit> fruits = new List<Fruit>();
            List<double> quantities = new List<double>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                fruits = db.UsersFruits.Where(x => x.UserId == userId && x.QuantityDinner > 0).Select(x => x.Fruit).ToList();
                quantities = db.UsersFruits.Where(x => x.UserId == userId && x.QuantityDinner > 0).Select(x => x.QuantityDinner).ToList();
            }
            List<double> nutrition = new List<double>();
            double calories = 0;
            double carbs = 0;
            double fat = 0;
            double protein = 0;
            for (int i = 0; i < fruits.Count(); i++)
            {
                calories = calories + fruits[i].Calories * quantities[i];
                carbs = carbs + fruits[i].Carbs * quantities[i];
                fat = fat + fruits[i].Fat * quantities[i];
                protein = protein + fruits[i].Protein * quantities[i];
                nutrition.Add(calories);
                nutrition.Add(carbs);
                nutrition.Add(fat);
                nutrition.Add(protein);
            }
            return nutrition;
        }
        public IEnumerable< double> CountCaloriesSnacks(string userId)
        {
            List<Fruit> fruits = new List<Fruit>();
            List<double> quantities = new List<double>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                fruits = db.UsersFruits.Where(x => x.UserId == userId && x.QuantitySnacks > 0).Select(x => x.Fruit).ToList();
                quantities = db.UsersFruits.Where(x => x.UserId == userId && x.QuantitySnacks > 0).Select(x => x.QuantitySnacks).ToList();
            }
            List<double> nutrition = new List<double>();
            double calories = 0;
            double carbs = 0;
            double fat = 0;
            double protein = 0;
            for (int i = 0; i < fruits.Count(); i++)
            {
                calories = calories + fruits[i].Calories * quantities[i];
                carbs = carbs + fruits[i].Carbs * quantities[i];
                fat = fat + fruits[i].Fat * quantities[i];
                protein = protein + fruits[i].Protein * quantities[i];
                nutrition.Add(calories);
                nutrition.Add(carbs);
                nutrition.Add(fat);
                nutrition.Add(protein);
            }
            return nutrition;
        }

        public List<UsersFruits>[] GetUserFruitsMeals(string userId)
        {
            List<UsersFruits>[] fruits = new List<UsersFruits>[5];
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                fruits[0] = db.UsersFruits.Include("Fruit").Where(x => x.UserId == userId && x.QuantityBreakfast > 0).ToList();
                fruits[1] = db.UsersFruits.Include("Fruit").Where(x => x.UserId == userId && x.QuantityLunch > 0).ToList();
                fruits[2] = db.UsersFruits.Include("Fruit").Where(x => x.UserId == userId && x.QuantityDinner > 0).ToList();
                fruits[3] = db.UsersFruits.Include("Fruit").Where(x => x.UserId == userId && x.QuantitySnacks > 0).ToList();
                fruits[4] = db.UsersFruits.Include("Fruit").Where(x=>x.UserId==userId).ToList();

                return fruits;
            }
        }



        public List<UsersFruits> EraseDay(string userId)
        {

            using ( ApplicationDbContext db=new ApplicationDbContext())
            {

                    var userfruits = db.UsersFruits.Where(x => x.UserId == userId).ToList();
                    var userburns = db.UsersBurns.Where(x => x.UserId == userId).ToList();
                    db.UsersFruits.RemoveRange(userfruits);
               
                    //db.UsersBurns.RemoveRange(userburns);
                    
                    db.SaveChanges();
                var ll = db.UsersFruits.ToList();
                return ll;
            }
        }

        public bool UpdateBreakfastQuantity(UsersFruits object1)
        {
            UsersFruits userFruits = new UsersFruits();
            bool update = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                   userFruits =db.UsersFruits.Where(x => x.FruitId == object1.FruitId && x.UserId == object1.UserId).FirstOrDefault();
                    userFruits.QuantityBreakfast = object1.QuantityBreakfast;
                    if (object1.QuantityBreakfast > 0||object1.QuantityDinner>0|| object1.QuantityLunch>0|| object1.QuantitySnacks>0)
                    {
                        db.UsersFruits.Attach(userFruits);
                        db.Entry(userFruits).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        db.UsersFruits.Remove(userFruits);
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

        public bool UpdateLunchQuantity(UsersFruits object1)
        {
            UsersFruits userFruits = new UsersFruits();
            bool update = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    userFruits = db.UsersFruits.Where(x => x.FruitId == object1.FruitId && x.UserId == object1.UserId).FirstOrDefault();
                    userFruits.QuantityLunch = object1.QuantityLunch;
                    if (object1.QuantityBreakfast > 0 || object1.QuantityDinner > 0 || object1.QuantityLunch > 0 || object1.QuantitySnacks > 0)
                    {
                        db.UsersFruits.Attach(userFruits);
                        db.Entry(userFruits).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        db.UsersFruits.Remove(userFruits);
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
        public bool UpdateDinnerQuantity(UsersFruits object1)
        {
            UsersFruits userFruits = new UsersFruits();
            bool update = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    userFruits = db.UsersFruits.Where(x => x.FruitId == object1.FruitId && x.UserId == object1.UserId).FirstOrDefault();
                    userFruits.QuantityDinner = object1.QuantityDinner;
                    if (object1.QuantityBreakfast > 0 || object1.QuantityDinner > 0 || object1.QuantityLunch > 0 || object1.QuantitySnacks > 0)
                    {
                        db.UsersFruits.Attach(userFruits);
                        db.Entry(userFruits).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        db.UsersFruits.Remove(userFruits);
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
        public bool UpdateSnacksQuantity(UsersFruits object1)
        {
            UsersFruits userFruits = new UsersFruits();
            bool update = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    userFruits = db.UsersFruits.Where(x => x.FruitId == object1.FruitId && x.UserId == object1.UserId).FirstOrDefault();
                    userFruits.QuantitySnacks = object1.QuantitySnacks;
                    if (object1.QuantityBreakfast > 0 || object1.QuantityDinner > 0 || object1.QuantityLunch > 0 || object1.QuantitySnacks > 0)
                    {
                        db.UsersFruits.Attach(userFruits);
                        db.Entry(userFruits).State = System.Data.Entity.EntityState.Modified;
                        update = true;
                    }
                    else
                    {
                        db.UsersFruits.Remove(userFruits);
                    }
                    db.SaveChanges();
                    
                }
                catch
                {

                }

            }
            return update;
        }

        public void CreateQuantity(UsersFruits object1)
        {
            UsersFruits userFruits = new UsersFruits();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.UsersFruits.Add(new UsersFruits
                {
                    UserId = object1.UserId,
                    FruitId = object1.FruitId,
                    QuantityBreakfast=object1.QuantityBreakfast,
                    QuantityDinner=object1.QuantityDinner,
                    QuantityLunch=object1.QuantityLunch,
                    QuantitySnacks=object1.QuantitySnacks
                });
                db.SaveChanges();

            }
            
        }

        public bool DeleteUserFruit(int id,string searchString)
        {
            bool returnValue = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    var userfruit = db.UsersFruits.Where(x => x.UserId == searchString && x.FruitId == id).FirstOrDefault();
                    db.UsersFruits.Remove(userfruit);
                    db.SaveChanges();
                    returnValue = true;
                }
                catch
                {

                }
                return returnValue;
            }
        }
        public bool DeleteUserFruits(List<UsersFruits> usersFruit)
        {
            bool returnValue = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    //var userfruit = db.UsersFruits.Where(x => x.UserId == searchString).Select(x => x).ToList();
                    db.UsersFruits.RemoveRange(usersFruit);
                    db.SaveChanges();
                    returnValue = true;
                }
                catch
                {

                }
                return returnValue;
            }
        }

        public double CountCalories(string userId)
        {
            double sumCal = 0;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var userfruits = db.UsersFruits.Where(x => x.UserId == userId).ToList();
                if (userfruits != null)
                {
                    foreach (var x in userfruits)
                    {
                        sumCal = sumCal + (x.QuantityBreakfast + x.QuantityDinner + x.QuantityLunch + x.QuantitySnacks) * x.Fruit.Calories;
                    }
                }
            }
            return sumCal;
        }





    }
}
