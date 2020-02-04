using GuiltyPleasures.Models;
using GuiltyPleasures.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuiltyPleasures.Controllers
{

    [Authorize(Roles = "User")]
    public class FruitController : Controller
    {
        private readonly FruitRepository _fruitsRepository = new FruitRepository();
        private readonly UsersFruitsRepository _usersfruitsRepository = new UsersFruitsRepository();

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var fruits = _fruitsRepository.GetFruit();

            return View(fruits);
        }
        public ActionResult IndexBreakfast()
        {
            string userId= User.Identity.GetUserId();
            var fruitsUserFruits = new FruitsUserFruitsViewModel();
            fruitsUserFruits.UserId = userId;
            fruitsUserFruits.Fruits = _fruitsRepository.GetFruit();
            fruitsUserFruits.UsersFruitsBreakfast= _usersfruitsRepository.GetUserFruitsMeals(userId)[0];
            fruitsUserFruits.UsersFruitsLunch = _usersfruitsRepository.GetUserFruitsMeals(userId)[1];
            fruitsUserFruits.UsersFruitsDinner = _usersfruitsRepository.GetUserFruitsMeals(userId)[2];
            fruitsUserFruits.UsersFruitsSnacks = _usersfruitsRepository.GetUserFruitsMeals(userId)[3];
            fruitsUserFruits.UsersFruitsAll = _usersfruitsRepository.GetUserFruitsMeals(userId)[4];
            return View(fruitsUserFruits);
        }
        public ActionResult IndexLunch()
        {
            string userId = User.Identity.GetUserId();
            var fruitsUserFruits = new FruitsUserFruitsViewModel();
            fruitsUserFruits.UserId = userId;
            fruitsUserFruits.Fruits = _fruitsRepository.GetFruit();
            fruitsUserFruits.UsersFruitsBreakfast = _usersfruitsRepository.GetUserFruitsMeals(userId)[0];
            fruitsUserFruits.UsersFruitsLunch = _usersfruitsRepository.GetUserFruitsMeals(userId)[1];
            fruitsUserFruits.UsersFruitsDinner = _usersfruitsRepository.GetUserFruitsMeals(userId)[2];
            fruitsUserFruits.UsersFruitsSnacks = _usersfruitsRepository.GetUserFruitsMeals(userId)[3];
            fruitsUserFruits.UsersFruitsAll = _usersfruitsRepository.GetUserFruitsMeals(userId)[4];
            return View(fruitsUserFruits);
        
    }

        public ActionResult IndexDinner()
        {
            string userId = User.Identity.GetUserId();
            var fruitsUserFruits = new FruitsUserFruitsViewModel();
            fruitsUserFruits.UserId = userId;
            fruitsUserFruits.Fruits = _fruitsRepository.GetFruit();
            fruitsUserFruits.UsersFruitsBreakfast = _usersfruitsRepository.GetUserFruitsMeals(userId)[0];
            fruitsUserFruits.UsersFruitsLunch = _usersfruitsRepository.GetUserFruitsMeals(userId)[1];
            fruitsUserFruits.UsersFruitsDinner = _usersfruitsRepository.GetUserFruitsMeals(userId)[2];
            fruitsUserFruits.UsersFruitsSnacks = _usersfruitsRepository.GetUserFruitsMeals(userId)[3];
            fruitsUserFruits.UsersFruitsAll = _usersfruitsRepository.GetUserFruitsMeals(userId)[4];
            return View(fruitsUserFruits);

        }

        public ActionResult IndexSnacks()
        {
            string userId = User.Identity.GetUserId();
            var fruitsUserFruits = new FruitsUserFruitsViewModel();
            fruitsUserFruits.UserId = userId;
            fruitsUserFruits.Fruits = _fruitsRepository.GetFruit();
            fruitsUserFruits.UsersFruitsBreakfast = _usersfruitsRepository.GetUserFruitsMeals(userId)[0];
            fruitsUserFruits.UsersFruitsLunch = _usersfruitsRepository.GetUserFruitsMeals(userId)[1];
            fruitsUserFruits.UsersFruitsDinner = _usersfruitsRepository.GetUserFruitsMeals(userId)[2];
            fruitsUserFruits.UsersFruitsSnacks = _usersfruitsRepository.GetUserFruitsMeals(userId)[3];
            fruitsUserFruits.UsersFruitsAll = _usersfruitsRepository.GetUserFruitsMeals(userId)[4];
            return View(fruitsUserFruits);

        }

      
        public ActionResult IndexChosenBreakfast()
        {
            string currentUserId = User.Identity.GetUserId();
            return View(_fruitsRepository.FindChosenBreakfast(currentUserId));
        }
        public ActionResult IndexChosenLunch()
        {
            string currentUserId = User.Identity.GetUserId();
            return View(_fruitsRepository.FindChosenLunch(currentUserId));
        }
        public ActionResult IndexChosenDinner()
        {
            string currentUserId = User.Identity.GetUserId();
            return View(_fruitsRepository.FindChosenDinner(currentUserId));
        }
        public ActionResult IndexChosenSnacks()
        {
            string currentUserId = User.Identity.GetUserId();
            return View(_fruitsRepository.FindChosenSnacks(currentUserId));
        }
        public ActionResult Search(string name)
        {
            return View(_fruitsRepository.Search(name));
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Create()
        {
            var roleManager = HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Create(Fruit fruit)
        {
            if (!ModelState.IsValid)
            {
                return View(fruit);
            }

            _fruitsRepository.AddFruit(fruit);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            var fruit = _fruitsRepository.FindById(id);
            return View(fruit);
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int id)
        {
            var fruit = _fruitsRepository.FindById(id);
            return View(fruit);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fruit fruit)
        {
            if (!ModelState.IsValid)
            {
                return View(fruit);
            }

            _fruitsRepository.UpdateFruit(fruit);

            return RedirectToAction("Index");
        }

 
        public ActionResult ChosenBreakfast(int id, double quantity)
        {

            string currentUserId = User.Identity.GetUserId();
            _fruitsRepository.FindByIdAndChangeStateChosenBreakfast(id, currentUserId,quantity);
            return RedirectToAction("IndexBreakfast");

        }

        public ActionResult ChosenLunch(int id, double quantity)
        {
            string currentUserId = User.Identity.GetUserId();
            _fruitsRepository.FindByIdAndChangeStateChosenLunch(id, currentUserId, quantity);
            return RedirectToAction("IndexLunch");

        }
        public ActionResult ChosenDinner(int id, double quantity)
        {
            string currentUserId = User.Identity.GetUserId();
            _fruitsRepository.FindByIdAndChangeStateChosenDinner(id, currentUserId, quantity);
            return RedirectToAction("IndexDinner");

        }
        public ActionResult ChosenSnacks(int id, double quantity)
        {
            string currentUserId = User.Identity.GetUserId();
            _fruitsRepository.FindByIdAndChangeStateChosenSnacks(id, currentUserId, quantity);
            return RedirectToAction("IndexSnacks");

        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            var fruit = _fruitsRepository.FindById(id);
            return View(fruit);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            _fruitsRepository.DeleteFruit(id);
            return RedirectToAction("Index");
        }

        
        public ActionResult SetGoal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SetGoal(string calories)
        {
            ViewBag.calories = calories;
            return View("SetGoal1",calories);
        }

    }
}