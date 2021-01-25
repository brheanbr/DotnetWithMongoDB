using Core.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DB
{
    public class DBClient : IDBClient
    {
        private readonly IMongoCollection<Contact> _contact;
        public DBClient(IDBSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _contact = database.GetCollection<Contact>(settings.CollectionName);

        }

        public Contact AddContact(Contact contact)
        {
            _contact.InsertOne(contact);
            return contact;
        }

        public List<Contact> GetAll() =>
            _contact.Find(c => true).ToList();
        
      
            
   
    }

   
}
