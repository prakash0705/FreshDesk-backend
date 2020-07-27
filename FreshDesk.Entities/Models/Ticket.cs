using System;
using System.Collections.Generic;
using System.Text;

namespace FreshDesk.Entities.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public int ResponderId { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public int registerId { get; set; }
        public Register register { get; set; }
    }
}
