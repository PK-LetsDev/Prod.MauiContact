using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.HelloWorld.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact() {Id = 1, Name = "John Doe", Email = "JohnDoe@gmail.com"},
            new Contact() {Id = 2, Name = "Jane Doe", Email = "JaneDoe@gmail.com"},
            new Contact() { Id = 3, Name = "A Doe", Email = "ADoe@gmail.com"},
            new Contact() {Id = 4, Name = "B Doe", Email = "BDoe@gmail.com"}
        };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContactsById(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == contactId);
            if (contact != null)
            {
                return new Contact
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Address = contact.Address
                };
            }

            return null;
        }

        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.Id) return;

            var contactToUpdate = _contacts.FirstOrDefault(x => x.Id == contactId);
            if (contactToUpdate != null)
            {
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Phone = contact.Phone;
            }
        }

        public static void AddContact(Contact contact)
        {
            var maxId = _contacts.Max(x => x.Id);
            contact.Id = maxId +1;
            _contacts.Add(contact);
        }

        public static void DeleteContact(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == contactId);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }

        public static List<Contact> SearchContacts(string filterText)
        {
           var contacts= _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
           if(contacts == null || contacts.Count <= 0)
           
              contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
           else
               return contacts;

           if (contacts == null || contacts.Count <= 0)

               contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
           else
               return contacts;

           if (contacts == null || contacts.Count <= 0)

               contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
           else
               return contacts;

           return contacts;
        }
    }
}
