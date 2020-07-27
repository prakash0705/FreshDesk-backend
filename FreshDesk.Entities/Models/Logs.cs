using System;
using System.Collections.Generic;
using System.Text;

namespace FreshDesk.Entities.Models
{
    public class Logs
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }
        public Ticket ticket { get; set; }
        public int? ticketId { get; set; }
        public Register register { get; set; }
        public int registerId { get; set; }
    }

}
