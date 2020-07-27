using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace FreshDesk.Entities.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Int64 Mobile { get; set; }
        public int registerId { get; set; }
        public Register register { get; set; }
        
    }
}
