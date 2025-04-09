using DBOperationsWithEFCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBOperationsWithEFCore.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public BooksController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        // Method to get all books from DB
        [HttpGet("")]  
        public async Task<IActionResult> GetAllbooks()
        {
            var books = await appDbContext.Books.ToListAsync();
            if(books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }


        // Method to Add data in Book table aka Book class
        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] Book data)
        {
            appDbContext.Books.Add(data); // Now updating data
            await appDbContext.SaveChangesAsync();
            return Ok(data);
        }

        // Updating data of dB
        [HttpPut("")]
        public async Task<IActionResult> UpdateBooksWithSingleQuery([FromBody] Book data)
        {
            appDbContext.Books.Update(data);
            await appDbContext.SaveChangesAsync();

            return Ok(data);
        }

        // Delete data from DB
        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBookById([FromRoute] int bookId)
        {
            var deletedBook = await appDbContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);
            if (deletedBook == null)
            {
                return NotFound();
            }

            appDbContext.Books.Remove(deletedBook);
            await appDbContext.SaveChangesAsync();

            return Ok(deletedBook);
        }


    }
}
