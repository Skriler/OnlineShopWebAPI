using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using OnlineShopWebAPI.Models;

namespace OnlineShopWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private ApplicationContext db;

        public ProductsController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Product>>> GetAsync()
        {
            return await db.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetAsync(int id)
        {
            Product product = await db.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            return new ObjectResult(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostAsync(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Products.Add(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<Product>> PutAsync(Product product)
        {
            if (product == null)
                return BadRequest();

            if (!db.Products.Any(p => p.Id == product.Id))
                return NotFound();

            db.Update(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteAsync(int id)
        {
            Product product = await db.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }
    }
}
