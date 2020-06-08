using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenJWTWebAPi.Model.Interface;

namespace TokenJWTWebAPi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        IProductsRepository Irepository;
        public ProductsController(IProductsRepository repository)
        {
            Irepository = repository;
        }
        /// <summary>
        /// Obtener todas las ordenes
        /// </summary>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet]
        [Route("AllProducts")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await Irepository.GetProductsAsync();
                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
    }
}