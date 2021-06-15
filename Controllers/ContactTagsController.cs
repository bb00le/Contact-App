using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactListApp.Data;
using ContactListApp.Models;

namespace ContactListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTagsController : ControllerBase
    {
        private readonly ContactAppDBContext _context;

        public ContactTagsController(ContactAppDBContext context)
        {
            _context = context;
        }

        // GET: api/ContactTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactTag>>> GetContactTags()
        {
            return await _context.ContactTags.ToListAsync();
        }

        // GET: api/ContactTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactTag>> GetContactTag(int id)
        {
            var contactTag = await _context.ContactTags.FindAsync(id);

            if (contactTag == null)
            {
                return NotFound();
            }

            return contactTag;
        }

        // PUT: api/ContactTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactTag(int id, ContactTag contactTag)
        {
            if (id != contactTag.TagId)
            {
                return BadRequest();
            }

            _context.Entry(contactTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactTagExists(id))
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

        // POST: api/ContactTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactTag>> PostContactTag(ContactTag contactTag)
        {
            _context.ContactTags.Add(contactTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactTag", new { id = contactTag.TagId }, contactTag);
        }

        // DELETE: api/ContactTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactTag(int id)
        {
            var contactTag = await _context.ContactTags.FindAsync(id);
            if (contactTag == null)
            {
                return NotFound();
            }

            _context.ContactTags.Remove(contactTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactTagExists(int id)
        {
            return _context.ContactTags.Any(e => e.TagId == id);
        }
    }
}
