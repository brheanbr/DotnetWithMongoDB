using Core.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DB
{
    public interface IDBClient
    {
        public List<Contact> GetAll();
        public Contact AddContact(Contact contact);
    }
}
