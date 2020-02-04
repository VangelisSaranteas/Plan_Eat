using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GuiltyPleasures.Models;
using GuiltyPleasures.Repositories;

namespace GuiltyPleasures.Controllers
{
   
    public class BurnApiController : ApiController
    {
        private readonly BurnRepository _burnRepository = new BurnRepository();
   
    [HttpGet]
    public IHttpActionResult Get()
        {
            return Ok(_burnRepository.GetBurn());
        }

        [HttpGet]
        public IHttpActionResult Find(int id)
        {
            return Ok(_burnRepository.FindById(id));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]Burn burn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _burnRepository.AddBurn(burn);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            bool removed = _burnRepository.DeleteBurnbool(id);

            if (!removed)
            {
                // CustomError error = new CustomError { Id = 400, Description = "Item not found" };
                // return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, error));
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Ok();
        }

        [HttpPatch]
        public IHttpActionResult Update([FromBody]Burn burn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var updated = _burnRepository.UpdateBurnbool(burn);

            if (!updated)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetSearch(int id,string searchString)
        {
            return Ok(_burnRepository.GetBurn(id,searchString));
        }


    }
}
