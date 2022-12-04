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
    public class ProviderController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProviderController(AppDbContext context)
        {
            this.context = context;
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProviderProduct>>> PostCategory([FromBody] ProviderDto providerDto)
        {
            context.Providers.Add
                (
                    new ProviderProduct { ProviderName = providerDto.ProviderName }
                );

            await context.SaveChangesAsync();

            var providers = context.Providers.ToList();

            return Ok(providers);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<ProviderProduct>>> DeleteСategory([FromRoute] int id)
        {
            var provider = await context.Providers.FirstOrDefaultAsync(b => b.Id == id);

            if (provider is null)
            {
                return NotFound();
            }

            context.Remove(provider);

            await context.SaveChangesAsync();

            var providers = await context.Providers.ToListAsync();

            return Ok(providers);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProviderProduct>>> GetAllCategories([FromQuery] string? filterNameProvider)
        {
            if (!string.IsNullOrEmpty(filterNameProvider))
            {
                var providersFilter = await context.Providers.Where(n => n.ProviderName.Contains(filterNameProvider)).ToListAsync();

                return Ok(providersFilter);
            }

            var providers = await context.Providers.ToListAsync();

            return Ok(providers);
        }

    }
}
