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
    [RoutePrefix("api/offers")]
    public class OfferController : ApiController
    {
        OfferRepository offerRepo = new OfferRepository();

        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(offerRepo.GetAll());
        }

        [Route("{id}", Name = "GetOfferById")]
        public IHttpActionResult Get(int id)
        {
            var category = offerRepo.Get(id);
            if (category == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(offerRepo.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Offer offer)
        {
            offerRepo.Insert(offer);
            string uri = Url.Link("GetOfferById", new { id = offer.OfferId });
            return Created(uri, offer);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Offer offer)
        {
            offer.OfferId = id;
            offerRepo.Update(offer);
            return Ok(offer);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            offerRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
