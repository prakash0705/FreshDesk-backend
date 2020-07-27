using System;
using System.Collections.Generic;
using System.Text;

namespace FreshDesk.Entities.Request
{
    public class AddRegisterRequest
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}
