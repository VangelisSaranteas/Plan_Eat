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
   
    public class FruitApiController : ApiController
    {
        private readonly FruitRepository _fruitRepository = new FruitRepository();
   
    [HttpGet]
    public IHttpActionResult Get()
        {
            return Ok(_fruitRepository.GetFruit());
        }

        [HttpGet]
        public IHttpActionResult Find(int id)
        {
            return Ok(_fruitRepository.FindById(id));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]Fruit fruit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _fruitRepository.AddFruit(fruit);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            bool removed = _fruitRepository.DeleteFruitbool(id);

            if (!removed)
            {
                // CustomError error = new CustomError { Id = 400, Description = "Item not found" };
                // return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, error));
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Ok();
        }

        [HttpPatch]
        public IHttpActionResult Update([FromBody]Fruit fruit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var updated = _fruitRepository.UpdateFruitbool(fruit);

            if (!updated)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetSearch(int id,string searchString)
        {
            return Ok(_fruitRepository.GetFruit(id,searchString));
        }

        [HttpGet]
        public IHttpActionResult GetFilter(int id, string searchString, string filterString)
        {
            return Ok(_fruitRepository.GetFruitFilter( filterString));
        }

        [HttpGet]
        public IHttpActionResult GetSearchFilter(int id, string searchString, string filterString,double quantity)
        {
            return Ok(_fruitRepository.GetFruitFilterSearch(searchString, filterString));
        }

    }
}
