using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TokenJWTWebAPi.Data;
using TokenJWTWebAPi.Model;

namespace TokenJWTWebAPi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
          
        private ApplicationDbContext context;
        public ValuesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets All Categories
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return context.categories.Select(u => u.CategoryName).ToArray();
        }
       

     


        /// <summary>
        /// Gets All Categories
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
