using FreshDesk.Entities.Models;
using FreshDesk.Entities.Request;
using FreshDesk.Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshDesk.Repository.Repository
{
    public interface IContactRepository
    {
        List<ViewContactDTO> ViewContact(int id);
        bool AddContact(AddContactRequest request);
        bool UpdateContact(UpdateContactRequest request);
        bool DeleteContact(DeleteContactRequest request);
        
    }
}
