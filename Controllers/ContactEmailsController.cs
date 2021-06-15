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
    public class ContactEmailsController : ControllerBase
    {
        private readonly ContactAppDBContext _context;

        public ContactEmailsController(ContactAppDBContext context)
        {
            _context = context;
        }

        // GET: api/ContactEmails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactEmail>>> GetContactEmails()
        {
            return await _context.ContactEmails.ToListAsync();
        }

        // GET: api/ContactEmails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactEmail>> GetContactEmail(int id)
        {
            var contactEmail = await _context.ContactEmails.FindAsync(id);

            if (contactEmail == null)
            {
                return NotFound();
            }

            return contactEmail;
        }

        // PUT: api/ContactEmails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactEmail(int id, ContactEmail contactEmail)
        {
            if (id != contactEmail.EmailId)
            {
                return BadRequest();
            }

            _context.Entry(contactEmail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactEmailExists(id))
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

        // POST: api/ContactEmails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactEmail>> PostContactEmail(ContactEmail contactEmail)
        {
            _context.ContactEmails.Add(contactEmail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactEmail", new { id = contactEmail.EmailId }, contactEmail);
        }

        // DELETE: api/ContactEmails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactEmail(int id)
        {
            var contactEmail = await _context.ContactEmails.FindAsync(id);
            if (contactEmail == null)
            {
                return NotFound();
            }

            _context.ContactEmails.Remove(contactEmail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactEmailExists(int id)
        {
            return _context.ContactEmails.Any(e => e.EmailId == id);
        }
    }
}
