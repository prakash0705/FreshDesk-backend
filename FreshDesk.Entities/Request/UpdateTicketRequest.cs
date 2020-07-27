using System;
using System.Collections.Generic;
using System.Text;

namespace FreshDesk.Entities.Request
{
    public class UpdateTicketRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
