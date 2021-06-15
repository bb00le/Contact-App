using ContactListApp.Data;
using ContactListApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactListApp.Controllers
{
    [Route("api/Search")]
    [ApiController]
    public class Search : ControllerBase
    {
        // GET: api/<SearchController>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactInfo>>> SearchContactsAsync([FromQuery] ContactSearch searchParams)
        {
            ContactAppDBContext context = new ContactAppDBContext();
            List<ContactInfo> contact=null;

            

            if (searchParams == null)
            {
                return BadRequest("Invalid search options");
            }

            if (searchParams.searchType == "FirstName")
            {
                
                contact = await context.ContactInfos
                    .Where(b => b.ContactFirstName.Contains(searchParams.searchString))
                    .ToListAsync();

            }

            else if (searchParams.searchType == "LastName")
            {

                contact = await context.ContactInfos
                    .Where(b => b.ContactLastName.Contains(searchParams.searchString))
                    .ToListAsync();

            }
            else if (searchParams.searchType == "Tag")
            {

                List<ContactTag> matchingTags = context.ContactTags
                    .Where(t => t.Tag.Contains(searchParams.searchString))
                    .ToList();

                contact = await context.ContactInfos
                    .Where(b => b.ContactTags.Intersect(matchingTags).Any())
                    .ToListAsync();

            }

            if (contact == null)
            {
                return NotFound();
            }

            return contact;


        }
    }
}
