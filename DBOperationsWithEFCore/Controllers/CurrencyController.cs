using DBOperationsWithEFCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBOperationsWithEFCore.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        // method to get all currencies
        [HttpGet("")]
        public async Task<IActionResult> GetAllCurrencies()
        {
            //var result = this.appDbContext.Currencies.ToList();
            var result = await (from currency in this.appDbContext.Currencies select currency).ToListAsync();
            
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // Method to fetch currency by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrencyById([FromRoute] int id)
        {
           var result = await this.appDbContext.Currencies.FindAsync(id);
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // Method to get data based on name -> Using FirstOrDefault
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetCurrencyByName([FromRoute] string name)
        {
            // Normal query
            //var result = await (from currency in appDbContext.Currencies
            //                    where currency.Title == name
            //                    select currency).FirstOrDefaultAsync();


            // Method query for the same
            var result = await appDbContext.Currencies
                                           .Where(obj => obj.Title == name)
                                           .FirstOrDefaultAsync();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
