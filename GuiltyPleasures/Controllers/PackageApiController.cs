using GuiltyPleasures.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GuiltyPleasures.Repositories;

namespace GuiltyPleasures.Controllers
{
    public class PackageApiController : ApiController
    {
        private readonly PackageRepository _packageRepositoty = new PackageRepository();

        public IHttpActionResult Get()
        {
            return Ok(_packageRepositoty.GetPackages());
        }
        [HttpGet]
        public IHttpActionResult Find(int id)
        {
            return Ok(_packageRepositoty.FindById(id));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _packageRepositoty.Add(package);
            return Ok(package);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            bool removed = _packageRepositoty.Deletebool(id);

            if (!removed)
            {
                // CustomError error = new CustomError { Id = 400, Description = "Item not found" };
                // return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, error));
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Ok();
        }

        [HttpPatch]
        public IHttpActionResult Update([FromBody]Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var updated = _packageRepositoty.Updatebool(package);

            if (!updated)
            {
                return NotFound();
            }

            return Ok();
        }


        //public IHttpActionResult Get(int id,string searchString)
        //{
        //    return Ok(_packageRepositoty.GetBalance(searchString));
        //} 
        [HttpPatch]
        public IHttpActionResult Update([FromBody]UserWithGoal userWithGoal,int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            string userId = User.Identity.GetUserId();
            userWithGoal.Id = userId;
            var updated = _packageRepositoty.BuyPackagePartGoal(userId, userWithGoal.PackageId);
            if (!updated)
            {
                return NotFound();
            }

            return Ok();
        }

        //[HttpPatch]
        //public IHttpActionResult Money([FromBody]Money money,int id, string searchString)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    var updated = _packageRepositoty.BuyPackagePartMoney(searchString, money.Balance);
        //    if (!updated)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(money.Balance);
        //}

    }
}
