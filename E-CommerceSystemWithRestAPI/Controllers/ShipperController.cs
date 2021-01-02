using E_CommerceSystemWithRestAPI.Models;
using E_CommerceSystemWithRestAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_CommerceSystemWithRestAPI.Controllers
{
    [RoutePrefix("api/shippers")]
    public class ShipperController : ApiController
    {
        ShipperRepository shipperRepo = new ShipperRepository();

        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(shipperRepo.GetAll());
        }

        [Route("{id}", Name = "GetShipperById")]
        public IHttpActionResult Get(int id)
        {
            var shipper = shipperRepo.Get(id);
            if (shipper == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(shipperRepo.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Shipper shipper)
        {
            shipperRepo.Insert(shipper);
            string uri = Url.Link("GetShipperById", new { id = shipper.ShipperId });
            return Created(uri, shipper);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Shipper shipper)
        {
            shipper.ShipperId = id;
            shipperRepo.Update(shipper);
            return Ok(shipper);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            shipperRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
