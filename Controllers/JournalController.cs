using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Library.Models;
using Library.Dtos;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class JournalController : ControllerBase
    {
        private readonly Models.LibraryContext _dbContext;
        public JournalController(Models.LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> GetJornals()
        {
            var journals = await _dbContext.Journals.ToArrayAsync();
            if (journals == null)
            {
                return NotFound();
            }
            return Ok(journals);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetJournals(int id)
        {
            if (_dbContext.Journals == null)
            {
                return NotFound();
            }
            var journals = await _dbContext.Journals.FindAsync(id);

            if (journals == null)
            {
                return NotFound();
            }
            return Ok(journals);
        }      

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Journals>> PostJournal([FromBody]Journals journals)
        {
            var newJournal = new Journal()
            { 
                UniqueId = Guid.NewGuid(),
                Title = journals.Title,
                Author = journals.Author,
                Publisher = journals.Publisher
            };

            _dbContext.Journals.Add(newJournal);
                await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJournals), new { id = newJournal.UniqueId }, newJournal);
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public async Task<ActionResult> PutJournal(int id, Journal journals)
        //{
        //    if (id != journals.id)
        //    {
        //        return BadRequest();
        //    }

        //    _dbContext.Entry(journals).State = EntityState.Modified;

        //    try
        //    {
        //        await _dbContext.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!JournalExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        //private bool journalExists(long id)
        //{
        //    return(_dbContext.Journals?.Any(e => e.id == id)).GetValueOrDefault();
        //}
    }
}

