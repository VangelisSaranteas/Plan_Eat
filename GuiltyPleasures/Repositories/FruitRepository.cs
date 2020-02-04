using GuiltyPleasures.Models;
using HelperMyApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuiltyPleasures.Repositories
{
    public class FruitRepository
    {
        public IEnumerable<Fruit> GetFruit()
        {
            IEnumerable<Fruit> fruits;

            using( ApplicationDbContext db = new ApplicationDbContext())
            {

                fruits = db.Fruits.ToList();
                
            }

            return fruits;
        }

        public IEnumerable<Fruit> GetFruit(int id,string searchString)
        {
            IEnumerable<Fruit> fruits;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                fruits = db.Fruits.Where(x => x.Name.Contains(searchString)).ToList();
            }

            return fruits;
        }
        public IEnumerable<Fruit> GetFruitFilter(string filterString)
        {
            IEnumerable<Fruit> fruits;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                fruits = db.Fruits.Where(x => x.Type.Contains(filterString)).ToList();
            }

            return fruits;
        }

        public IEnumerable<Fruit> GetFruitFilterSearch(string searchString,string filterString)
        {
            IEnumerable<Fruit> fruits;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                fruits = db.Fruits.Where(x => x.Type.Contains(filterString) && x.Name.Contains(searchString)).ToList();
            }

            return fruits;
        }
        public void AddFruit(Fruit fruit)
        {
           // Throw.IfNullOrWhiteSpace(name, "Name cannot be null or whitespace");

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Fruits.Add(new Fruit
                {
                    Name = fruit.Name,
                    Calories = fruit.Calories,
                    Carbs = fruit.Carbs,
                    Fat = fruit.Fat,
                    Protein = fruit.Protein,
                    Type=fruit.Type,
                    Portion=fruit.Portion
                    
                });;

                db.SaveChanges();
            }
        }

        public void UpdateFruit(Fruit fruit)
        {
            Throw.IfNull(fruit, nameof(fruit));

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Fruits.Attach(fruit);
                db.Entry(fruit).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public bool UpdateFruitbool(Fruit fruit)
        {
            Throw.IfNull(fruit, nameof(fruit));
            bool updatebool = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    db.Fruits.Attach(fruit);
                    db.Entry(fruit).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    updatebool = true;
                }
                catch
                {

                }
            }
            return updatebool;
        }

        public void DeleteFruit(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var fruit = db.Fruits.Find(id);
                db.Fruits.Remove(fruit);
                db.SaveChanges();
            }
        }
        public bool DeleteFruitbool(int id)
        {
            bool returnValue = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var fruit = db.Fruits.Find(id);
                try
                {
                    db.Fruits.Remove(fruit);
                    db.SaveChanges();
                    returnValue = true;
                }
                catch
                {

                }
                
            }
            return returnValue;
        }

        public Fruit FindById(int id)
        {
            Fruit fruit;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                fruit = db.Fruits.Find(id);
            }

            return fruit;
        }

        public void FindByIdAndChangeStateChosenBreakfast(int id, string userId,double quantity)
        {

            UsersFruits userfruits = new UsersFruits();
            Fruit fruit;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                fruit = db.Fruits.SingleOrDefault(x => x.FruitId == id);
                userfruits = db.UsersFruits.SingleOrDefault(x => x.UserId == userId && x.FruitId == id);
                if (userfruits==null)
                {
                    UsersFruits userfruits1 = new UsersFruits()
                    {
                        FruitId = id,
                        UserId=userId,
                        QuantityBreakfast=quantity
                    };
                    db.UsersFruits.Add(userfruits1);
               
                }
                else 
                {
                        userfruits.QuantityBreakfast = quantity;
                }
                db.SaveChanges();
            }


        }

        public void FindByIdAndChangeStateChosenLunch(int id, string userId, double quantity)
        {

            UsersFruits userfruits = new UsersFruits();
            Fruit fruit;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                fruit = db.Fruits.SingleOrDefault(x => x.FruitId == id);
                userfruits = db.UsersFruits.SingleOrDefault(x => x.UserId == userId && x.FruitId == id);
                if (userfruits == null)
                {
                    UsersFruits userfruits1 = new UsersFruits()
                    {
                        FruitId = id,
                        UserId = userId,
                        QuantityLunch = quantity
                    };
                    db.UsersFruits.Add(userfruits1);

                }
                else
                {
                        userfruits.QuantityLunch = quantity;

                }
                db.SaveChanges();
            }


        }
        public void FindByIdAndChangeStateChosenDinner(int id, string userId, double quantity)
        {

            UsersFruits userfruits = new UsersFruits();
            Fruit fruit;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                fruit = db.Fruits.SingleOrDefault(x => x.FruitId == id);
                userfruits = db.UsersFruits.SingleOrDefault(x => x.UserId == userId && x.FruitId == id);
                if (userfruits == null)
                {
                    UsersFruits userfruits1 = new UsersFruits()
                    {
                        FruitId = id,
                        UserId = userId,
                        QuantityDinner = quantity
                    };
                    db.UsersFruits.Add(userfruits1);

                }
                else
                {

                        userfruits.QuantityDinner = quantity;

                }
                db.SaveChanges();
            }


        }
        public void FindByIdAndChangeStateChosenSnacks(int id, string userId, double quantity)
        {

            UsersFruits userfruits = new UsersFruits();
            Fruit fruit;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                fruit = db.Fruits.SingleOrDefault(x => x.FruitId == id);
                userfruits = db.UsersFruits.SingleOrDefault(x => x.UserId == userId && x.FruitId == id);
                if (userfruits == null)
                {
                    UsersFruits userfruits1 = new UsersFruits()
                    {
                        FruitId = id,
                        UserId = userId,
                        QuantitySnacks = quantity
                    };
                    db.UsersFruits.Add(userfruits1);

                }
                else
                {
                        userfruits.QuantitySnacks = quantity;

                }
                db.SaveChanges();
            }


        }

        //nomizw palia
        //public IEnumerable<UsersFruits> FindChosen(string currentUserId)
        //{
        //    IEnumerable<UsersFruits> fruits;
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //       fruits = db.UsersFruits.Include("Fruit").Where(x => x.IsChosen == true && x.UserId == currentUserId).ToList();                  
                               
                
        //    }

        //    return fruits;
        //}
        public IEnumerable<UsersFruits> FindChosenBreakfast(string currentUserId)
        {
            IEnumerable<UsersFruits> fruits;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                fruits = db.UsersFruits.Include("Fruit").Where(x => x.QuantityBreakfast>0 && x.UserId == currentUserId).ToList();


            }

            return fruits;
        }
        public IEnumerable<UsersFruits> FindChosenDinner(string currentUserId)
        {
            IEnumerable<UsersFruits> fruits;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                fruits = db.UsersFruits.Include("Fruit").Where(x => x.QuantityDinner>0 && x.UserId == currentUserId).ToList();


            }

            return fruits;
        }
        public IEnumerable<UsersFruits> FindChosenLunch(string currentUserId)
        {
            IEnumerable<UsersFruits> fruits;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                fruits = db.UsersFruits.Include("Fruit").Where(x => x.QuantityLunch>0 && x.UserId == currentUserId).ToList();


            }

            return fruits;
        }
        public IEnumerable<UsersFruits> FindChosenSnacks(string currentUserId)
        {
            IEnumerable<UsersFruits> fruits;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                fruits = db.UsersFruits.Include("Fruit").Where(x => x.QuantitySnacks>0 == true && x.UserId == currentUserId).ToList();


            }

            return fruits;
        }

        public Fruit Search(string name)
        {
            Fruit fruit;
            using (ApplicationDbContext db =new ApplicationDbContext())
            {
               fruit = db.Fruits.SingleOrDefault(x => x.Name == name);
            }
            return fruit;
        }

    }
}