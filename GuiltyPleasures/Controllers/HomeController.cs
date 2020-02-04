using GuiltyPleasures.Models;
using GuiltyPleasures.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuiltyPleasures.Controllers
{
    [Authorize(Roles = "User")]
    public class HomeController : Controller
    {
        private readonly UsersRepository _usersRepository = new UsersRepository();
        private readonly UsersFruitsRepository _usersFruitsRepository = new UsersFruitsRepository();
        private readonly UsersBurnsRepository _usersBurnsRepository = new UsersBurnsRepository();
        private readonly FruitRepository _fruitsRepository = new FruitRepository();
        private readonly BurnRepository _burnsRepository = new BurnRepository();
        private readonly UsersBurnsRepository _usersburnsRepository = new UsersBurnsRepository();
        public ActionResult Index(bool? asadmin)
        {
            bool admin = User.IsInRole("Administrator");
            if (admin == true)
            {
                return View("Admin");
            }
            else
            {
                return RedirectToAction("About");
            }

        }



        [HttpPost]
        public  ActionResult Index(UserWithGoal applicationUser)
        {
           
           _usersRepository.SaveUser(applicationUser);
           return RedirectToAction("About",applicationUser);
        }

        public ActionResult About()
        {
            string currentUserId;
            ApplicationUser currentUser;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                currentUserId = User.Identity.GetUserId();
                currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            }
            // List<UsersFruits>[] fruitsBreakfast = _usersFruitsRepository.GetUserFruitsMeals(currentUserId);
            AboutViewModel aboutViewModel = new AboutViewModel();
                aboutViewModel.NutritionBreakfast = _usersFruitsRepository.CountCaloriesBreakfast(currentUserId).ToList();
            aboutViewModel.NutritionLunch = _usersFruitsRepository.CountCaloriesLunch(currentUserId).ToList();
            aboutViewModel.NutritionDinner = _usersFruitsRepository.CountCaloriesDinner(currentUserId).ToList();
            aboutViewModel.NutritionSnacks = _usersFruitsRepository.CountCaloriesSnacks(currentUserId).ToList();
            aboutViewModel.NutritionBurn = _usersBurnsRepository.CountCalories(currentUserId).ToList();
            aboutViewModel.UserId = currentUserId;

            BurnsUserBurnsViewModel BurnsUserBurns = new BurnsUserBurnsViewModel();
            BurnsUserBurns.UserId = currentUserId;
            BurnsUserBurns.Burns = _burnsRepository.GetBurn();
            BurnsUserBurns.UsersBurns = _usersburnsRepository.GetUserBurns(currentUserId);

            Together together = new Together();
            var fruitsUserFruits = new FruitsUserFruitsViewModel();
            fruitsUserFruits.UserId = currentUserId;
            fruitsUserFruits.Fruits = _fruitsRepository.GetFruit();
            fruitsUserFruits.UsersFruitsBreakfast = _usersFruitsRepository.GetUserFruitsMeals(currentUserId)[0];
            fruitsUserFruits.UsersFruitsLunch = _usersFruitsRepository.GetUserFruitsMeals(currentUserId)[1];
            fruitsUserFruits.UsersFruitsDinner = _usersFruitsRepository.GetUserFruitsMeals(currentUserId)[2];
            fruitsUserFruits.UsersFruitsSnacks = _usersFruitsRepository.GetUserFruitsMeals(currentUserId)[3];
            fruitsUserFruits.UsersFruitsAll = _usersFruitsRepository.GetUserFruitsMeals(currentUserId)[4];
            together.AboutViewModel = aboutViewModel;
            together.FruitsUserFruitsViewModel = fruitsUserFruits;
            together.BurnsUserBurnsViewModel = BurnsUserBurns;
            return View(together);
        }

    }
}