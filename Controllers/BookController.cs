using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class BookController : ControllerBase
    {
        private readonly Models.LibraryContext _dbContext;

        public BookController(Models.LibraryContext dbContext)

        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Getbooks()
        {
            var books = await _dbContext.Books.ToArrayAsync();

            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Getbooks(int id)
        {
            if (_dbContext.Books == null)
            {
                return NotFound();
            }
            var books = await _dbContext.Books.FindAsync(id);

            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBooks(Book books)
        {
            _dbContext.Books.Add(books);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Getbooks), new { id = books.id }, books);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            if (_dbContext.Books == null)
            {
                return NotFound();
            }

            var books = await _dbContext.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }

            _dbContext.Books.Remove(books);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutBook(int id, Book books)
        {
            if (id != books.id)
            {
                return BadRequest();
            }

            _dbContext.Entry(books).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool BookExists(long id)
        {
            return (_dbContext.Books?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

