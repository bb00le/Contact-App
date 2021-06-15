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
    public class ContactPhonesController : ControllerBase
    {
        private readonly ContactAppDBContext _context;

        public ContactPhonesController(ContactAppDBContext context)
        {
            _context = context;
        }

        // GET: api/ContactPhones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactPhone>>> GetContactPhones()
        {
            return await _context.ContactPhones.ToListAsync();
        }

        // GET: api/ContactPhones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactPhone>> GetContactPhone(int id)
        {
            var contactPhone = await _context.ContactPhones.FindAsync(id);

            if (contactPhone == null)
            {
                return NotFound();
            }

            return contactPhone;
        }

        // PUT: api/ContactPhones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactPhone(int id, ContactPhone contactPhone)
        {
            if (id != contactPhone.PhoneId)
            {
                return BadRequest();
            }

            _context.Entry(contactPhone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactPhoneExists(id))
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

        // POST: api/ContactPhones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactPhone>> PostContactPhone(ContactPhone contactPhone)
        {
            _context.ContactPhones.Add(contactPhone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactPhone", new { id = contactPhone.PhoneId }, contactPhone);
        }

        // DELETE: api/ContactPhones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactPhone(int id)
        {
            var contactPhone = await _context.ContactPhones.FindAsync(id);
            if (contactPhone == null)
            {
                return NotFound();
            }

            _context.ContactPhones.Remove(contactPhone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactPhoneExists(int id)
        {
            return _context.ContactPhones.Any(e => e.PhoneId == id);
        }
    }
}
