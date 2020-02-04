namespace GuiltyPleasures.Migrations
{
    using GuiltyPleasures.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuiltyPleasures.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            Seedfruits(context);
            Seedalcohol(context);
            Seedmeat(context);
            Seedmilk(context);
            Seedpasta(context);
            Seedsweet(context);
            Seedburn(context);
            //Seedmoney(context);
            Seedpackages(context);





            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                var role = new IdentityRole { Name = "Administrator" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var role = new IdentityRole { Name = "User" };
                manager.Create(role);
            }

            if (!context.Users.Any(user => user.UserName == "admin@guiltypleasure.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@guiltypleasure.com",
                    Email = "admin@guiltypleasure.com",
                    //FirstName = "Admin",
                    //LastName = "Admin"
                };

                var result = userManager.Create(user, "!Admin123");

                if (result.Succeeded)
                {
                    var admin = context.Users.SingleOrDefault(i => i.UserName == "admin@guiltypleasure.com");
                    userManager.AddToRoles(admin.Id, "Administrator", "User");
                }

            }



        }

        private void Seedfruits(ApplicationDbContext context)
        {
            context.Fruits.AddOrUpdate(
                 p => p.Name,
                  new Fruit { Name = "Banana", Calories = 105, Carbs = 27, Fat = 0.3, Protein = 0.5, Type = Convert.ToString(FoodType.Fruit),Portion="One Fruit" },
                 new Fruit { Name = "Apple", Calories = 95, Carbs = 95, Fat = 1, Protein = 1, Type = Convert.ToString(FoodType.Fruit), Portion = "One Fruit" },
                 new Fruit { Name = "Apricot", Calories = 17, Carbs = 3.9, Fat = 0.1, Protein = 0.5, Type = Convert.ToString(FoodType.Fruit), Portion = "One Fruit" },
                 new Fruit { Name = "Avocado", Calories = 322, Carbs = 17, Fat = 29, Protein = 4, Type = Convert.ToString(FoodType.Fruit), Portion = "One Fruit" },
                 new Fruit { Name = "Blackberry", Calories = 62, Carbs = 14, Fat = 0.7, Protein = 2, Type = Convert.ToString(FoodType.Fruit), Portion = "100 gr" },
                 new Fruit { Name = "Blueberry", Calories = 85, Carbs = 21, Fat = 0.5, Protein = 1.1, Type = Convert.ToString(FoodType.Fruit), Portion = "100 gr" },
                 new Fruit { Name = "Cantaloupe", Calories = 149, Carbs = 36, Fat = 0.8, Protein = 3.7, Type = Convert.ToString(FoodType.Fruit), Portion = "100 gr" },
                 new Fruit { Name = "Cherries", Calories = 77, Carbs = 19, Fat = 0.5, Protein = 1.6, Type = Convert.ToString(FoodType.Fruit), Portion = "One Fruit" },
                 new Fruit { Name = "Coconut", Calories = 283, Carbs = 12, Fat = 27, Protein = 3, Type = Convert.ToString(FoodType.Fruit), Portion = "One Fruit" },
                  new Fruit { Name = "Cranberries", Calories = 123, Carbs = 26.7, Fat = 0.5, Protein = 1.2, Type = Convert.ToString(FoodType.Fruit), Portion = "One Fruit" },
                 new Fruit { Name = "Grapefruit", Calories = 65, Carbs = 16, Fat = 0.2, Protein = 1.2, Type = Convert.ToString(FoodType.Fruit), Portion = "One Fruit" },
                 new Fruit { Name = "Grapes", Calories = 62, Carbs = 16, Fat = 0.3, Protein = 0.6, Type = Convert.ToString(FoodType.Fruit), Portion = "One Fruit" },
                 new Fruit { Name = "Lemon", Calories = 17, Carbs = 5, Fat = 0.2, Protein = 0.6, Type = Convert.ToString(FoodType.Fruit), Portion = "One Fruit" },
                 new Fruit { Name = "Mandarin", Calories = 47, Carbs = 12, Fat = 0.3, Protein = 0.7, Type = Convert.ToString(FoodType.Fruit), Portion = "One Fruit" },
                 new Fruit { Name = "Mango", Calories = 99, Carbs = 25, Fat = 1.1, Protein = 1.4, Type = Convert.ToString(FoodType.Fruit), Portion = "One Fruit" },
                 new Fruit { Name = "Nectarine", Calories = 63, Carbs = 15, Fat = 0.5, Protein = 1.5, Type = Convert.ToString(FoodType.Fruit), Portion = "One Fruit" },
                 new Fruit { Name = "Orange", Calories = 62, Carbs = 15, Fat = 0.2, Protein = 1.2, Type = Convert.ToString(FoodType.Fruit), Portion = "One Fruit" },
                 new Fruit { Name = "Peach", Calories = 59, Carbs = 14, Fat = 0.4, Protein = 1.4, Type = Convert.ToString(FoodType.Fruit), Portion = "One Fruit" },
                 new Fruit { Name = "Watermelon", Calories = 46, Carbs = 11, Fat = 1, Protein = 1, Type = Convert.ToString(FoodType.Fruit), Portion = "One Fruit" }
               );
        }
        private void Seedmilk(ApplicationDbContext context)
        {
            context.Fruits.AddOrUpdate(
                 p => p.Name,
                 new Fruit { Name = "Cottage cheese", Calories = 98, Carbs = 3.4, Fat = 4.3, Protein = 11, Type = Convert.ToString(FoodType.Milk), Portion = "100 gr" },
                 new Fruit { Name = "Condensed milk", Calories = 321, Carbs = 54, Fat = 9, Protein = 8, Type = Convert.ToString(FoodType.Milk), Portion = "100 gr" },
                 new Fruit { Name = "Cream cheese", Calories = 342, Carbs = 4.1, Fat = 34, Protein = 6, Type = Convert.ToString(FoodType.Milk), Portion = "100 gr" },
                 new Fruit { Name = "Edam cheese", Calories = 357, Carbs = 1.4, Fat = 28, Protein = 25, Type = Convert.ToString(FoodType.Milk), Portion = "100 gr" },
                 new Fruit { Name = "Feta cheese", Calories = 264, Carbs = 4.1, Fat = 21, Protein = 14, Type = Convert.ToString(FoodType.Milk), Portion = "100 gr" },
                 new Fruit { Name = "Frozen yoghurt", Calories = 159, Carbs = 24, Fat = 6, Protein = 4, Type = Convert.ToString(FoodType.Milk), Portion = "100 gr" },
                 new Fruit { Name = "Milk", Calories = 61, Carbs = 4.7, Fat = 3.3, Protein = 3.3, Type = Convert.ToString(FoodType.Milk), Portion = "100 gr" },
                 new Fruit { Name = "Mozzarella cheese", Calories = 280, Carbs = 3.1, Fat = 17, Protein = 28, Type = Convert.ToString(FoodType.Milk), Portion = "100 gr" },
                 new Fruit { Name = "Blue cheese", Calories = 353, Carbs = 2.3, Fat = 29, Protein = 21, Type = Convert.ToString(FoodType.Milk), Portion = "100 gr" },
                 new Fruit { Name = "Swiss  cheese", Calories = 380, Carbs = 5, Fat = 28, Protein = 27, Type = Convert.ToString(FoodType.Milk), Portion = "100 gr" },
                 new Fruit { Name = "Yogurt", Calories = 59, Carbs = 3.6, Fat = 3.1, Protein = 10, Type = Convert.ToString(FoodType.Milk), Portion = "100 gr" },
                 new Fruit { Name = "Gouda cheese", Calories = 356, Carbs = 2.2, Fat = 27, Protein = 25, Type = Convert.ToString(FoodType.Milk), Portion = "100 gr" },
                 new Fruit { Name = "Butter ", Calories = 717, Carbs = 0.1, Fat = 81, Protein = 0.9, Type = Convert.ToString(FoodType.Milk), Portion = "100 gr" }
               );
        }
        private void Seedmeat(ApplicationDbContext context)
        {
            context.Fruits.AddOrUpdate(
                 p => p.Name,
new Fruit { Name = "Beef", Calories = 250, Carbs = 5, Fat = 15, Protein = 26, Type = Convert.ToString(FoodType.Meat), Portion = "100 gr" },
                 new Fruit { Name = "Goat", Calories = 1, Carbs = 1, Fat = 1, Protein = 1, Type = Convert.ToString(FoodType.Meat), Portion = "100 gr" },
                 new Fruit { Name = "Lamb", Calories = 294, Carbs = 1, Fat = 21, Protein = 25, Type = Convert.ToString(FoodType.Meat), Portion = "100 gr" },
                 new Fruit { Name = "Chicken ", Calories = 239, Carbs = 1, Fat = 14, Protein = 27, Type = Convert.ToString(FoodType.Meat), Portion = "100 gr" },
                 new Fruit { Name = "Turkey", Calories = 189, Carbs = 0.1, Fat = 7, Protein = 29, Type = Convert.ToString(FoodType.Meat), Portion = "100 gr" },
                 new Fruit { Name = "Bacon ", Calories = 541, Carbs = 1.4, Fat = 42, Protein = 37, Type = Convert.ToString(FoodType.Meat), Portion = "100 gr" },
                 new Fruit { Name = "Salami ", Calories = 336, Carbs = 2.4, Fat = 26, Protein = 22, Type = Convert.ToString(FoodType.Meat), Portion = "100 gr" },
                 new Fruit { Name = "Steak ", Calories = 271, Carbs = 1, Fat = 19, Protein = 25, Type = Convert.ToString(FoodType.Meat), Portion = "100 gr" }
               );
        }
        private void Seedalcohol(ApplicationDbContext context)
        {
            context.Fruits.AddOrUpdate(
                 p => p.Name,
              new Fruit { Name = "Beer", Calories = 154, Carbs = 13, Fat = 0, Protein = 1.6, Type = Convert.ToString(FoodType.Alcohol), Portion = "1 Drink" },
                 new Fruit { Name = "Wine", Calories = 123, Carbs = 4, Fat = 1, Protein = 0.1, Type = Convert.ToString(FoodType.Alcohol),Portion = "1 Drink" },
                 new Fruit { Name = "Hard Cider", Calories = 152, Carbs = 21, Fat = 1, Protein = 1, Type = Convert.ToString(FoodType.Alcohol),Portion = "1 Drink" },
                 new Fruit { Name = "Gin", Calories = 110, Carbs = 1, Fat = 1, Protein = 1, Type = Convert.ToString(FoodType.Alcohol),Portion = "1 Drink" },
                 new Fruit { Name = "Brandy", Calories = 97, Carbs = 1, Fat = 1, Protein = 1, Type = Convert.ToString(FoodType.Alcohol), Portion = "1 Drink" },
                 new Fruit { Name = "Whiskey", Calories = 70, Carbs = 1, Fat = 1, Protein = 1, Type = Convert.ToString(FoodType.Alcohol),Portion = "1 Drink" },
                 new Fruit { Name = "Rum", Calories = 64, Carbs = 1, Fat = 1, Protein = 1, Type = Convert.ToString(FoodType.Alcohol),Portion = "1 Drink" }, 
                 new Fruit { Name = "Tequila", Calories = 68, Carbs = 1, Fat = 1, Protein = 1, Type = Convert.ToString(FoodType.Alcohol),Portion = "1 Drink" }, 
                 new Fruit { Name = "Vodka", Calories = 64, Carbs = 1, Fat = 1, Protein = 1, Type = Convert.ToString(FoodType.Alcohol), Portion = "1 Drink" },
                 new Fruit { Name = "Absinthe", Calories = 82, Carbs = 1, Fat = 1, Protein = 1, Type = Convert.ToString(FoodType.Alcohol), Portion = "1 Drink" },
                 new Fruit { Name = "Everclear", Calories = 1, Carbs = 1, Fat = 1, Protein = 1, Type = Convert.ToString(FoodType.Alcohol), Portion = "1 Drink" }
               );
        }
        private void Seedpasta(ApplicationDbContext context)
        {
            context.Fruits.AddOrUpdate(
                 p => p.Name,


 new Fruit { Name = "Carbonara", Calories = 764.5, Carbs = 90.8, Fat = 31.2, Protein = 28.8, Type = Convert.ToString(FoodType.Pasta), Portion = "100 gr" },
                 new Fruit { Name = "Vegan Bolognese", Calories = 395, Carbs = 61.4, Fat = 11.8, Protein = 16.8, Type = Convert.ToString(FoodType.Pasta), Portion = "100 gr" },
                 new Fruit { Name = "Greek Pasta with Tomatoes and  Beans", Calories = 432, Carbs = 77.7, Fat = 9, Protein = 23, Type = Convert.ToString(FoodType.Pasta), Portion = "100 gr" },
                 new Fruit { Name = "Ravioli with Coconut Milk", Calories = 350, Carbs = 351, Fat = 12, Protein = 19.3, Type = Convert.ToString(FoodType.Pasta), Portion = "100 gr" },
                 new Fruit { Name = "Bolognese", Calories = 646, Carbs = 81, Fat = 18, Protein = 35.8, Type = Convert.ToString(FoodType.Pasta), Portion = "100 gr" },
                 new Fruit { Name = "Penne Ala Vodka", Calories = 536, Carbs = 85, Fat = 26, Protein = 19, Type = Convert.ToString(FoodType.Pasta), Portion = "100 gr" },
                 new Fruit { Name = "Chicken Pasta", Calories = 568, Carbs = 101, Fat = 28.5, Protein = 32.3, Type = Convert.ToString(FoodType.Pasta), Portion = "100 gr" },
                 new Fruit { Name = "Pesto pasta", Calories = 432, Carbs = 75, Fat = 15.3, Protein = 22.3, Type = Convert.ToString(FoodType.Pasta), Portion = "100 gr" }
               );
        }
        private void Seedsweet(ApplicationDbContext context)
        {
            context.Fruits.AddOrUpdate(
                 p => p.Name,
                new Fruit { Name = "Apple Pie", Calories = 277, Carbs = 40, Fat = 13, Protein = 2.2, Type = Convert.ToString(FoodType.Sweet), Portion = "100 gr" },
                 new Fruit { Name = "Butter Cake", Calories = 116, Carbs = 15, Fat = 6, Protein = 1.7, Type = Convert.ToString(FoodType.Sweet), Portion = "100 gr" },
                 new Fruit { Name = "Pound Cake", Calories = 116, Carbs = 17, Fat = 6, Protein = 1.8, Type = Convert.ToString(FoodType.Sweet), Portion = "100 gr" },
                 new Fruit { Name = "Biscuit Cake", Calories = 128, Carbs = 1, Fat = 1, Protein = 1.4, Type = Convert.ToString(FoodType.Sweet), Portion = "100 gr" },
                 new Fruit { Name = "Bougatsa", Calories = 220, Carbs = 33.8, Fat = 14.3, Protein = 6.2, Type = Convert.ToString(FoodType.Sweet), Portion = "100 gr" },
                 new Fruit { Name = "Cheesecake", Calories = 257, Carbs = 20, Fat = 18, Protein = 4.4, Type = Convert.ToString(FoodType.Sweet), Portion = "100 gr" },
                 new Fruit { Name = "Cherry pie", Calories = 287, Carbs = 51, Fat = 15, Protein = 1.9, Type = Convert.ToString(FoodType.Sweet), Portion = "100 gr" },
                 new Fruit { Name = "Chocolate brownie", Calories = 132, Carbs = 14, Fat = 11, Protein = 1.8, Type = Convert.ToString(FoodType.Sweet), Portion = "100 gr" },
                 new Fruit { Name = "Ice cream", Calories = 1, Carbs = 1, Fat = 1, Protein = 1, Type = Convert.ToString(FoodType.Sweet), Portion = "100 gr" }
               );
        }
        private void Seedburn(ApplicationDbContext context)
        {
            context.Burns.AddOrUpdate(
                 p => p.Name,
                new Burn { Name = "Aerobic", Calories = 225, Time = 30 },
                 new Burn { Name = "Yoga", Calories = 150, Time = 30 },
                 new Burn { Name = "Pilates", Calories = 199,  Time = 30 },
                 new Burn { Name = "Calisthenics ", Calories = 298, Time = 30 },
                 new Burn { Name = "Strength Training", Calories = 302, Time = 30 },
                 new Burn { Name = "Footbal", Calories = 365,  Time = 30 },
                 new Burn { Name = "Basketball", Calories = 289,  Time = 30 },
                 new Burn { Name = "Swimming", Calories = 245,  Time = 30 }
               );
        }
        private void Seedpackages(ApplicationDbContext context)
        {
            context.Packages.AddOrUpdate(
                 p => p.Name,
                 new Package { Name = "Classic", Description = "Complete and balanced menu, based on Mediterranean diet standards", Price = 45 },
                  new Package { Name = "Business", Description = "Complete and balanced menu, ideal for those who spend hours at work", Price = 50 },
                   new Package { Name = "Veggie", Description = "Complete and balanced menu, characterized by the absence of meat, fish, dairy products, sausages, butter, seafood and eggs", Price = 55 }

               );
        }
    }
}
