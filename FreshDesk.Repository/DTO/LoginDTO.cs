using System;
using System.Collections.Generic;
using System.Text;

namespace FreshDesk.Repository.DTO
{
    public class LoginDTO
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string token { get; set; }
       
    }
}
