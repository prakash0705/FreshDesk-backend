using System;
using System.Collections.Generic;
using System.Text;

namespace FreshDesk.Entities.Request
{
    public class UpdateContactRequest
    {
        public int ContactId { get; set; }
        public string Email { get; set; }
        public Int64 Phone { get; set; }
        
    }
}
