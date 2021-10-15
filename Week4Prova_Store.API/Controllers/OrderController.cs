using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week4Prova_Store.Core.Interfaces;
using Week4Prova_Store.Core.Models;

namespace Week4Prova_Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IMainBusinessLayer mainBusinessLayer;

        public OrderController(IMainBusinessLayer mainBusinessLayer)
        {
            this.mainBusinessLayer = mainBusinessLayer;
        }


        // GET: api/Order
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = mainBusinessLayer.FetchOrders();
            return Ok(orders);
        }

        // GET api/Order/5
        [HttpGet("{id}")]
        public IActionResult GetOrderBy(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Order ID.");

            Order order = this.mainBusinessLayer.GetOrderById(id);

            if (order == null)
                return NotFound($"Order with ID = {id} is missing.");

            return Ok(order);
        }

        // POST api/order
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order newOrder)
        {
            if (newOrder == null)
                return BadRequest("Invalid data.");

            if (!this.mainBusinessLayer.CreateOrder(newOrder))
                return BadRequest("Addition not completed");

            return CreatedAtAction("CreateOrder", new { id = newOrder.Id }, newOrder);
        }

        // PUT api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order editedOrder)
        {
            if (editedOrder == null)
                return BadRequest("Invalid data.");

            if (id != editedOrder.Id)
                return BadRequest("Ids don't match ");

            if (!this.mainBusinessLayer.EditOrder(editedOrder))
                return BadRequest("Operation not completed ");

            return Ok();
        }

        // DELETE api/order/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID.");

            var result = this.mainBusinessLayer.DeleteOrder(id);

            if (!result)
                return StatusCode(500, "Operation not completed ");

            return Ok();
        }
    }
}
