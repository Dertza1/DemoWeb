using DemoWebApp.Models;
using DemoWebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProductController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts([FromQuery] string? filterProviderName, [FromQuery] string? sortCost)
        {
            if (!string.IsNullOrEmpty(filterProviderName) && !string.IsNullOrEmpty(sortCost))
            {
                if (sortCost == "По возрастанию")
                {
                    var productFilterProviderOrderCost = context.Products.Where(n => n.ProviderId == context.Providers.FirstOrDefault(b => b.ProviderName == filterProviderName).Id).OrderBy(p => p.ProductCost).ToList();
                    return Ok(productFilterProviderOrderCost);
                }

                if (sortCost == "По убыванию")
                {
                    var productFilterProviderOrderCost = context.Products.Where(n => n.ProviderId == context.Providers.FirstOrDefault(b => b.ProviderName == filterProviderName).Id).OrderByDescending(p => p.ProductCost).ToList();
                    return Ok(productFilterProviderOrderCost);
                }
            }

            if (!string.IsNullOrEmpty(filterProviderName))
            {
                var productFilterProvider = context.Products.Where(n => n.ProviderId == context.Providers.FirstOrDefault(b => b.ProviderName == filterProviderName).Id).ToList();
                return Ok(productFilterProvider);
            }

            if (!string.IsNullOrEmpty(sortCost))
            {
                if (sortCost == "По возрастанию")
                {
                    var productOrderCost = context.Products.OrderBy(p => p.ProductCost).ToList();
                    return Ok(productOrderCost);
                }

                if (sortCost == "По убыванию")
                {
                    var productOrderCost = context.Products.OrderByDescending(p => Convert.ToDecimal(p.ProductCost));
                    return Ok(productOrderCost);
                }
            }

            var products = context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct([FromRoute] int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(n => n.Id == id);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> DeleteProduct([FromRoute] int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(b => b.Id == id);

            if (product is null)
            {
                return NotFound();
            }
            context.Remove(product);

            await context.SaveChangesAsync();

            var products = await context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Product>>> PostProduct([FromBody] ProductDto productDto)
        {
            if(productDto is null)
            {
                return BadRequest();
            }

            if(!context.Categories.Any(n => n.Id == productDto.CategoryId))
            {
                return NotFound("Нет такой категории");
            }

            try
            {
                Product newProduct = new()
                {
                    ProductName = productDto.ProductName,
                    ProductCost = productDto.ProductCost,
                    ProductDesc = productDto.ProductDesc,
                    CategoryId = productDto.CategoryId,
                    Category = context.Categories.Where(b=>b.Id == productDto.CategoryId).SingleOrDefault(),
                    Provider = context.Providers.Where(b=>b.Id == productDto.ProviderId).SingleOrDefault(),
                    ProviderId = productDto.ProviderId
                };

                context.Products.Add(newProduct);

                await context.SaveChangesAsync();

                var products = await context.Products.ToListAsync();

                return Ok(products);
            }

            catch (System.Exception ex)
            {
                return BadRequest($"Ошибка + {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> PutProduct([FromRoute] int id, [FromBody] ProductDto productDto)
        {
            if (productDto is null)
            {
                return BadRequest();
            }

            if (!context.Categories.Any(n => n.Id == productDto.CategoryId))
            {
                return NotFound("Нет такой категории");
            }

            if (!context.Providers.Any(n => n.Id == productDto.ProviderId))
            {
                return NotFound("Нет такого поставщика");
            }

            try
            {
                var product = await context.Products.FirstOrDefaultAsync(b => b.Id == id);

                product.ProductCost = productDto.ProductCost;
                product.ProductDesc = productDto.ProductDesc;
                product.ProductName = productDto.ProductName;
                product.CategoryId = productDto.CategoryId;
                product.ProviderId = productDto.ProviderId;
              
                context.Products.Update(product);

                await context.SaveChangesAsync();


                var products = await context.Products.ToListAsync();
                return Ok(products);
            }

            catch (System.Exception ex)
            {
                return BadRequest($"Ошибка + {ex.Message}");
            }

        }
    }
}
