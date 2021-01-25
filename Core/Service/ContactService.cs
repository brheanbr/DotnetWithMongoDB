using Core.DB;
using Core.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public class ContactService
    {
        private readonly IMongoCollection<Contact> _contact;
        public ContactService(IOptions<DBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _contact = database.GetCollection<Contact>(settings.Value.CollectionName);
        }
        public List<Contact> GetAll() =>
            _contact.Find(c => true).ToList();

        public Contact GetByName(string name) =>
            _contact.Find<Contact>(c => c.FirstName.Contains(name) || c.LastName.Contains(name)).FirstOrDefault();

        public Contact AddContact(Contact contact)
        {
            _contact.InsertOne(contact);
            return contact;
        }
            
    }
   
}
