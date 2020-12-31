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
        ProductRepository pr = new ProductRepository();

        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(pr.GetAll());
        }
    }
}
