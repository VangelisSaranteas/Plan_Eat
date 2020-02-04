using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GuiltyPleasures.Repositories;
using Microsoft.AspNet.Identity;
using GuiltyPleasures.Models;

namespace GuiltyPleasures.Controllers
{
    public class GoalApiController : ApiController
    {
        private readonly UserGoalRepositoty _userGoalRepositoty = new UserGoalRepositoty();
        
        [HttpGet]
        public IHttpActionResult Get()
        {
            string userId = User.Identity.GetUserId();
            return Ok(_userGoalRepositoty.GetGoal(userId));
        }

        [HttpPatch]
        public IHttpActionResult Update(UserWithGoal userWithGoal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            string userId = User.Identity.GetUserId();
            userWithGoal.Id = userId;
            var updated = _userGoalRepositoty.SetGoal(userWithGoal);
            if (!updated)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}

