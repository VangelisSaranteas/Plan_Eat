﻿using System;
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
    public class UserFruitSnacksApiController : ApiController
    {
        private readonly UsersFruitsRepository _userFruitsRepositoty = new UsersFruitsRepository();



        [HttpGet]
        public IHttpActionResult Get(int id,string searchString)
        {
            List<UsersFruits> breakfast = _userFruitsRepositoty.GetUserFruitsMeals(searchString)[3];
            return Ok(breakfast);
        }



        [HttpPatch]
        public IHttpActionResult Patch(UsersFruits object1)
        {
            
            return Ok(_userFruitsRepositoty.UpdateSnacksQuantity(object1));
        }

        [HttpPost]
        public IHttpActionResult Post(UsersFruits object1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _userFruitsRepositoty.CreateQuantity(object1);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id,string searchString)
        {
            bool removed = _userFruitsRepositoty.DeleteUserFruit(id,searchString);

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
