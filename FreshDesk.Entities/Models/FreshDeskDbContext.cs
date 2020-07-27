using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshDesk.Entities.Models
{
    public class FreshDeskDbContext:DbContext
    {
        public FreshDeskDbContext(DbContextOptions<FreshDeskDbContext> options):base(options)
        {

        }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Logs> Logs { get; set; }

    }
}
