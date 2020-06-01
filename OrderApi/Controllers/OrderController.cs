using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderApi.Models;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly OrderContext orderDb;

        public OrderController(OrderContext context)
        {
            this.orderDb = context;
        }

        // GET: api/order/{id}  id为路径参数
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(long id)
        {
            var order = orderDb.Orders.FirstOrDefault(t => t.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        // GET: api/order/{cusname}  cusname为路径参数
        [HttpGet]
        public ActionResult<List<Order>> GetOrder(string cusname)
        {
            var query = buildQuery(cusname);
            return query.ToList();
        }

        private IQueryable<Order> buildQuery(string cusname)
        {
            IQueryable<Order> query = orderDb.Orders;
            if (cusname != null)
            {
                query = query.Where(t => t.CusName.Contains(cusname));
            }
            return query;
        }

        // POST: api/todo
        [HttpPost]
        public ActionResult<Order> PostTodoItem(Order order)
        {
            try
            {
                orderDb.Orders.Add(order);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }

        // PUT: api/order/{id}
        [HttpPut("{id}")]
        public ActionResult<Order> PutOrdere(long id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                orderDb.Entry(order).State = EntityState.Modified;
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        // DELETE: api/order/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(long id)
        {
            try
            {
                var order = orderDb.Orders.FirstOrDefault(t => t.OrderId == id);
                if (order != null)
                {
                    orderDb.Remove(order);
                    orderDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

    }
}