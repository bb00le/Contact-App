
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactListApp.Data;
using ContactListApp.Models;

namespace ContactListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly ContactAppDBContext _context;

        public ContactInfoController(ContactAppDBContext context)
        {
            _context = context;
        }

        // GET: api/ContactInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactInfo>>> GetContactInfos()
        {
            await _context.ContactPhones.ToListAsync();
            await _context.ContactEmails.ToListAsync();
            await _context.ContactTags.ToListAsync();
            return await _context.ContactInfos.ToListAsync();
            
        }

        // GET: api/ContactInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactInfo>> GetContactInfo(int id)
        {
            await _context.ContactPhones.ToListAsync();
            await _context.ContactEmails.ToListAsync();
            await _context.ContactTags.ToListAsync();
            var contactInfo = await _context.ContactInfos.FindAsync(id);

            if (contactInfo == null)
            {
                return NotFound();
            }

            return contactInfo;
        }
        

        // PUT: api/ContactInfo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactInfo(int id, ContactInfo contactInfo)
        {
            if (id != contactInfo.ContactId)
            {
                return BadRequest();
            }

            _context.Update(contactInfo);

            try
            {
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactInfoExists(id))
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

        // POST: api/ContactInfo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactInfo>> PostContactInfo(ContactInfo contactInfo)
        {
            _context.ContactInfos.Add(contactInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactInfo", new { id = contactInfo.ContactId }, contactInfo);
        }

        // DELETE: api/ContactInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactInfo(int id)
        {
            var contactInfo = await _context.ContactInfos.FindAsync(id);
            if (contactInfo == null)
            {
                return NotFound();
            }
            
            _context.ContactInfos.Remove(contactInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactInfoExists(int id)
        {
            return _context.ContactInfos.Any(e => e.ContactId == id);
        }
    }
}
