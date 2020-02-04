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
    public class UserBurnApiController : ApiController
    {
        private readonly UsersBurnsRepository _userBurnsRepositoty = new UsersBurnsRepository();

        [HttpGet]
        public IHttpActionResult Get(int id, string searchString)
        {
            List<UsersBurns> breakfast = _userBurnsRepositoty.GetUserBurns(searchString);
            return Ok(breakfast);
        }



        [HttpPatch]
        public IHttpActionResult Patch(UsersBurns object1)
        {
            
            return Ok(_userBurnsRepositoty.UpdateDuration(object1));
        }

        [HttpPost]
        public IHttpActionResult Post(UsersBurns object1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _userBurnsRepositoty.CreateQuantity(object1);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id,string searchString)
        {
            bool removed = _userBurnsRepositoty.DeleteUserBurn(id,searchString);

            if (!removed)
            {
                // CustomError error = new CustomError { Id = 400, Description = "Item not found" };
                // return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, error));
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Ok();
        }
    }
}
