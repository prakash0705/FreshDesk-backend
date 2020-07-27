using System;
using System.Collections.Generic;
using System.Text;

namespace FreshDesk.Entities.Request
{
    public class ChangeResponderRequest
    {
        public int userId { get; set; }
        public int responderId { get; set; }
    }
}
