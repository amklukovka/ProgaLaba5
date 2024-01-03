using SimpleContactBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleContactBook.Services
{
    public class MockDataService : IContactDataService
    {
        private IEnumerable<Contact> _contacts;
        public MockDataService()
        {
            _contacts = new List<Contact>()
            {
                new Contact
                {
                    Name = "Anya Klukva",
                    PhoneNumber = "+79633140888",
                    Email = "anyaklukva@yandex.ru" 
                },
                new Contact
                {
                    Name = "Tony Stark",
                    PhoneNumber = "+79062450407",
                    Email = "tonystark@yandex.ru"
                },
            };
        }
        public IEnumerable<Contact> GetContacts()
        {
            return _contacts;
        }

        public void Save(IEnumerable<Contact> contacts)
        {
            _contacts = contacts;
        }
    }
}
