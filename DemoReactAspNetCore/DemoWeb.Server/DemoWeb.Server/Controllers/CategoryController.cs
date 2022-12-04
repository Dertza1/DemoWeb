using DemoWebApp.Models;
using DemoWebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext context;

        public CategoryController(AppDbContext context)
        {
            this.context = context;
        }

  
        [HttpPost]
        public async Task<ActionResult<IEnumerable<CategoryProduct>>> PostCategory([FromBody] CategoryDto categoryDto)
        {
            context.Categories.Add
                (
                    new CategoryProduct{ CategoryName = categoryDto.CategoryName }
                );

            await context.SaveChangesAsync();

            var categories = context.Categories.ToList();

            return Ok(categories);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<CategoryProduct>>> DeleteСategory([FromRoute] int id)
        {
            var category = await context.Categories.FirstOrDefaultAsync(b => b.Id == id);

            if (category is null)
            {
                return NotFound();
            }

            context.Remove(category);

            await context.SaveChangesAsync();

            var categories = await context.Categories.ToListAsync();

            return Ok(categories);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryProduct>>> GetAllCategories([FromQuery]string? filterNameCategory)
        {
            if (!string.IsNullOrEmpty(filterNameCategory))
            {
                var categoriesFilter = await context.Categories.Where(n=>n.CategoryName==filterNameCategory).ToListAsync();

                return Ok(categoriesFilter);
            }

            var categories = await context.Categories.ToListAsync();

            return Ok(categories);
        }

    }
}
