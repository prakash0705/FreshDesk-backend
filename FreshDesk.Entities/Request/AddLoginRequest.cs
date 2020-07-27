using System;
using System.Collections.Generic;
using System.Text;

namespace FreshDesk.Entities.Request
{
    public class AddLoginRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
