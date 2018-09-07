using ContactBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ContactBook.Services
{
    public class ContactService
    {
        private readonly ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>
        {
            new Contact { Id = 1, FirstName = "John", LastName = "Smith", Email = "john@smith.com", Phone = "1111" },
            new Contact{ Id = 2, FirstName="romaric", LastName="Nze", Email = "Rom@nze.com", Phone = "2222" },
            new Contact{ Id = 3, FirstName="Nina", LastName="Koua", Email = "nin@koua.com", Phone = "3333"},
            new Contact{ Id = 4, FirstName="Valery", LastName="Fetch", Email = "val@fetch.com", Phone = "4444"}
        };
        
        public ObservableCollection<Contact> GetContacts()
        {
            return _contacts;
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void DeleteContact(Contact contact)
        {
            _contacts.Remove(contact); 
        }
    }
}
