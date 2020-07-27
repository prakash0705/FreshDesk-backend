using System;
using System.Collections.Generic;
using System.Text;

namespace FreshDesk.Entities.Request
{
    public class AddTicketRequest
    {
        public string title { get; set; }
        public string description { get; set; }
        public int UserId { get; set; }

    }
}
