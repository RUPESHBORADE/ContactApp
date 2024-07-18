using ContactApp.Models;
using Newtonsoft.Json;

namespace ContactApp.Services
{
    /// <summary>
    /// Represent a Contact Services
    /// </summary>
    public class ContactService
    {
        #region Fields
        private readonly string filePath = "contacts.json";
        private List<Contact> contacts;
        #endregion

        #region Constructor
        public ContactService()
        {
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                contacts = JsonConvert.DeserializeObject<List<Contact>>(jsonData) ?? new List<Contact>();
            }
            else
            {
                contacts = new List<Contact>();
            }
        }
        #endregion

        #region Services
        public IEnumerable<Contact> GetAll() => contacts;

        public Contact Get(int id) => contacts.FirstOrDefault(c => c.Id == id);

        public void Add(Contact contact)
        {
            contact.Id = contacts.Count > 0 ? contacts.Max(c => c.Id) + 1 : 1;
            contacts.Add(contact);
            SaveChanges();
        }

        public void Update(Contact contact)
        {
            var existingContact = Get(contact.Id);
            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Email = contact.Email;
                SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var contact = Get(id);
            if (contact != null)
            {
                contacts.Remove(contact);
                SaveChanges();
            }
        }

        private void SaveChanges()
        {
            var jsonData = JsonConvert.SerializeObject(contacts);
            File.WriteAllText(filePath, jsonData);
        }
        #endregion
    }
}
   