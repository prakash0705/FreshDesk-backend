using System;
using System.Collections.Generic;
using System.Text;

namespace FreshDesk.Entities.Request
{
    public class AddContactRequest
    {
        
        public string email { get; set; }
        public long mobile { get; set; }
        public int userId { get; set; }

    }
}
