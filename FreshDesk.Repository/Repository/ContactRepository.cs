using FreshDesk.Entities.Models;
using FreshDesk.Entities.Request;
using FreshDesk.Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreshDesk.Repository.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly FreshDeskDbContext _db;
        public ContactRepository(FreshDeskDbContext db)
        {
            this._db = db;
        }

        public bool AddContact(AddContactRequest request)
        {
            if(request!=null)
            {
                int secretNumber = 5306;
                request.userId = request.userId - secretNumber;
                var result = _db.Contacts.Where(a => a.registerId == request.userId).FirstOrDefault();
                if (result == null)
                {
                    Contact contact = new Contact
                    {
                        Email = request.email,
                        Mobile = request.mobile,
                        registerId = request.userId
                    };
                    _db.Contacts.Add(contact);
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool DeleteContact(DeleteContactRequest request)
        {
            var contact = _db.Contacts.Where(a => a.Id == request.Id).FirstOrDefault();
            if(contact!=null)
            {
                _db.Contacts.Remove(contact);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateContact(UpdateContactRequest request)
        {
            if(request!=null)
            {
                var contact = _db.Contacts.Where(a => a.Id == request.ContactId).FirstOrDefault();
                if(contact!=null)
                {
                    contact.Mobile = request.Phone;
                    contact.Email = request.Email;
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public List<ViewContactDTO> ViewContact(int id=0)
        {
            //secret number is to hide the exact user id and sending another ids
            int secretNumber = 5306;
            id = id - secretNumber;
            var contact = id != 0 ? _db.Contacts.Where(a=>a.registerId==id).ToList() : _db.Contacts.ToList();
            List<ViewContactDTO> contactDTOs = new List<ViewContactDTO>();
            if (contact.Count!=0)
            {
                int i = 0;
                List<string> personName = new List<string>();
                foreach (var item in contact)
                {
                    var person = _db.Registers.Where(a => a.Id == item.registerId).FirstOrDefault();
                    personName.Add(person.FirstName + " " + person.LastName);
                }
                foreach (var item in contact)
                {
                    contactDTOs.Add(new ViewContactDTO
                    {
                        Id = item.Id,
                        email = item.Email,
                        mobile = item.Mobile,
                        name =personName[i],
                    });
                    i++;
                }
                i = 0;
            }
            return contactDTOs;

        }
    }
}
