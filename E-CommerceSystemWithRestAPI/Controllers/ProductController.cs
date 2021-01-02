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
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        ProductRepository postController = new ProductRepository();

        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(postController.GetAll());
        }

        [Route("")]
        public IHttpActionResult Post(Product product)
        {
            if (ModelState.IsValid )
            {
                postController.Insert(product);
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

       
    }
}
