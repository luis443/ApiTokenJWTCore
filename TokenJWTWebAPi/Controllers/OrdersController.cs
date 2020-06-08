using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TokenJWTWebAPi.Model;
using TokenJWTWebAPi.Model.Interface;

namespace TokenJWTWebAPi.Controllers
{
   [Authorize]
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        IOrdersRepository Irepository;
        public OrdersController(IOrdersRepository repository)
        {
            Irepository = repository;
        }

        /// <summary>
        /// Obtener todas las ordenes
        /// </summary>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet]
        [Route("AllOrders")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var Ordenes = await Irepository.GetOrders();
                if (Ordenes == null)
                {
                    return NotFound();
                }
                return Ok(Ordenes);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        /// <summary>
        /// Gets All Categories
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpPost]
        [Route("RegistrarOrders")]
        public async Task<IActionResult> RegistrarOrden([FromBody] Orders orders)
        {
            try
            {
                var orden = await Irepository.RegistrarOrden(orders);
                if (orden == 0)
                {
                    return NotFound();
                }
                return Ok(orden);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        /// <summary>
        /// Gets All Categories
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpPut]
        [Route("ActualizarOrders")]
        public async Task<IActionResult> ActualizarOrden(Orders orders)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await Irepository.ActualizarOrden(orders);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        /// <summary>
        /// Gets All Categories
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("EliminarOrders")]
        public async Task<IActionResult> EliminarOrden(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await Irepository.EliminarOrden(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}