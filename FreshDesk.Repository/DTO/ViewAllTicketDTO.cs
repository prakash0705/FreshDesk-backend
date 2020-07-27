using System;
using System.Collections.Generic;
using System.Text;

namespace FreshDesk.Repository.DTO
{
    public class ViewAllTicketDTO
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string responderName { get; set; }
        public DateTime created { get; set; }
        public DateTime lastModified { get; set; }

    }
}
