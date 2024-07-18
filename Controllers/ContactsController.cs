using ContactApp.Models;
using ContactApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Controllers
{
    /// <summary>
    /// Represent a Contacts Controller
    /// </summary>
    
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        #region Fields
        private readonly ContactService _contactService;
        #endregion

        #region Constructor
        public ContactsController()
        {
            _contactService = new ContactService();
        }
        #endregion

        #region Methods

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetAll()
        {
            return Ok(_contactService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            var contact = _contactService.Get(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpPost]
        public ActionResult Add(Contact contact)
        {
            _contactService.Add(contact);
            return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Contact contact)
        {
            if (id != contact.Id) return BadRequest();
            var existingContact = _contactService.Get(id);
            if (existingContact == null) return NotFound();
            _contactService.Update(contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var contact = _contactService.Get(id);
            if (contact == null) return NotFound();
            _contactService.Delete(id);
            return NoContent();
        }

        #endregion
    }
}

