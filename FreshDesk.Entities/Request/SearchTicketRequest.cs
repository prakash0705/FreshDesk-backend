using System;
using System.Collections.Generic;
using System.Text;

namespace FreshDesk.Entities.Request
{
    public class SearchTicketRequest
    {
        public int ticketid { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int registerId { get; set; }

    }
}
