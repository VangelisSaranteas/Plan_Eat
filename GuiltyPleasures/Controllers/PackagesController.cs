using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuiltyPleasures.Repositories;
using Microsoft.AspNet.Identity;

namespace GuiltyPleasures.Controllers
{
    public class PackagesController : Controller
    {
        private readonly PackageRepository _packageRepository = new PackageRepository();
        // GET: Packages
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            ViewBag.UserId = userId;
            return View(_packageRepository.GetPackages());
        }

        public ActionResult IndexAdmin()
        {
            string userId = User.Identity.GetUserId();
            ViewBag.UserId = userId;
            return View(_packageRepository.GetPackages());
        }
    }
}