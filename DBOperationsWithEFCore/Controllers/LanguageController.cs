using DBOperationsWithEFCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBOperationsWithEFCore.Controllers
{
    [Route("api/languages")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        public LanguageController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        // Action Method to get all languages
        [HttpGet("")]
        public async Task<IActionResult> GetAllLanguages()
        {
            var result = await (from language in this.appDbContext.Languages select language).ToListAsync();
            return Ok(result);
        }
    }
}
