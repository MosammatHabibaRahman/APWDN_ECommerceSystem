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
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        CategoryRepository cr = new CategoryRepository();

        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(cr.GetAll());
        }

        [Route("{id}", Name = "GetCategoryById")]
        public IHttpActionResult Get(int id)
        {
            var post = cr.Get(id);
            if (post == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(cr.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Category category)
        {
            cr.Insert(category);
            string uri = Url.Link("GetCategoryById", new { id = category.CategoryId });
            return Created(uri, category);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Category category)
        {
            category.CategoryId = id;
            cr.Update(category);
            return Ok(category);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            cr.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
