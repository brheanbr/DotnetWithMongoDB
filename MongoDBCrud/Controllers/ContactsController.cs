using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DB;
using Core.DTO;
using Core.Model;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MongoDBCrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IDBClient _dbClient;

        public ContactsController(IDBClient dbClient)
        {
            _dbClient = dbClient;
        }


        [HttpGet("GetContacts")]
        public async Task<ActionResult <List<Contact>>> GetContacts()
        {
            return _dbClient.GetAll();
        }
           

        [HttpPost("AddContact")]
        public ActionResult<Contact> AddContact(Contact contact)
        {
            _dbClient.AddContact(contact);

            return contact;
        }
    }
}
