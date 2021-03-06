﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SingularityLimitedPhaseOneTest.Data;
using SingularityLimitedPhaseOneTest.Models;
using SingularityLimitedPhaseOneTest.Models.Dtos;

namespace SingularityLimitedPhaseOneTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly SingularityLimitedPhaseOneTestContext _context;

        public ProductsController(SingularityLimitedPhaseOneTestContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.Where(p => p.DeleteStatus != true).ToListAsync();
        }

        [HttpGet("GetTrashProduct")]
        public async Task<ActionResult<IEnumerable<Product>>> GetTrashProduct()
        {
            return await _context.Product.Where(p => p.DeleteStatus == true).ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null || product.DeleteStatus == true)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost("RecoverProduct/{id}")]
        public async Task<ActionResult<Product>> RecoverProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product.DeleteStatus = false;

            await _context.SaveChangesAsync();
            return product;
        }

        [HttpPost("LockProduct/{id}")]
        public async Task<ActionResult<Product>> LockProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null || product.DeleteStatus == true)
            {
                return NotFound();
            }

            product.LockStatus = product.LockStatus != true;


            await _context.SaveChangesAsync();
            return product;
        }

        // PUT: api/Products/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            
            if (id != product.Id)
            {
                return BadRequest("Id is not matched");
            }
            var p = await _context.Product.FindAsync(id);
            if(p.DeleteStatus == true || p.LockStatus == true)
            {
                return BadRequest();
            }

            p.Name = product.Name;
            p.SKU = product.SKU;
            p.Description = product.Description;
            p.Price = product.Price;
            p.DeleteStatus = product.DeleteStatus;
            p.LockStatus = product.LockStatus;
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Products
       
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDto product)
        {
            var p = new Product
            {
                Name = product.Name,
                SKU = product.SKU,
                Price = product.Price,
                Description = product.Description,
                DeleteStatus =false,
                LockStatus =false
               
            };
            _context.Product.Add(p);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = p.Id },p);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
       
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Product.FirstOrDefaultAsync(p => p.DeleteStatus != true && p.Id == id);
            if (product == null )
            {
                return NotFound();
            }
            if(product.LockStatus == true)
            {
                return BadRequest();
            }

            product.DeleteStatus = true;
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
