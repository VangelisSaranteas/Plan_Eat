using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using GuiltyPleasures.Repositories;
using Microsoft.AspNet.Identity;
using GuiltyPleasures.Models;

namespace GuiltyPleasures.Controllers
{
    public class UserFruitApiAllController : ApiController
    {
        private readonly UsersFruitsRepository _userFruitsRepositoty = new UsersFruitsRepository();

        [HttpGet]
        public IHttpActionResult Get(int id, string searchString)
        {
            List<UsersFruits> breakfast = _userFruitsRepositoty.GetUserFruitsMeals(searchString)[4];
            return Ok(breakfast);
        }

        [HttpGet]
        public IHttpActionResult CountCals(int id, string searchString,string filterString)
        {
            double cals = _userFruitsRepositoty.CountCalories(searchString);
            return Ok(cals);

        }
    }
}
