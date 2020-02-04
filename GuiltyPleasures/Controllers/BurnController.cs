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
    public class BurnController : Controller
    {
        private readonly BurnRepository _burnsRepository = new BurnRepository();
        private readonly UsersBurnsRepository _usersburnsRepository = new UsersBurnsRepository();

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var Burns = _burnsRepository.GetBurn();

            return View(Burns);
        }
        public ActionResult IndexBurn()
        {
            string userId= User.Identity.GetUserId();
            var BurnsUserBurns = new BurnsUserBurnsViewModel();
            BurnsUserBurns.UserId = userId;
            BurnsUserBurns.Burns = _burnsRepository.GetBurn();
            BurnsUserBurns.UsersBurns= _usersburnsRepository.GetUserBurns(userId);
            return View(BurnsUserBurns);
        }


      
        public ActionResult IndexChosenBurn()
        {
            string currentUserId = User.Identity.GetUserId();
            return View(_burnsRepository.FindChosen(currentUserId));
        }

        public ActionResult Search(string name)
        {
            return View(_burnsRepository.Search(name));
        }

        //[Authorize(Roles = "Administrator")]
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    var roleManager = HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
        //    return View();
        //}

        //[Authorize(Roles = "Administrator")]
        //[HttpPost]
        //public ActionResult Create(Burn Burn)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(Burn);
        //    }

        //    _burnsRepository.AddBurn(Burn);

        //    return RedirectToAction("Index");
        //}
        //[Authorize(Roles = "Administrator")]
        //public ActionResult Edit(int id)
        //{
        //    var Burn = _BurnsRepository.FindById(id);
        //    return View(Burn);
        //}
        //[Authorize(Roles = "Administrator")]
        //public ActionResult Details(int id)
        //{
        //    var Burn = _BurnsRepository.FindById(id);
        //    return View(Burn);
        //}

        //[Authorize(Roles = "Administrator")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Burn Burn)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(Burn);
        //    }

        //    _BurnsRepository.UpdateBurn(Burn);

        //    return RedirectToAction("Index");
        //}

 
        //public ActionResult Chosen(int id, double quantity)
        //{

        //    string currentUserId = User.Identity.GetUserId();
        //    _burnsRepository.FindByIdAndChangeStateChosen(id, currentUserId,quantity);
        //    return RedirectToAction("IndexBreakfast");

        //}

        //public ActionResult ChosenLunch(int id, double quantity)
        //{
        //    string currentUserId = User.Identity.GetUserId();
        //    _BurnsRepository.FindByIdAndChangeStateChosenLunch(id, currentUserId, quantity);
        //    return RedirectToAction("IndexLunch");

        //}
        //public ActionResult ChosenDinner(int id, double quantity)
        //{
        //    string currentUserId = User.Identity.GetUserId();
        //    _BurnsRepository.FindByIdAndChangeStateChosenDinner(id, currentUserId, quantity);
        //    return RedirectToAction("IndexDinner");

        //}
        //public ActionResult ChosenSnacks(int id, double quantity)
        //{
        //    string currentUserId = User.Identity.GetUserId();
        //    _BurnsRepository.FindByIdAndChangeStateChosenSnacks(id, currentUserId, quantity);
        //    return RedirectToAction("IndexSnacks");

        //}

        //[Authorize(Roles = "Administrator")]
        //public ActionResult Delete(int id)
        //{
        //    var Burn = _BurnsRepository.FindById(id);
        //    return View(Burn);
        //}

        //[Authorize(Roles = "Administrator")]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirm(int id)
        //{
        //    _BurnsRepository.DeleteBurn(id);
        //    return RedirectToAction("Index");
        //}


    }
}